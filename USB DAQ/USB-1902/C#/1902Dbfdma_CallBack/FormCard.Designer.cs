namespace _902dma
{
    partial class FormCard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton_1901 = new System.Windows.Forms.RadioButton();
            this.radioButton_1902 = new System.Windows.Forms.RadioButton();
            this.radioButton_1903 = new System.Windows.Forms.RadioButton();
            this.comboBox_CardID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_CANCEL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButton_1901
            // 
            this.radioButton_1901.AutoSize = true;
            this.radioButton_1901.Enabled = false;
            this.radioButton_1901.Location = new System.Drawing.Point(8, 17);
            this.radioButton_1901.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton_1901.Name = "radioButton_1901";
            this.radioButton_1901.Size = new System.Drawing.Size(82, 19);
            this.radioButton_1901.TabIndex = 0;
            this.radioButton_1901.TabStop = true;
            this.radioButton_1901.Text = "USB-1901";
            this.radioButton_1901.UseVisualStyleBackColor = true;
            this.radioButton_1901.CheckedChanged += new System.EventHandler(this.radioButton_1901_CheckedChanged);
            // 
            // radioButton_1902
            // 
            this.radioButton_1902.AutoSize = true;
            this.radioButton_1902.Enabled = false;
            this.radioButton_1902.Location = new System.Drawing.Point(109, 17);
            this.radioButton_1902.Name = "radioButton_1902";
            this.radioButton_1902.Size = new System.Drawing.Size(82, 19);
            this.radioButton_1902.TabIndex = 1;
            this.radioButton_1902.TabStop = true;
            this.radioButton_1902.Text = "USB-1902";
            this.radioButton_1902.UseVisualStyleBackColor = true;
            this.radioButton_1902.CheckedChanged += new System.EventHandler(this.radioButton_1902_CheckedChanged);
            // 
            // radioButton_1903
            // 
            this.radioButton_1903.AutoSize = true;
            this.radioButton_1903.Enabled = false;
            this.radioButton_1903.Location = new System.Drawing.Point(210, 17);
            this.radioButton_1903.Name = "radioButton_1903";
            this.radioButton_1903.Size = new System.Drawing.Size(82, 19);
            this.radioButton_1903.TabIndex = 2;
            this.radioButton_1903.TabStop = true;
            this.radioButton_1903.Text = "USB-1903";
            this.radioButton_1903.UseVisualStyleBackColor = true;
            this.radioButton_1903.CheckedChanged += new System.EventHandler(this.radioButton_1903_CheckedChanged);
            // 
            // comboBox_CardID
            // 
            this.comboBox_CardID.FormattingEnabled = true;
            this.comboBox_CardID.Location = new System.Drawing.Point(125, 49);
            this.comboBox_CardID.Name = "comboBox_CardID";
            this.comboBox_CardID.Size = new System.Drawing.Size(115, 23);
            this.comboBox_CardID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Module ID:";
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Enabled = false;
            this.button_OK.Location = new System.Drawing.Point(50, 85);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(85, 28);
            this.button_OK.TabIndex = 5;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_CANCEL
            // 
            this.button_CANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_CANCEL.Location = new System.Drawing.Point(151, 85);
            this.button_CANCEL.Name = "button_CANCEL";
            this.button_CANCEL.Size = new System.Drawing.Size(85, 28);
            this.button_CANCEL.TabIndex = 6;
            this.button_CANCEL.Text = "CANCEL";
            this.button_CANCEL.UseVisualStyleBackColor = true;
            // 
            // FormCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 136);
            this.Controls.Add(this.button_CANCEL);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_CardID);
            this.Controls.Add(this.radioButton_1903);
            this.Controls.Add(this.radioButton_1902);
            this.Controls.Add(this.radioButton_1901);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCard";
            this.Load += new System.EventHandler(this.FormCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_1901;
        private System.Windows.Forms.RadioButton radioButton_1902;
        private System.Windows.Forms.RadioButton radioButton_1903;
        private System.Windows.Forms.ComboBox comboBox_CardID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_CANCEL;
    }
}