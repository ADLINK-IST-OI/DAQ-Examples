namespace _902dma
{
    partial class Form1
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
            this.pbxDisplay = new System.Windows.Forms.PictureBox();
            this.tbxYup = new System.Windows.Forms.TextBox();
            this.tbxYdown = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.textYZero = new System.Windows.Forms.TextBox();
            this.textBox_CardID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxDisplay
            // 
            this.pbxDisplay.Location = new System.Drawing.Point(155, 22);
            this.pbxDisplay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbxDisplay.Name = "pbxDisplay";
            this.pbxDisplay.Size = new System.Drawing.Size(600, 390);
            this.pbxDisplay.TabIndex = 0;
            this.pbxDisplay.TabStop = false;
            // 
            // tbxYup
            // 
            this.tbxYup.BackColor = System.Drawing.SystemColors.Control;
            this.tbxYup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxYup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxYup.Location = new System.Drawing.Point(29, 11);
            this.tbxYup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxYup.Name = "tbxYup";
            this.tbxYup.Size = new System.Drawing.Size(120, 14);
            this.tbxYup.TabIndex = 1;
            this.tbxYup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxYdown
            // 
            this.tbxYdown.BackColor = System.Drawing.SystemColors.Control;
            this.tbxYdown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxYdown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxYdown.Location = new System.Drawing.Point(29, 408);
            this.tbxYdown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxYdown.Name = "tbxYdown";
            this.tbxYdown.Size = new System.Drawing.Size(120, 14);
            this.tbxYdown.TabIndex = 2;
            this.tbxYdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(443, 471);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Module ID:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(643, 439);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 29);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(513, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Range: +-10V";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(643, 473);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 29);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // textYZero
            // 
            this.textYZero.BackColor = System.Drawing.SystemColors.Control;
            this.textYZero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textYZero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textYZero.Location = new System.Drawing.Point(29, 209);
            this.textYZero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textYZero.Name = "textYZero";
            this.textYZero.Size = new System.Drawing.Size(120, 14);
            this.textYZero.TabIndex = 17;
            this.textYZero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_CardID
            // 
            this.textBox_CardID.Location = new System.Drawing.Point(519, 468);
            this.textBox_CardID.Name = "textBox_CardID";
            this.textBox_CardID.ReadOnly = true;
            this.textBox_CardID.Size = new System.Drawing.Size(72, 21);
            this.textBox_CardID.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 517);
            this.Controls.Add(this.textBox_CardID);
            this.Controls.Add(this.textYZero);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxYdown);
            this.Controls.Add(this.tbxYup);
            this.Controls.Add(this.pbxDisplay);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxDisplay;
        private System.Windows.Forms.TextBox tbxYup;
        private System.Windows.Forms.TextBox tbxYdown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox textYZero;
        private System.Windows.Forms.TextBox textBox_CardID;
    }
}

