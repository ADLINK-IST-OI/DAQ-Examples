#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <process.h>
#include "wd-dask.h"
#include "wddaskex.h"

#define _STORE_TEXT_FILE

#define _MODULE_COUNT 2

#define _SAMPLE_COUNT 4000 // Number of samples per one buffer half-ready
#define _BUFFER_COUNT (_SAMPLE_COUNT * 8) // all channels

#define _SAMPLE_RATE  4000
#define _BASE_CLOCK   100000000 // 100MHz

const U16 card_type = PXIe_9848;
U16 card_num[_MODULE_COUNT]; // card_num[0] for master
U16 card_handle[_MODULE_COUNT]; // card_handle[0] for master
U16 chnl_range[_MODULE_COUNT];
U16 ai_buf[_MODULE_COUNT][2][_BUFFER_COUNT] = {0};
U16 buf_id[_MODULE_COUNT][2] = {0};
const U32 sample_intrv = _BASE_CLOCK / _SAMPLE_RATE; //smaple_rate = 100MHz / sample_intrv
U32 start_pos[_MODULE_COUNT] = {0};
U32 access_cnt[_MODULE_COUNT] = {0};
U32 ready_count[_MODULE_COUNT] = {0};

BOOL is_ssi_routed[_MODULE_COUNT] = {0};
BOOL is_buf_set[_MODULE_COUNT] = {0};
BOOL is_ai_started[_MODULE_COUNT] = {0};
BOOL is_ai_stopping[_MODULE_COUNT] = {0};
BOOL is_ai_thr_started[_MODULE_COUNT] = {0};

char file_name[_MODULE_COUNT][MAX_PATH] = {0};
char time_stamp_folder[MAX_PATH] = {0};
char file_path[_MODULE_COUNT][MAX_PATH] = {0};

char* get_time_stamp_folder()
{
    static char time_folder[MAX_PATH] = {0};

    SYSTEMTIME ltime;
    GetLocalTime(&ltime);
    sprintf(time_folder, "%04d%02d%02d_%02d%02d%02d_%3d", ltime.wYear, ltime.wMonth, ltime.wDay, ltime.wHour, ltime.wMinute, ltime.wSecond, ltime.wMilliseconds);

    return time_folder;
}

int exit_handle(int ret_value)
{
    // Stop operation
    for (int vi = 0; vi < _MODULE_COUNT; ++ vi)
    {
        if (is_ai_started[vi])
        {
            WD_AI_AsyncClear(card_handle[vi], &start_pos[vi], &access_cnt[vi]);
            is_ai_started[vi] = FALSE;
        }
    }

    // Reset buffer
    for (int vi = 0; vi < _MODULE_COUNT; ++ vi)
    {
        if (is_buf_set[vi])
        {
            WD_AI_ContBufferReset(card_handle[vi]);
            is_buf_set[vi] = FALSE;
        }
    }

    // Reset SSI route
    for (int vi = 0; vi < _MODULE_COUNT; ++ vi)
    {
        if (is_ssi_routed[vi])
        {
            WD_Signal_DisConn(card_handle[0], SSI_TRIG_SRC1, PXI_TRIG_0);
            is_ssi_routed[vi] = FALSE;
        }
    }

    // Close device
    for (int vi = 0; vi < _MODULE_COUNT; ++ vi)
    {
        if (card_handle[vi] != 0xffff)
        {
            WD_Release_Card(card_handle[vi]);
            card_handle[vi] = 0xffff;
        }
    }

    printf("\nPress 'Enter' to exit...");
    getchar();
    return ret_value;
}

int repeat_handle()
{
    int result;

    printf("\nDo you want to repeat the operation? [Y]es or [N]o: [N] ");
    char sel = getch();
    if (sel != 'Y' && sel != 'y' )
    {
        printf("\n");
        return 0;
    }
    else
    {
        //
        // De-initial for repeat opeation
        //
        printf("\n\n");

        // Stop operation
        for (int vi = 0; vi < _MODULE_COUNT; ++ vi)
        {
            if (is_ai_started[vi])
            {
                WD_AI_AsyncClear(card_handle[vi], &start_pos[vi], &access_cnt[vi]);
                is_ai_started[vi] = FALSE;
            }
        }

        // Reset buffer
        for (int vi = 0; vi < _MODULE_COUNT; ++ vi)
        {
            if (is_buf_set[vi])
            {
                WD_AI_ContBufferReset(card_handle[vi]);
                is_buf_set[vi] = FALSE;
            }
        }
        return 1;
    }
}

