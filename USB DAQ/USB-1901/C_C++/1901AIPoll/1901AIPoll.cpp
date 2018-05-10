#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <math.h>
#include <process.h>
#include "usbdask.h"

// Device
I16 w_error;
U16 w_card_type = USB_1901;
U16 w_card_num = 0;
U16 w_card_handle = 0xffff;
U16 w_inpit_type = 0;
U16 w_inpit_range = 0;
U16 w_max_channel_cnt = 16;
U16 w_num_channel = 1;
U32 dw_acq_interval = 1;
bool f_save_file = false;
char sz_file_name[MAX_PATH] = {0, };
FILE *fp_save_file = NULL;

// Thread
bool f_thr_stop = false;
HANDLE h_timer = NULL;
DWORD dw_timer_elapsed = dw_acq_interval * 1000;
int n_cnt = 0;

void ai_poll(void *p_arg)
{
    U16 wNumChans = w_num_channel;
    U16 pwChans[16];
    U16 pwAdRanges[16];
    U16 pwBuffer[16];
    for (U16 vi = 0; vi < wNumChans && vi < 16; ++ vi)
    {
        pwChans[vi] = vi;
        switch(w_inpit_range)
        {
            case 0:
                pwAdRanges[vi] = AD_B_10_V;
                break;
            case 1:
                pwAdRanges[vi] = AD_B_2_V;
                break;
            case 2:
                pwAdRanges[vi] = AD_B_1_V;
                break;
            case 3:
                pwAdRanges[vi] = AD_B_0_2_V;
                break;
            default:
                pwAdRanges[vi] = AD_B_10_V;
                break;
        }
        pwBuffer[vi] = 0;
    }

    char sz_time_start[MAX_PATH];
    dw_timer_elapsed = dw_acq_interval * 1000;
    do
    {
        SYSTEMTIME _stime;
        GetLocalTime(&_stime);

        if (n_cnt == 0)
        {
            sprintf(sz_time_start, "%02d/%02d/%02d %02d:%02d:%02d", _stime.wYear, _stime.wMonth, _stime.wDay, _stime.wHour, _stime.wMinute, _stime.wSecond);
        }
        char sz_time_stamp[MAX_PATH];
        sprintf(sz_time_stamp, "%02d/%02d/%02d %02d:%02d:%02d", _stime.wYear, _stime.wMonth, _stime.wDay, _stime.wHour, _stime.wMinute, _stime.wSecond);

        I16 w_error = UD_AI_ReadMultiChannels(w_card_handle, wNumChans, pwChans, pwAdRanges, pwBuffer);
        n_cnt ++;

        system("cls");
        printf("**************************************************\n");

        printf("The start acquisition time: %s\n", sz_time_start);
        printf("The latest acquisition time: %s\n\n", sz_time_stamp);

        if (w_error != NoError)
        {
            printf("Failed to perform UD_AI_ReadMultiChannels(), status: %d\n", w_error);
        }
        else
        {
            F64 pdfVoltageArray[16];
            UD_AI_ContVScale(w_card_handle, pwAdRanges[0], (void *)pwBuffer, pdfVoltageArray, (I32)wNumChans);
            for (U16 vi = 0; vi < wNumChans; ++ vi)
            {
                printf("CH%02d: %+.4f (0x%x)\n", pwChans[vi], pdfVoltageArray[vi], pwBuffer[vi]);
                if (f_save_file && fp_save_file)
                {
                    if (vi == 0)
                    {
                        fprintf(fp_save_file, "%s", sz_time_stamp);
                    }
                    fprintf(fp_save_file, ",%.8f", pdfVoltageArray[vi]);
                    if (vi == wNumChans - 1)
                    {
                        fprintf(fp_save_file, "\n");
                    }
                    fflush(fp_save_file);
                }
            }
        }

        printf("\n\t\tYou can press 'Enter' to stop...\n");
        printf("**************************************************");

        if (NULL != h_timer)
        {
            DWORD result = WaitForSingleObject(h_timer, dw_timer_elapsed);
            if (result != WAIT_TIMEOUT)
            {
                if (result != WAIT_OBJECT_0)
                {
                    printf("\n\nFailed to perform WaitForSingleObject(), status: %d", result);
                }
                break;
            }
        }
    } while (f_thr_stop == false);
}

