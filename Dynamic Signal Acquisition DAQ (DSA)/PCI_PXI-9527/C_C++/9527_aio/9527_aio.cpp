#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <conio.h>

#include "DSA-Dask.h"

#define SAMPLE_COUNT  1024
#define CHANNEL_COUNT 2
#define SAMPLE_RATE   48000

int main()
{
    // Device configuration variables
    I16 status;
    U16 card;
    // Sample clock variables
    U16 clk_conf = PXI9527_AIO_1to1;
    U16 clk_source = P9527_Internal;
    F64 clk_sample_rate = SAMPLE_RATE;
    F64 clk_actual_rate = 0.0;
    // Trigger variables
    U16 trig_target = P9527_TRG_ALL;
    U16 trig_ctrl = P9527_TRG_SRC_SOFT | P9527_TRG_MODE_POST;
    // AI Variables
    U32 ai_read_cnt = SAMPLE_COUNT;
    U16 ai_channel = P9527_AI_CH_DUAL;
    U32 ai_chnl_cnt = CHANNEL_COUNT;
    U16 ai_range = AD_B_1_V;
    U16 ai_cfg = P9527_AI_PseudoDifferential | P9527_AI_Coupling_DC;
    BOOLEAN ai_buffer_set = FALSE;
    U32 ai_buffer_cnt = ai_read_cnt * ai_chnl_cnt;
    U32 *ai_raw_buffer[2] = {0,};
    U16 ai_buffer_id[2];
    F64 *ai_scale_buffer[2] = {0,};
    BOOLEAN ai_acq_start = FALSE;
    BOOLEAN ai_half_ready = 0;
    BOOLEAN ai_stopped = 0;
    U16 ai_buffer_idx = 0;
    U32 ai_half_rdy_cnt = 0;
    U32 ai_access_cnt;
    // AO Variables
    U32 ao_write_cnt = SAMPLE_COUNT;
    U16 ao_channel = P9527_AO_CH_DUAL;
    U32 ao_chnl_cnt = CHANNEL_COUNT;
    U16 ao_range = AD_B_1_V;
    U16 ao_cfg = P9527_AO_PseudoDifferential;
    BOOLEAN ao_buffer_set = FALSE;
    U32 ao_buffer_cnt = ao_write_cnt * ao_chnl_cnt;
    U32 *ao_raw_buffer[2] = {0,};
    U16 ao_buffer_id[2];
    F64 *ao_scale_buffer[2] = {0,};
    BOOLEAN ao_acq_start = FALSE;
    U32 ao_access_cnt = 0;

    printf("This example performs AI & AO operation simultaneously.\n");
    printf("Press 'Enter' to continue...");
    getchar();

    printf("\nInitializing device... ");

    // Step 1. Register Devices
    status = DSA_Register_Card(PCI_9527, 0);
    if (status < 0)
    {
        printf("Failed to perform DSA_Register_Card(), status: %d\n", status);
        goto _exit;
    }
    card = (I16)status;

    printf("Done\n");

    printf("Configuring device... ");

    // Step 2. Configure AIO Sample Clock
    status = DSA_ConfigSpeedRate(card, clk_conf, clk_source, clk_sample_rate, &clk_actual_rate);
    if (status != NoError && status != ErrorFrequencyLocked)
    {
        printf("Failed to perform DSA_ConfigSpeedRate(), status: %d\n", status);
        goto _exit_wReleaseCard;
    }

    // Step 3. Configure AIO Channel
    // AI Channel
    status = DSA_AI_9527_ConfigChannel(card, ai_channel, ai_range, ai_cfg, 0);
    if (status != NoError)
    {
        printf("Failed to perform DSA_AI_9527_ConfigChannel(), status: %d\n", status);
        goto _exit_wReleaseCard;
    }
    // AO Channel
    status = DSA_AO_9527_ConfigChannel(card, ao_channel, ao_range, ao_cfg, 0);
    if (status != NoError)
    {
        printf("Failed to perform DSA_AO_9527_ConfigChannel(), status: %d\n", status);
        goto _exit_wReleaseCard;
    }

    // Step 4. Configure AIO Trigger
    status = DSA_TRG_Config(card, trig_target, trig_ctrl, 0, 0);
    if (status != NoError)
    {
        printf("Failed to perform DSA_AI_9527_ConfigChannel(), status: %d\n", status);
        goto _exit_wReleaseCard;
    }

    // Step 5. Configure AIO Buffer Modes
    // Enable Double Buffer Mode to perform Continuous AIO operation
    status = DSA_AI_AsyncDblBufferMode(card, 1);
    if (status != NoError)
    {
        printf("Failed to perform DSA_AI_AsyncDblBufferMode(), status: %d\n", status);
        goto _exit_wReleaseCard;
    }
    status = DSA_AO_AsyncDblBufferMode(card, 1);
    if (status != NoError)
    {
        printf("Failed to perform DSA_AO_AsyncDblBufferMode(), status: %d\n", status);
        goto _exit_wReleaseCard;
    }
    // Allocate Memory
    ai_raw_buffer[0] = (U32 *)malloc(ai_buffer_cnt * sizeof(U32));
    ai_scale_buffer[0] = (F64 *)malloc(ai_buffer_cnt * sizeof(F64));
    ai_raw_buffer[1] = (U32 *)malloc(ai_buffer_cnt * sizeof(U32));
    ai_scale_buffer[1] = (F64 *)malloc(ai_buffer_cnt * sizeof(F64));
    ao_raw_buffer[0] = (U32 *)malloc(ao_buffer_cnt * sizeof(U32));
    ao_scale_buffer[0] = (F64 *)malloc(ao_buffer_cnt * sizeof(F64));
    ao_raw_buffer[1] = (U32 *)malloc(ao_buffer_cnt * sizeof(U32));
    ao_scale_buffer[1] = (F64 *)malloc(ao_buffer_cnt * sizeof(F64));
    memset(ai_raw_buffer[0], 0, ai_buffer_cnt * sizeof(U32));
    memset(ai_raw_buffer[1], 0, ai_buffer_cnt * sizeof(U32));
    memset(ao_raw_buffer[0], 0, ao_buffer_cnt * sizeof(U32));
    memset(ao_raw_buffer[1], 0, ao_buffer_cnt * sizeof(U32));
    // Setup AI Buffer 0
    status = DSA_AI_ContBufferSetup(card, ai_raw_buffer[0], ai_buffer_cnt, &ai_buffer_id[0]);
    if (status != NoError)
    {
        printf("Failed to perform DSA_AI_ContBufferSetup(0), status: %d\n", status);
        goto _exit_wResetBuffer;
    }
    ai_buffer_set = TRUE;
    // Setup AI Buffer 1
    status = DSA_AI_ContBufferSetup(card, ai_raw_buffer[1], ai_buffer_cnt, &ai_buffer_id[1]);
    if (status != NoError)
    {
        printf("Failed to perform DSA_AI_ContBufferSetup(1), status: %d\n", status);
        goto _exit_wResetBuffer;
    }
    // Setup AO Buffer 0
    status = DSA_AO_ContBufferSetup(card, ao_raw_buffer[0], ao_buffer_cnt, &ao_buffer_id[0]);
    if (status != NoError)
    {
        printf("Failed to perform DSA_AO_ContBufferSetup(0), status: %d\n", status);
        goto _exit_wResetBuffer;
    }
    ao_buffer_set = TRUE;
    // Setup AO Buffer 1
    status = DSA_AO_ContBufferSetup(card, ao_raw_buffer[1], ao_buffer_cnt, &ao_buffer_id[1]);
    if (status != NoError)
    {
        printf("Failed to perform DSA_AO_ContBufferSetup(1), status: %d\n", status);
        goto _exit_wResetBuffer;
    }

    printf("Done\n");
    printf("\nPress 'Enter' to start AI & AO operation... ");
    getchar();

    // Step 6. Start AIO Operation
    // Start AI Acquisition
    status = DSA_AI_ContReadChannel(card, ai_channel, 0, &ai_buffer_id[0], ai_buffer_cnt, 0, ASYNCH_OP);
    if (status != NoError)
    {
        printf("Failed to perform DSA_AI_ContReadChannel(), status: %d\n", status);
        goto _exit_wAsyncClear;
    }
    ai_acq_start = TRUE;
    printf("\nAI Acquisition STARTED!");
    // Start AO Update
    status = DSA_AO_ContWriteChannel(card, ao_channel, ao_buffer_id[0], ao_buffer_cnt, 0, 0, 0, ASYNCH_OP);
    if (status != NoError)
    {
        printf("Failed to perform DSA_AO_ContWriteChannel(), status: %d\n", status);
        goto _exit_wAsyncClear;
    }
    ao_acq_start = TRUE;
    printf("\nAO Update STARTED!");

    // Fire Software trigger to trigger AI and AO Operation
    status = DSA_TRG_SoftTriggerGen(card);
    if (status != NoError)
    {
        printf("Failed to perform DSA_TRG_SoftTriggerGen(), status: %d\n", status);
        goto _exit_wAsyncClear;
    }
    printf("\nSoftware Trigger is FIRED!\n\n");

#if defined (CONFIG_SAVE_AI_DATA)
    FILE *fp = fopen("ai_data.csv", "w");
#endif

    // Step 7. Check AIO Operation status
    do {
        // Check Buffer Ready
        status = DSA_AI_AsyncDblBufferHalfReady(card, &ai_half_ready, &ai_stopped);
        if (status != NoError)
        {
            printf("Failed to perform DSA_AI_AsyncDblBufferHalfReady(), status: %d\n", status);
            goto _exit_wAsyncClear;
        }

        if (ai_half_ready)
        {
            ai_half_rdy_cnt ++;
            printf("Buffer Half Ready!!! cnt: %d, idx: %d\r", ai_half_rdy_cnt, ai_buffer_idx);

            // Scale AI raw data to voltage
            DSA_AI_ContVScale(card, ai_range, (void *)ai_raw_buffer[ai_buffer_idx], ai_scale_buffer[ai_buffer_idx], ai_buffer_cnt);

            //
            // *** Process your operation HRER ***
            //
            // We just copy AI data to AO buffer to be updated
            // You can process "ai_scale_buffer[ai_buffer_idx]" and thne put the processed data to "ao_scale_buffer[ai_buffer_idx]"
            memcpy(ao_scale_buffer[ai_buffer_idx], ai_scale_buffer[ai_buffer_idx], ai_buffer_cnt * sizeof(F64));

            // Scale AO voltage to raw data
            for (unsigned vi = 0; vi < ai_buffer_cnt; ++ vi)
            {
                DSA_AO_VoltScale(card, 0, ao_scale_buffer[ai_buffer_idx][vi], (I32 *)&ao_raw_buffer[ai_buffer_idx][vi]);
            }

#if defined (CONFIG_SAVE_AI_DATA)
            for (unsigned int vi = 0; vi < ai_read_cnt; ++ vi)
            {
                for (unsigned int vj = 0; vj < ai_chnl_cnt; ++ vj)
                {
                    fprintf(fp, "%.6f,", ai_scale_buffer[ai_buffer_idx][vi * ai_chnl_cnt + vj]);
                }
                fprintf(fp, "\n");
            }
#endif

            ai_buffer_idx = (ai_buffer_idx == 0)? 1:0;
        }
        Sleep(10);
    } while(!kbhit()); getchar();

#if defined (CONFIG_SAVE_AI_DATA)
    fclose(fp);
#endif

_exit_wAsyncClear:
    // Clear AIO Configurations
    if (ai_acq_start)
    {
        DSA_AI_AsyncClear(card, &ai_access_cnt);
    }
    if (ao_acq_start)
    {
        DSA_AO_AsyncClear(card, &ao_access_cnt, 0);
    }

_exit_wResetBuffer:
    if (ai_buffer_set)
    {
        DSA_AI_ContBufferReset(card);
    }
    if (ao_buffer_set)
    {
        DSA_AO_ContBufferReset(card);
    }
    for (int vi = 0; vi < 2; ++ vi)
    {
        if (ai_raw_buffer[vi])
        {
            free(ai_raw_buffer[vi]);
        }
        if (ai_scale_buffer[vi])
        {
            free(ai_scale_buffer[vi]);
        }
        if (ao_raw_buffer[vi])
        {
            free(ao_raw_buffer[vi]);
        }
        if (ao_scale_buffer[vi])
        {
            free(ao_scale_buffer[vi]);
        }
    }

_exit_wReleaseCard:
    DSA_Release_Card(card);

_exit:
    printf("\n\nPress 'Enter' to exit...");
    getchar();
    return 0;
}
