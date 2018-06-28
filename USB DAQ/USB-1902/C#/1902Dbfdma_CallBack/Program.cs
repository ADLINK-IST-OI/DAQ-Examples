using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _902dma
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DialogResult dr = new DialogResult();

            FormCard CardForm = new FormCard();
            dr = CardForm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ushort wCardType, wCardID;

                wCardType = CardForm.GetCardType();
                wCardID = CardForm.GetCardID();

                Form1 AppForm = new Form1();
                AppForm.SetModuleType(wCardType);
                AppForm.SetModuleID(wCardID);
                Application.Run(AppForm);
            }
        }
    }
}