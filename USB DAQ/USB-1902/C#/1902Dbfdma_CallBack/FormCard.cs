using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _902dma
{
    public partial class FormCard : Form
    {
        ushort wModuleNum;
        ushort wSelModuleID;
        ushort wSelCardType;

        byte[] AvialableCardType = new byte[4];  // empty, usb-1902, usb-1903 and usb-1901
        ushort[] CardID = new ushort[USBDASK.MAX_USB_DEVICE];
        USBDAQ_DEVICE[] AvailModules = new USBDAQ_DEVICE[USBDASK.MAX_USB_DEVICE];

        public FormCard()
        {
            int vi;

            InitializeComponent();
            wSelModuleID = USBDASK.INVALID_CARD_ID;

            wSelCardType = USBDASK.USB_1902; // default Module-Type

            for (vi = 0; vi < USBDASK.MAX_USB_DEVICE; vi++)
                CardID[vi] =USBDASK.INVALID_CARD_ID;

            for (vi = 0; vi < 4; vi++)
                AvialableCardType[vi] = 0x00;
        }
        private void UpdateComboBox()
        {
            int i, vi;

            // TODO:  Add extra initialization here
            comboBox_CardID.Items.Clear();

            for (i = 0, vi = 0; i < wModuleNum; i++)
            {
                if (AvailModules[i].wModuleType == wSelCardType)
                {
                    CardID[vi] = AvailModules[i].wCardID;
                    comboBox_CardID.Items.Add(CardID[vi].ToString());
                    vi++;
                }
            }

            wSelModuleID = CardID[0];
            comboBox_CardID.SelectedIndex = 0;
        }
        private void FormCard_Load(object sender, EventArgs e)
        {
            short err;
            int i;

            // scan the active USB DASK module
            err = USBDASK.UD_Device_Scan(out wModuleNum, AvailModules);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_Device_Scan() Failed !!, Error Code:" + err.ToString());
                return;
            }

            for (i = 0; i < wModuleNum; i++)
            {
                switch (AvailModules[i].wModuleType)
                {
                    case USBDASK.USB_1902:
                        if (AvialableCardType[USBDASK.USB_1902] == 0x00)
                        {
                            AvialableCardType[USBDASK.USB_1902] = 0x01;
                            radioButton_1902.Enabled = true;
                        }
                        break;

                    case USBDASK.USB_1903:
                        if (AvialableCardType[USBDASK.USB_1903] == 0x00)
                        {
                            AvialableCardType[USBDASK.USB_1903] = 0x01;
                            radioButton_1903.Enabled = true;
                        }
                        break;

                    case USBDASK.USB_1901:
                        if (AvialableCardType[USBDASK.USB_1901] == 0x00)
                        {
                            AvialableCardType[USBDASK.USB_1901] = 0x01;
                            radioButton_1901.Enabled = true;
                        }
                        break;

                }

            }

            // re-assign the wSelCardType
            if (AvialableCardType[USBDASK.USB_1902] == 0x01)
            {
                wSelCardType = USBDASK.USB_1902;
                radioButton_1902.Checked = true;

                button_OK.Enabled = true;
                // UpdateComboBox();
            }
            else if (AvialableCardType[USBDASK.USB_1903] == 0x01)
            {
                wSelCardType = USBDASK.USB_1903;
                radioButton_1903.Checked = true;

                button_OK.Enabled = true;
                // UpdateComboBox();
            }
            else if (AvialableCardType[USBDASK.USB_1901] == 0x01)
            {
                wSelCardType = USBDASK.USB_1901;
                radioButton_1901.Checked = true;

                button_OK.Enabled = true;
                //UpdateComboBox();
            }

        }

        private void radioButton_1901_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_1901.Checked == true)
            {
                wSelCardType = USBDASK.USB_1901;
                UpdateComboBox();
            }
        }

        private void radioButton_1902_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_1902.Checked == true)
            {
                wSelCardType = USBDASK.USB_1902;
                UpdateComboBox();
            }
        }

        private void radioButton_1903_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_1903.Checked == true)
            {
                wSelCardType = USBDASK.USB_1903;
                UpdateComboBox();
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            int nCurSel;

            nCurSel = comboBox_CardID.SelectedIndex;
            wSelModuleID = CardID[nCurSel];
        }

        public ushort GetCardType()
        {
            return wSelCardType;
        }

        public ushort GetCardID()
        {
            return wSelModuleID;
        }

    }
}