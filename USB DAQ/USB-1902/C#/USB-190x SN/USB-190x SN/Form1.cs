using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace USB_190x_SN
{
    public partial class Form1 : Form
    {
        int bstate;
        short card;

        [DllImport("USB-Dask64.dll")]
        public static extern short UD_Custom_Serial_Number_Read(uint wCardNumber, byte[] pSerialNum);
        [DllImport("USB-Dask64.dll")]
        public static extern short UD_Custom_Serial_Number_Write(uint wCardNumber, string pSerialNum);


        public Form1()
        {
            InitializeComponent();
        }

        private void RB_ADLINK_SN_CheckedChanged(object sender, EventArgs e)
        {
            bstate = 0;
        }

        private void RB_CUSTOMER_SN_CheckedChanged(object sender, EventArgs e)
        {
            bstate = 1;
        }

        private void BT_WriteSN_Click(object sender, EventArgs e)
        {
            if(TXT_SNWRITE.Text == "")
            {
                MessageBox.Show("Please enter the Serial number");
                return;
            }
                
            if(TXT_SNWRITE.Text.Length>16)
            {
                MessageBox.Show("The length of serial number is too long to write");
                return;
            }

            short err = -1;

            if (bstate == 0)
            {
                err= UD_Serial_Number_Write((uint)card, TXT_SNWRITE.Text);
                if (err < 0)
                    MessageBox.Show("Fail");
            }
            else
            {
                err = UD_Custom_Serial_Number_Write((uint)card, TXT_SNWRITE.Text);
                if (err < 0)
                    MessageBox.Show("Fail");
            }          
        }

        private void BT_ReadSN_Click(object sender, EventArgs e)
        {
            byte [] sn = new byte[16];
            short err = -1;

            if (bstate == 0)
            {
                err = UD_Serial_Number_Read((uint)card, sn);
                if (err < 0)
                {
                    MessageBox.Show("Fail");
                }
                else
                {
                    TXT_SNREAD.Text = System.Text.Encoding.ASCII.GetString(sn);
                }                    
            }
            else
            {
                err = UD_Custom_Serial_Number_Read((uint)card, sn);
                if (err < 0)
                {
                    MessageBox.Show("Fail");
                }
                else
                    TXT_SNREAD.Text = System.Text.Encoding.ASCII.GetString(sn);
            }
        }

        private void BT_REGISTER_Click(object sender, EventArgs e)
        {            
            ushort card_num = Convert.ToUInt16(TXT_CARDNUM.Text);
            card = USBDASK.UD_Register_Card(USBDASK.USB_1902, card_num);
            if (card < 0)
            {
                MessageBox.Show("Register Card fail, " + card.ToString());
            }
            else
            {
                BT_RELEASE.Enabled = true;
                BT_REGISTER.Enabled = false;
            }                
        }

        private void BT_RELEASE_Click(object sender, EventArgs e)
        {
            short err = USBDASK.UD_Release_Card((ushort)card);
            if(err<0)
            {
                MessageBox.Show("Release Card Fail");
            }

            BT_REGISTER.Enabled = true;
            BT_RELEASE.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BT_REGISTER.Enabled = true;
            BT_RELEASE.Enabled = false;
            bstate = 1;
        }
    }
}
