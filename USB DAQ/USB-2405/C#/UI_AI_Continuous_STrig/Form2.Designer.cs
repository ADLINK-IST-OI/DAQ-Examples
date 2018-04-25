namespace AIO_Simultaneous_UI
{
    partial class frm_logger
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
            this.cbox_data_logger_enabled = new System.Windows.Forms.CheckBox();
            this.lb_data_logger_path = new System.Windows.Forms.Label();
            this.lb_data_logger_seconds = new System.Windows.Forms.Label();
            this.btn_data_logger_start = new System.Windows.Forms.Button();
            this.tbox_data_logger_path = new System.Windows.Forms.TextBox();
            this.tbox_data_logger_seconds = new System.Windows.Forms.TextBox();
            this.pbar_data_logger_progress = new System.Windows.Forms.ProgressBar();
            this.btn_data_logger_advanced = new System.Windows.Forms.Button();
            this.gbox_data_converter = new System.Windows.Forms.GroupBox();
            this.btn_data_converter_folder = new System.Windows.Forms.Button();
            this.btn_data_converter_destination = new System.Windows.Forms.Button();
            this.btn_data_converter_source = new System.Windows.Forms.Button();
            this.btn_data_converter_start = new System.Windows.Forms.Button();
            this.lb_data_converter_destination = new System.Windows.Forms.Label();
            this.lb_data_converter_source = new System.Windows.Forms.Label();
            this.tbox_data_converter_destination = new System.Windows.Forms.TextBox();
            this.tbox_data_converter_source = new System.Windows.Forms.TextBox();
            this.btn_data_logger_path = new System.Windows.Forms.Button();
            this.cbox_data_converter_unit = new System.Windows.Forms.ComboBox();
            this.lb_data_converter_unit = new System.Windows.Forms.Label();
            this.gbox_data_converter.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbox_data_logger_enabled
            // 
            this.cbox_data_logger_enabled.AutoSize = true;
            this.cbox_data_logger_enabled.Location = new System.Drawing.Point(256, 64);
            this.cbox_data_logger_enabled.Name = "cbox_data_logger_enabled";
            this.cbox_data_logger_enabled.Size = new System.Drawing.Size(136, 19);
            this.cbox_data_logger_enabled.TabIndex = 3;
            this.cbox_data_logger_enabled.Text = "Enable Data Logging";
            this.cbox_data_logger_enabled.UseVisualStyleBackColor = true;
            this.cbox_data_logger_enabled.CheckedChanged += new System.EventHandler(this.cbox_data_logger_enabled_CheckedChanged);
            // 
            // lb_data_logger_path
            // 
            this.lb_data_logger_path.AutoSize = true;
            this.lb_data_logger_path.Location = new System.Drawing.Point(24, 24);
            this.lb_data_logger_path.Name = "lb_data_logger_path";
            this.lb_data_logger_path.Size = new System.Drawing.Size(105, 15);
            this.lb_data_logger_path.TabIndex = 0;
            this.lb_data_logger_path.Text = "Data Logging Path";
            this.lb_data_logger_path.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_data_logger_seconds
            // 
            this.lb_data_logger_seconds.AutoSize = true;
            this.lb_data_logger_seconds.Location = new System.Drawing.Point(24, 64);
            this.lb_data_logger_seconds.Name = "lb_data_logger_seconds";
            this.lb_data_logger_seconds.Size = new System.Drawing.Size(123, 15);
            this.lb_data_logger_seconds.TabIndex = 1;
            this.lb_data_logger_seconds.Text = "Data Logging Time (s)";
            this.lb_data_logger_seconds.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // btn_data_logger_start
            // 
            this.btn_data_logger_start.Enabled = false;
            this.btn_data_logger_start.Location = new System.Drawing.Point(406, 64);
            this.btn_data_logger_start.Name = "btn_data_logger_start";
            this.btn_data_logger_start.Size = new System.Drawing.Size(112, 32);
            this.btn_data_logger_start.TabIndex = 6;
            this.btn_data_logger_start.Text = "Start Logging";
            this.btn_data_logger_start.UseVisualStyleBackColor = true;
            this.btn_data_logger_start.Click += new System.EventHandler(this.btn_data_logger_start_Click);
            // 
            // tbox_data_logger_path
            // 
            this.tbox_data_logger_path.Enabled = false;
            this.tbox_data_logger_path.Location = new System.Drawing.Point(154, 21);
            this.tbox_data_logger_path.Name = "tbox_data_logger_path";
            this.tbox_data_logger_path.Size = new System.Drawing.Size(339, 23);
            this.tbox_data_logger_path.TabIndex = 4;
            this.tbox_data_logger_path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_data_logger_path_KeyDown);
            this.tbox_data_logger_path.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_data_logger_path_Validating);
            // 
            // tbox_data_logger_seconds
            // 
            this.tbox_data_logger_seconds.Enabled = false;
            this.tbox_data_logger_seconds.Location = new System.Drawing.Point(154, 61);
            this.tbox_data_logger_seconds.Name = "tbox_data_logger_seconds";
            this.tbox_data_logger_seconds.Size = new System.Drawing.Size(80, 23);
            this.tbox_data_logger_seconds.TabIndex = 5;
            this.tbox_data_logger_seconds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_data_logger_seconds_KeyDown);
            this.tbox_data_logger_seconds.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_data_logger_seconds_Validating);
            // 
            // pbar_data_logger_progress
            // 
            this.pbar_data_logger_progress.Location = new System.Drawing.Point(27, 113);
            this.pbar_data_logger_progress.Name = "pbar_data_logger_progress";
            this.pbar_data_logger_progress.Size = new System.Drawing.Size(368, 23);
            this.pbar_data_logger_progress.TabIndex = 2;
            // 
            // btn_data_logger_advanced
            // 
            this.btn_data_logger_advanced.Location = new System.Drawing.Point(406, 104);
            this.btn_data_logger_advanced.Name = "btn_data_logger_advanced";
            this.btn_data_logger_advanced.Size = new System.Drawing.Size(112, 32);
            this.btn_data_logger_advanced.TabIndex = 7;
            this.btn_data_logger_advanced.Text = "Advanced";
            this.btn_data_logger_advanced.UseVisualStyleBackColor = true;
            this.btn_data_logger_advanced.Click += new System.EventHandler(this.btn_data_logger_advanced_Click);
            // 
            // gbox_data_converter
            // 
            this.gbox_data_converter.Controls.Add(this.lb_data_converter_unit);
            this.gbox_data_converter.Controls.Add(this.cbox_data_converter_unit);
            this.gbox_data_converter.Controls.Add(this.btn_data_converter_folder);
            this.gbox_data_converter.Controls.Add(this.btn_data_converter_destination);
            this.gbox_data_converter.Controls.Add(this.btn_data_converter_source);
            this.gbox_data_converter.Controls.Add(this.btn_data_converter_start);
            this.gbox_data_converter.Controls.Add(this.lb_data_converter_destination);
            this.gbox_data_converter.Controls.Add(this.lb_data_converter_source);
            this.gbox_data_converter.Controls.Add(this.tbox_data_converter_destination);
            this.gbox_data_converter.Controls.Add(this.tbox_data_converter_source);
            this.gbox_data_converter.Location = new System.Drawing.Point(24, 154);
            this.gbox_data_converter.Name = "gbox_data_converter";
            this.gbox_data_converter.Size = new System.Drawing.Size(494, 163);
            this.gbox_data_converter.TabIndex = 8;
            this.gbox_data_converter.TabStop = false;
            this.gbox_data_converter.Text = "Data Converter";
            this.gbox_data_converter.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // btn_data_converter_folder
            // 
            this.btn_data_converter_folder.Location = new System.Drawing.Point(364, 112);
            this.btn_data_converter_folder.Name = "btn_data_converter_folder";
            this.btn_data_converter_folder.Size = new System.Drawing.Size(112, 32);
            this.btn_data_converter_folder.TabIndex = 7;
            this.btn_data_converter_folder.Text = "Open Folder";
            this.btn_data_converter_folder.UseVisualStyleBackColor = true;
            this.btn_data_converter_folder.Click += new System.EventHandler(this.btn_data_converter_folder_Click);
            // 
            // btn_data_converter_destination
            // 
            this.btn_data_converter_destination.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_data_converter_destination.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_data_converter_destination.Location = new System.Drawing.Point(451, 72);
            this.btn_data_converter_destination.Name = "btn_data_converter_destination";
            this.btn_data_converter_destination.Size = new System.Drawing.Size(25, 23);
            this.btn_data_converter_destination.TabIndex = 4;
            this.btn_data_converter_destination.Text = "▼";
            this.btn_data_converter_destination.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btn_data_converter_destination.UseVisualStyleBackColor = true;
            this.btn_data_converter_destination.Click += new System.EventHandler(this.btn_data_converter_destination_Click);
            // 
            // btn_data_converter_source
            // 
            this.btn_data_converter_source.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_data_converter_source.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_data_converter_source.Location = new System.Drawing.Point(451, 32);
            this.btn_data_converter_source.Name = "btn_data_converter_source";
            this.btn_data_converter_source.Size = new System.Drawing.Size(25, 23);
            this.btn_data_converter_source.TabIndex = 2;
            this.btn_data_converter_source.Text = "▼";
            this.btn_data_converter_source.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btn_data_converter_source.UseVisualStyleBackColor = true;
            this.btn_data_converter_source.Click += new System.EventHandler(this.btn_data_converter_source_Click);
            // 
            // btn_data_converter_start
            // 
            this.btn_data_converter_start.Location = new System.Drawing.Point(240, 112);
            this.btn_data_converter_start.Name = "btn_data_converter_start";
            this.btn_data_converter_start.Size = new System.Drawing.Size(112, 32);
            this.btn_data_converter_start.TabIndex = 6;
            this.btn_data_converter_start.Text = "Start Conversion";
            this.btn_data_converter_start.UseVisualStyleBackColor = true;
            this.btn_data_converter_start.Click += new System.EventHandler(this.btn_data_converter_start_Click);
            // 
            // lb_data_converter_destination
            // 
            this.lb_data_converter_destination.AutoSize = true;
            this.lb_data_converter_destination.Location = new System.Drawing.Point(24, 76);
            this.lb_data_converter_destination.Name = "lb_data_converter_destination";
            this.lb_data_converter_destination.Size = new System.Drawing.Size(69, 15);
            this.lb_data_converter_destination.TabIndex = 1;
            this.lb_data_converter_destination.Text = "Destination";
            this.lb_data_converter_destination.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_data_converter_source
            // 
            this.lb_data_converter_source.AutoSize = true;
            this.lb_data_converter_source.Location = new System.Drawing.Point(24, 36);
            this.lb_data_converter_source.Name = "lb_data_converter_source";
            this.lb_data_converter_source.Size = new System.Drawing.Size(44, 15);
            this.lb_data_converter_source.TabIndex = 0;
            this.lb_data_converter_source.Text = "Source";
            this.lb_data_converter_source.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_data_converter_destination
            // 
            this.tbox_data_converter_destination.Location = new System.Drawing.Point(105, 72);
            this.tbox_data_converter_destination.Name = "tbox_data_converter_destination";
            this.tbox_data_converter_destination.Size = new System.Drawing.Size(352, 23);
            this.tbox_data_converter_destination.TabIndex = 5;
            this.tbox_data_converter_destination.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_data_converter_destination_KeyDown);
            this.tbox_data_converter_destination.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_data_converter_destination_Validating);
            // 
            // tbox_data_converter_source
            // 
            this.tbox_data_converter_source.Location = new System.Drawing.Point(105, 32);
            this.tbox_data_converter_source.Name = "tbox_data_converter_source";
            this.tbox_data_converter_source.Size = new System.Drawing.Size(352, 23);
            this.tbox_data_converter_source.TabIndex = 3;
            this.tbox_data_converter_source.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_data_converter_source_KeyDown);
            this.tbox_data_converter_source.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_data_converter_source_Validating);
            // 
            // btn_data_logger_path
            // 
            this.btn_data_logger_path.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_data_logger_path.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_data_logger_path.Location = new System.Drawing.Point(493, 21);
            this.btn_data_logger_path.Name = "btn_data_logger_path";
            this.btn_data_logger_path.Size = new System.Drawing.Size(25, 23);
            this.btn_data_logger_path.TabIndex = 9;
            this.btn_data_logger_path.Text = "▼";
            this.btn_data_logger_path.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btn_data_logger_path.UseVisualStyleBackColor = true;
            this.btn_data_logger_path.Click += new System.EventHandler(this.btn_data_logger_path_Click);
            // 
            // cbox_data_converter_unit
            // 
            this.cbox_data_converter_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_data_converter_unit.FormattingEnabled = true;
            this.cbox_data_converter_unit.Items.AddRange(new object[] {
            "V",
            "g"});
            this.cbox_data_converter_unit.Location = new System.Drawing.Point(105, 112);
            this.cbox_data_converter_unit.Name = "cbox_data_converter_unit";
            this.cbox_data_converter_unit.Size = new System.Drawing.Size(112, 23);
            this.cbox_data_converter_unit.TabIndex = 8;
            this.cbox_data_converter_unit.SelectedIndexChanged += new System.EventHandler(this.cbox_data_converter_unit_SelectedIndexChanged);
            this.cbox_data_converter_unit.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_data_converter_unit.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // lb_data_converter_unit
            // 
            this.lb_data_converter_unit.AutoSize = true;
            this.lb_data_converter_unit.Location = new System.Drawing.Point(24, 116);
            this.lb_data_converter_unit.Name = "lb_data_converter_unit";
            this.lb_data_converter_unit.Size = new System.Drawing.Size(75, 15);
            this.lb_data_converter_unit.TabIndex = 9;
            this.lb_data_converter_unit.Text = "Convert Unit";
            // 
            // frm_logger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 337);
            this.Controls.Add(this.btn_data_logger_path);
            this.Controls.Add(this.gbox_data_converter);
            this.Controls.Add(this.btn_data_logger_advanced);
            this.Controls.Add(this.pbar_data_logger_progress);
            this.Controls.Add(this.tbox_data_logger_seconds);
            this.Controls.Add(this.tbox_data_logger_path);
            this.Controls.Add(this.btn_data_logger_start);
            this.Controls.Add(this.lb_data_logger_seconds);
            this.Controls.Add(this.lb_data_logger_path);
            this.Controls.Add(this.cbox_data_logger_enabled);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_logger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Logger Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_log_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_logger_FormClosed);
            this.Load += new System.EventHandler(this.frm_log_Load);
            this.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            this.gbox_data_converter.ResumeLayout(false);
            this.gbox_data_converter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbox_data_logger_enabled;
        private System.Windows.Forms.Label lb_data_logger_path;
        private System.Windows.Forms.Label lb_data_logger_seconds;
        private System.Windows.Forms.Button btn_data_logger_start;
        private System.Windows.Forms.TextBox tbox_data_logger_path;
        private System.Windows.Forms.TextBox tbox_data_logger_seconds;
        private System.Windows.Forms.ProgressBar pbar_data_logger_progress;
        private System.Windows.Forms.Button btn_data_logger_advanced;
        private System.Windows.Forms.GroupBox gbox_data_converter;
        private System.Windows.Forms.Button btn_data_converter_destination;
        private System.Windows.Forms.Button btn_data_converter_source;
        private System.Windows.Forms.Button btn_data_converter_start;
        private System.Windows.Forms.Label lb_data_converter_destination;
        private System.Windows.Forms.Label lb_data_converter_source;
        private System.Windows.Forms.TextBox tbox_data_converter_destination;
        private System.Windows.Forms.TextBox tbox_data_converter_source;
        private System.Windows.Forms.Button btn_data_converter_folder;
        private System.Windows.Forms.Button btn_data_logger_path;
        private System.Windows.Forms.ComboBox cbox_data_converter_unit;
        private System.Windows.Forms.Label lb_data_converter_unit;
    }
}