int main()
{
    printf("This example performs USB-1901 AI channel acquisition by polling.\n");
    printf("Press 'Enter' to continue...");
    getchar();

    printf("\nCard number? (0 ~ 7): ");
    scanf(" %hd", &w_card_num); getchar();
    w_card_num = (w_card_num > 7)? 0:w_card_num;

    printf("Input type? (0) SE, (1) NRSE, (2) DIFF: ");
    scanf(" %hd", &w_inpit_type); getchar();
    w_inpit_type = (w_inpit_type > 2)? 0:w_inpit_type;
    w_max_channel_cnt = (w_inpit_type == 2)? 8:16;

    printf("Input range? (0) +-10V, (1) +-2V, (2) +-1V, (3) +-200mV: ");
    scanf(" %hd", &w_inpit_range); getchar();
    w_inpit_range = (w_inpit_range > 3)? 0:w_inpit_range;

    printf("Number of AI channels? (1 ~ %d): ", w_max_channel_cnt);
    scanf(" %hd", &w_num_channel); getchar();
    w_num_channel = (w_num_channel == 0 || w_num_channel > w_max_channel_cnt)? w_max_channel_cnt:w_num_channel;

    printf("Acquisition interval (in seconds)? (1 ~ ): ");
    scanf(" %d", &dw_acq_interval); getchar();
    dw_acq_interval = (dw_acq_interval == 0)? 1:dw_acq_interval;

    printf("Save data to file? (Y)es or (N)o: ");
    char b_tmp_save_file;
    scanf(" %c", &b_tmp_save_file); getchar();
    if (b_tmp_save_file == 'Y' || b_tmp_save_file == 'y')
    {
        f_save_file = true;
        printf("File name: ");
        scanf(" %s", sz_file_name); getchar();
    }

    // Open device
    w_error = UD_Register_Card(w_card_type, w_card_num);
    if (w_error < 0)
    {
        printf("\nFailed to perform UD_Register_Card(), status: %d\n", w_error);
        goto _exit;
    }
    w_card_handle = (U16)w_error;

    // Configure AI
    U16 wConfigCtrl;
    switch (w_inpit_type)
    {
        case 0:
            wConfigCtrl = P1902_AI_SingEnded;
            break;
        case 1:
            wConfigCtrl = P1902_AI_NonRef_SingEnded;
            break;
        case 2:
            wConfigCtrl = P1902_AI_Differential;
            break;
        default:
            wConfigCtrl = P1902_AI_SingEnded;
    }
    w_error = UD_AI_1902_Config(w_card_handle, wConfigCtrl, 0, 0, 0, 0);
    if (w_error != NoError)
    {
        printf("\nFailed to perform UD_AI_1902_Config(), status: %d\n", w_error);
        goto _exit_wRelease;
    }

    // Open file
    if (f_save_file)
    {
        fp_save_file = fopen(sz_file_name, "w");
        if (fp_save_file)
        {
            fprintf(fp_save_file, "Time Stamp");
            for (U16 vi = 0; vi < w_num_channel; ++ vi)
            {
                fprintf(fp_save_file, ",Channel %d", vi);
            }
            fprintf(fp_save_file, "\n");
            fflush(fp_save_file);
        }
    }

    printf("\nPress 'Enter' to start...");
    getchar();

    // Create thread to read AI periodically
    h_timer = CreateEvent(NULL, TRUE, FALSE, "1901aipoll");
    _beginthread(ai_poll, 0, NULL);
    getchar();

    // Stop thread
    f_thr_stop = true;
    if (NULL != h_timer)
    {
        SetEvent(h_timer);
        CloseHandle(h_timer);
        h_timer = NULL;
    }

_exit_wCloseFile:
    if (fp_save_file)
    {
        fclose(fp_save_file);
    }

_exit_wRelease:
    // Close device
    if (w_card_handle != 0xffff)
    {
        UD_Release_Card(w_card_handle);
    }

_exit:
    printf("\nPress 'Enter' to exit...");
    getchar();
    return 0;
}