void check_ai_buf_ready(void *p)
{
    U32 idx = (U32)p;
    U16 handle;
    BOOLEAN half_ready = FALSE;
    BOOLEAN stop_flag = FALSE;
    U32 op_sts;
    U16 buf_idx = 0;
    FILE *fp;

    if (idx >= _MODULE_COUNT)
    {
        // Invalid index
        return;
    }

    // Set flag
    is_ai_thr_started[idx] = TRUE;

    // Wait for AI started
    do {
        Sleep(1);
    } while (! is_ai_started[idx]);

    // Open file
    fp = fopen(file_path[idx], "wb");

    // Check buffer ready
    handle = card_handle[idx];
    do {
        WD_AI_AsyncDblBufferHalfReady(handle, &half_ready, &stop_flag);
        WD_AI_ContStatus(handle, &op_sts);
        if (op_sts & 0x60000000)
        {
            if (op_sts & 0x20000000)
            {
                printf("device handle: %d, buffer overrun...\n");
            }
            if (op_sts & 0x40000000)
            {
                printf("device handle: %d, DDR overflow (%x)...\n", op_sts);
            }
        }
        if (half_ready)
        {
            ready_count[idx] ++;
            printf("device handle: %d, half_ready: %d, stop_flag: %d, ready_count: %d\n", handle, half_ready, stop_flag, ready_count[idx]);

            //
            // Process file HERE
            //
            if (fp)
            {
                // Only write raw data to binary file
                fwrite(ai_buf[idx][buf_idx], 1, sizeof(ai_buf[idx][buf_idx]), fp);

                //F64 buf_scale[_BUFFER_COUNT];
                //WD_AI_ContVScale(handle, chnl_range[idx], ai_buf[idx][buf_idx], buf_scale, _BUFFER_COUNT);
            }

            // Tell DASK buffer is handled
            WD_AI_AsyncDblBufferHandled(handle);

            // Set next ready buffer index
            buf_idx = (buf_idx == 0)? 1:0;
        }
        if (stop_flag)
        {
            break;
        }
        Sleep(1);
    } while (is_ai_stopping[idx] == FALSE);

    // Stop AI
    WD_AI_AsyncClear(handle, &start_pos[idx], &access_cnt[idx]);
    is_ai_stopping[idx] = FALSE;
    is_ai_started[idx] = FALSE;

    // Close file
    if (fp)
    {
        fclose(fp);
    }

    // Exit thread
    is_ai_thr_started[idx] = FALSE;
    _endthread();
}

