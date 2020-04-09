namespace USB_190x_SN
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TXT_SNWRITE = new System.Windows.Forms.TextBox();
            this.TXT_SNREAD = new System.Windows.Forms.TextBox();
            this.BT_WriteSN = new System.Windows.Forms.Button();
            this.BT_ReadSN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TXT_CARDNUM = new System.Windows.Forms.TextBox();
            this.BT_REGISTER = new System.Windows.Forms.Button();
            this.BT_RELEASE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TXT_SNWRITE
            // 
            this.TXT_SNWRITE.Location = new System.Drawing.Point(31, 82);
            this.TXT_SNWRITE.MaxLength = 16;
            this.TXT_SNWRITE.Name = "TXT_SNWRITE";
            this.TXT_SNWRITE.Size = new System.Drawing.Size(205, 25);
            this.TXT_SNWRITE.TabIndex = 0;
            // 
            // TXT_SNREAD
            // 
            this.TXT_SNREAD.Location = new System.Drawing.Point(31, 125);
            this.TXT_SNREAD.MaxLength = 16;
            this.TXT_SNREAD.Name = "TXT_SNREAD";
            this.TXT_SNREAD.ReadOnly = true;
            this.TXT_SNREAD.Size = new System.Drawing.Size(202, 25);
            this.TXT_SNREAD.TabIndex = 1;
            // 
            // BT_WriteSN
            // 
            this.BT_WriteSN.Location = new System.Drawing.Point(258, 83);
            this.BT_WriteSN.Name = "BT_WriteSN";
            this.BT_WriteSN.Size = new System.Drawing.Size(78, 23);
            this.BT_WriteSN.TabIndex = 2;
            this.BT_WriteSN.Text = "Write SN";
            this.BT_WriteSN.UseVisualStyleBackColor = true;
            this.BT_WriteSN.Click += new System.EventHandler(this.BT_WriteSN_Click);
            // 
            // BT_ReadSN
            // 
            this.BT_ReadSN.Location = new System.Drawing.Point(258, 125);
            this.BT_ReadSN.Name = "BT_ReadSN";
            this.BT_ReadSN.Size = new System.Drawing.Size(78, 23);
            this.BT_ReadSN.TabIndex = 3;
            this.BT_ReadSN.Text = "Read SN";
            this.BT_ReadSN.UseVisualStyleBackColor = true;
            this.BT_ReadSN.Click += new System.EventHandler(this.BT_ReadSN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Card Number:";
            // 
            // TXT_CARDNUM
            // 
            this.TXT_CARDNUM.Location = new System.Drawing.Point(132, 18);
            this.TXT_CARDNUM.MaxLength = 2;
            this.TXT_CARDNUM.Name = "TXT_CARDNUM";
            this.TXT_CARDNUM.Size = new System.Drawing.Size(54, 25);
            this.TXT_CARDNUM.TabIndex = 7;
            this.TXT_CARDNUM.Text = "0";
            // 
            // BT_REGISTER
            // 
            this.BT_REGISTER.Location = new System.Drawing.Point(209, 13);
            this.BT_REGISTER.Name = "BT_REGISTER";
            this.BT_REGISTER.Size = new System.Drawing.Size(63, 39);
            this.BT_REGISTER.TabIndex = 8;
            this.BT_REGISTER.Text = "Register Card";
            this.BT_REGISTER.UseVisualStyleBackColor = true;
            this.BT_REGISTER.Click += new System.EventHandler(this.BT_REGISTER_Click);
            // 
            // BT_RELEASE
            // 
            this.BT_RELEASE.Location = new System.Drawing.Point(278, 13);
            this.BT_RELEASE.Name = "BT_RELEASE";
            this.BT_RELEASE.Size = new System.Drawing.Size(63, 39);
            this.BT_RELEASE.TabIndex = 9;
            this.BT_RELEASE.Text = "Release Card";
            this.BT_RELEASE.UseVisualStyleBackColor = true;
            this.BT_RELEASE.Click += new System.EventHandler(this.BT_RELEASE_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 164);
            this.Controls.Add(this.BT_RELEASE);
            this.Controls.Add(this.BT_REGISTER);
            this.Controls.Add(this.TXT_CARDNUM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_ReadSN);
            this.Controls.Add(this.BT_WriteSN);
            this.Controls.Add(this.TXT_SNREAD);
            this.Controls.Add(this.TXT_SNWRITE);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXT_SNWRITE;
        private System.Windows.Forms.TextBox TXT_SNREAD;
        private System.Windows.Forms.Button BT_WriteSN;
        private System.Windows.Forms.Button BT_ReadSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXT_CARDNUM;
        private System.Windows.Forms.Button BT_REGISTER;
        private System.Windows.Forms.Button BT_RELEASE;
    }
}

