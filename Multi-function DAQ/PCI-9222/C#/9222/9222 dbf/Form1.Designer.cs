namespace _9112_polling
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.zedGraphtime = new ZedGraph.ZedGraphControl();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxOverrun = new System.Windows.Forms.TextBox();
            this.labeloverrun = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxQueueCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(824, 29);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(171, 62);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // zedGraphtime
            // 
            this.zedGraphtime.Location = new System.Drawing.Point(45, 12);
            this.zedGraphtime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.zedGraphtime.Name = "zedGraphtime";
            this.zedGraphtime.ScrollGrace = 0D;
            this.zedGraphtime.ScrollMaxX = 0D;
            this.zedGraphtime.ScrollMaxY = 0D;
            this.zedGraphtime.ScrollMaxY2 = 0D;
            this.zedGraphtime.ScrollMinX = 0D;
            this.zedGraphtime.ScrollMinY = 0D;
            this.zedGraphtime.ScrollMinY2 = 0D;
            this.zedGraphtime.Size = new System.Drawing.Size(749, 464);
            this.zedGraphtime.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(824, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 64);
            this.button1.TabIndex = 4;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxOverrun
            // 
            this.textBoxOverrun.Location = new System.Drawing.Point(824, 373);
            this.textBoxOverrun.Name = "textBoxOverrun";
            this.textBoxOverrun.Size = new System.Drawing.Size(123, 25);
            this.textBoxOverrun.TabIndex = 5;
            // 
            // labeloverrun
            // 
            this.labeloverrun.AutoSize = true;
            this.labeloverrun.Location = new System.Drawing.Point(821, 346);
            this.labeloverrun.Name = "labeloverrun";
            this.labeloverrun.Size = new System.Drawing.Size(54, 15);
            this.labeloverrun.TabIndex = 6;
            this.labeloverrun.Text = "Overrun";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(821, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Queue Count";
            // 
            // textBoxQueueCount
            // 
            this.textBoxQueueCount.Location = new System.Drawing.Point(824, 451);
            this.textBoxQueueCount.Name = "textBoxQueueCount";
            this.textBoxQueueCount.Size = new System.Drawing.Size(123, 25);
            this.textBoxQueueCount.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 506);
            this.Controls.Add(this.textBoxQueueCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labeloverrun);
            this.Controls.Add(this.textBoxOverrun);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zedGraphtime);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "9222";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private ZedGraph.ZedGraphControl zedGraphtime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxOverrun;
        private System.Windows.Forms.Label labeloverrun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxQueueCount;
    }
}