int main(int argc, char **argv)
{
    I16 status = -1;

    printf("This example performs PXIe-9848 simultaneous operation.\n");
    printf("Press 'Enter' to continue...");
    getchar();

    if (_MODULE_COUNT < 2 || _MODULE_COUNT > 32)
    {
        printf("\nNumber of devices is invalid.\n");
        return exit_handle(1);
    }

    // Initial variables
    for (unsigned short vi = 0; vi < _MODULE_COUNT; ++ vi)
    {
        card_num[vi] = vi;
        card_handle[vi] = 0xffff;
        chnl_range[vi] = AD_B_2_V;
        sprintf(file_name[vi], "ai_data_%d.dat", vi);
    }

    // Open device
    for (int vi = 0; vi < _MODULE_COUNT; ++ vi)
    {
        if (vi == 0)
        {
            // Master
            printf("\nOpen device %d (Master)... ", vi);
        }
        else
        {
            printf("Open device %d (Slave)... ", vi);
        }
        status = WD_Register_Card(card_type, card_num[vi]);
        if (status < 0)
        {
            printf("Failed\n");
            printf("\nFailed to perform WD_Register_Card(%d), status: %d\n", vi, status);
            return exit_handle(1);
        }
        printf("done\n");
        card_handle[vi] = (U16)status;
    }

    //
    // Configure master device
    //
    printf("Configure device 0 (Master)... ");
    // Configure AI channel
    status = WD_AI_CH_Config(card_handle[0], -1 /*all channels*/, chnl_range[0]);
    if (status != NoError)
    {
        printf("Failed\n");
        printf("\nFailed to perform WD_AI_CH_Config(0), status: %d\n", status);
        return exit_handle(2);
    }
    // Configure AI function
    status = WD_AI_Config(card_handle[0], WD_IntTimeBase/*WD_PXIe_CLK100*/, 1, WD_AI_ADCONVSRC_TimePacer, FALSE, FALSE);
    if (status != NoError)
    {
        printf("Failed\n");
        printf("\nFailed to perform WD_AI_Config(0), status: %d\n", status);
        return exit_handle(2);
    }
    // Configure AI trigger
    status = WD_AI_Trig_Config(card_handle[0], WD_AI_TRGMOD_POST, WD_AI_TRGSRC_SOFT, WD_AI_TrgPositive, 0, 0.0, 0, 0, 0, 1);
    if (status != NoError)
    {
        printf("Failed\n");
        printf("\nFailed to perform WD_AI_Trig_Config(0), status: %d\n", status);
        return exit_handle(2);
    }
    // Route simultaneous signal
    status = WD_Route_Signal(card_handle[0], SSI_TRIG_SRC1, PXI_TRIG_0, 1);
    if (status != NoError)
    {
        printf("Failed\n");
        printf("\nFailed to perform WD_Route_Signal(0), status: %d\n", status);
        return exit_handle(2);
    }
    is_ssi_routed[0] = TRUE;
    printf("done\n");

    //
    // Configure slave devices
    //
    for (int vi = 1; vi <_MODULE_COUNT; ++ vi)
    {
        printf("Configure device %d (Slave)... ", vi);
        // Configure AI channel
        status = WD_AI_CH_Config(card_handle[vi], -1 /*all channels*/, chnl_range[vi]);
        if (status != NoError)
        {
            printf("Failed\n");
            printf("\nFailed to perform WD_AI_CH_Config(%d), status: %d\n", vi, status);
            for (int vj = 0; vj < vi; ++ vj)
            {
                WD_Signal_DisConn(card_handle[vj], SSI_TRIG_SRC1, PXI_TRIG_0);
            }
            return exit_handle(3);
        }
        // Configure AI function
        status = WD_AI_Config(card_handle[vi], WD_IntTimeBase/*WD_PXIe_CLK100*/, 1, WD_AI_ADCONVSRC_TimePacer, FALSE, FALSE);
        if (status != NoError)
        {
            printf("Failed\n");
            printf("\nFailed to perform WD_AI_Config(%d), status: %d\n", vi, status);
            for (int vj = 0; vj < vi; ++ vj)
            {
                WD_Signal_DisConn(card_handle[vj], SSI_TRIG_SRC1, PXI_TRIG_0);
            }
            return exit_handle(3);
        }
        // Configure AI trigger
        status = WD_AI_Trig_Config(card_handle[vi], WD_AI_TRGMOD_POST, WD_AI_TRSRC_SSI_1, WD_AI_TrgPositive, 0, 0.0, 0, 0, 0, 1);
        if (status != NoError)
        {
            printf("Failed\n");
            printf("\nFailed to perform WD_AI_Trig_Config(%d), status: %d\n", vi, status);
            for (int vj = 0; vj < vi; ++ vj)
            {
                WD_Signal_DisConn(card_handle[vj], SSI_TRIG_SRC1, PXI_TRIG_0);
            }
            return exit_handle(3);
        }
        // Route simultaneous signal
        status = WD_Route_Signal(card_handle[vi], SSI_TRIG_SRC1, PXI_TRIG_0, 0);
        if (status != NoError)
        {
            printf("Failed\n");
            printf("\nFailed to perform WD_Route_Signal(%d), status: %d\n", vi, status);
            for (int vj = 0; vj < vi; ++ vj)
            {
                WD_Signal_DisConn(card_handle[vj], SSI_TRIG_SRC1, PXI_TRIG_0);
            }
            return exit_handle(3);
        }
        is_ssi_routed[vi] = TRUE;
        printf("done\n");
    }

//
// Repeat procedure
//
_repeat_operation:

    //
    // Setup buffer for continuous AI operation
    //
    for (int vi = 0; vi <_MODULE_COUNT; ++ vi)
    {
        if (vi == 0)
        {
            printf("Setup buffer for device %d (Master)... ", vi);
        }
        else
        {
            printf("Setup buffer for device %d (Slave)... ", vi);
        }
        // Enable double buffer mode
        status = WD_AI_AsyncDblBufferMode(card_handle[vi], TRUE);
        if (status != NoError)
        {
            printf("Failed\n");
            printf("\nFailed to perform WD_AI_AsyncDblBufferMode(%d), status: %d\n", vi, status);
            return exit_handle(4);
        }
        // Setup buffer
        status = WD_AI_ContBufferSetup(card_handle[vi], ai_buf[vi][0], _BUFFER_COUNT, &buf_id[vi][0]);
        if (status != NoError)
        {
            printf("Failed\n");
            printf("\nFailed to perform WD_AI_ContBufferSetup(%d, 0), status: %d\n", vi, status);
            return exit_handle(4);
        }
        status = WD_AI_ContBufferSetup(card_handle[vi], ai_buf[vi][1], _BUFFER_COUNT, &buf_id[vi][1]);
        if (status != NoError)
        {
            printf("Failed\n");
            printf("\nFailed to perform WD_AI_ContBufferSetup(%d, 1), status: %d\n", vi, status);
            WD_AI_ContBufferReset(card_handle[vi]);
            return exit_handle(4);
        }
        is_buf_set[vi] = TRUE;
        printf("done\n");
    }

    // Create data folder
    sprintf(time_stamp_folder, get_time_stamp_folder());
    CreateDirectory(time_stamp_folder, NULL);
    for (int vi = 0; vi <_MODULE_COUNT; ++ vi)
    {
        sprintf(file_path[vi], "%s\\%s", time_stamp_folder, file_name[vi]);
    }

    // Begin thread for checking buffer ready
    for (unsigned int vi = 0; vi < _MODULE_COUNT; ++ vi)
    {
        if (vi == 0)
        {
            printf("Create thread for device %d (Master)... ", vi);
        }
        else
        {
            printf("Create thread for device %d (Slave)... ", vi);
        }
        ready_count[vi] = 0;
        _beginthread(check_ai_buf_ready, 0, (void *)vi);
        do {
            Sleep(1);
        } while (is_ai_thr_started[vi] == FALSE);
        printf("done\n");
    }

    // Start slave device
    for (int vi = 1; vi <_MODULE_COUNT; ++ vi)
    {
        printf("Start AI operation for device %d (Slave)... ", vi);
        status = WD_AI_ContScanChannels(card_handle[vi], 7, buf_id[vi][0], _SAMPLE_COUNT, sample_intrv, sample_intrv, ASYNCH_OP);
        if (status != NoError)
        {
            printf("Failed\n");
            printf("\nFailed to perform WD_AI_ContScanChannels(%d), status: %d\n", vi, status);
            return exit_handle(5);
        }
        is_ai_started[vi] = TRUE;
        printf("done\n");
    }

    // All device will be started simultaneously while master device is started.
    printf("\nPress 'Enter' to start AI operation\n");
    printf("And then you can press another 'Enter' to stop...\n");
    getchar();

    // Start master device
    status = WD_AI_ContScanChannels(card_handle[0], 7, buf_id[0][0], _SAMPLE_COUNT, sample_intrv, sample_intrv, ASYNCH_OP);
    if (status != NoError)
    {
        printf("\nFailed to perform WD_AI_ContScanChannels(0), status: %d\n", status);
        return exit_handle(5);
    }
    is_ai_started[0] = TRUE;

    // Press to stop operation
    getchar();

    // Set stopping flag
    for (int vi = 0; vi < _MODULE_COUNT; ++ vi)
    {
        is_ai_stopping[vi] = TRUE;
    }

    // Wait thread stopped
    for (int vi = 0; vi < _MODULE_COUNT; ++ vi)
    {
        do {
            Sleep(1);
        } while (is_ai_thr_started[vi] == TRUE);
    }

    printf("\nOperation is complete.\n");

    // Transform Data
    printf("\nDo you want to transform binary data? [Y]es or No: [Y] ");
    char sel = getch();
    if (sel != 'N' && sel != 'n' )
    {
        for (int vi = 0; vi < _MODULE_COUNT; ++ vi)
        {
            printf("\nConverting file, %s, it may take a few seconds, please wait... ", file_name[vi]);

            // Target file name
            char scale_file_path[MAX_PATH] = {0};
        #if defined _STORE_TEXT_FILE
            sprintf(scale_file_path, "%s.csv", file_path[vi]);
        #else
            sprintf(scale_file_path, "%s.bin", file_path[vi]);
        #endif

        // Open raw file
            FILE *fp_raw = fopen(file_path[vi], "rb");
        #if defined _STORE_TEXT_FILE
            FILE *fp_scale = fopen(scale_file_path, "w");
        #else
            FILE *fp_scale = fopen(scale_file_path, "wb");
        #endif

            if (fp_raw && fp_scale)
            {
                rewind(fp_raw);
                do {
                    U16 buf_raw[8]; //Channel
                    int read_cnt = fread(buf_raw, 1, sizeof(buf_raw), fp_raw);
                    read_cnt /= 2;

                    F64 buf_scale[8];
                    WD_AI_ContVScale(card_handle[vi], chnl_range[vi], (void *)buf_raw, buf_scale, read_cnt);

                #if defined _STORE_TEXT_FILE
                    for (int vj = 0; vj < read_cnt; ++ vj)
                    {
                        fprintf(fp_scale, "%.5f, ", buf_scale[vj]);
                    }
                    fprintf(fp_scale, "\n");
                #else
                    fwrite(buf_scale, 1, sizeof(buf_scale), fp_scale);
                #endif

                    if (read_cnt < 8)
                    {
                        break;
                    }
                } while (1);
            }

            if (fp_raw)
            {
                fclose(fp_raw);
            }
            if (fp_scale)
            {
                fclose(fp_scale);
            }

            printf("done");
        }
    }
    printf("\n");

    if (repeat_handle() != 0)
    {
        // Repeat operation
        goto _repeat_operation;
    }

    return exit_handle(0);
}
