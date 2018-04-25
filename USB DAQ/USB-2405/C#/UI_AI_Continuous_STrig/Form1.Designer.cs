namespace AIO_Simultaneous_UI
{
    partial class frm_main
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
            this.cbox_device_type = new System.Windows.Forms.ComboBox();
            this.cbox_device_index = new System.Windows.Forms.ComboBox();
            this.lb_device_type = new System.Windows.Forms.Label();
            this.lb_device_index = new System.Windows.Forms.Label();
            this.gbox_device_operation = new System.Windows.Forms.GroupBox();
            this.btn_data_logger = new System.Windows.Forms.Button();
            this.tbox_ai_buf_ready_cnt = new System.Windows.Forms.TextBox();
            this.btn_device_start = new System.Windows.Forms.Button();
            this.btn_device_open = new System.Windows.Forms.Button();
            this.gbox_ai_operation = new System.Windows.Forms.GroupBox();
            this.gbox_ai_sensor_settings = new System.Windows.Forms.GroupBox();
            this.cbox_ai_sensor_settings = new System.Windows.Forms.ComboBox();
            this.lb_ai_sensor_settings = new System.Windows.Forms.Label();
            this.tbox_sensor_ch3_sensitivity = new System.Windows.Forms.TextBox();
            this.lb_sensor_ch3_sensitivity = new System.Windows.Forms.Label();
            this.tbox_sensor_ch1_sensitivity = new System.Windows.Forms.TextBox();
            this.lb_sensor_ch1_sensitivity = new System.Windows.Forms.Label();
            this.tbox_sensor_ch2_sensitivity = new System.Windows.Forms.TextBox();
            this.lb_sensor_ch2_sensitivity = new System.Windows.Forms.Label();
            this.tbox_sensor_ch0_sensitivity = new System.Windows.Forms.TextBox();
            this.lb_sensor_ch0_sensitivity = new System.Windows.Forms.Label();
            this.gbox_ai_status = new System.Windows.Forms.GroupBox();
            this.lb_ai_ch_magnitude_unit = new System.Windows.Forms.Label();
            this.cbox_ai_ch_magnitude_unit = new System.Windows.Forms.ComboBox();
            this.tbox_ai_ch3_magnitude3 = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch3_magnitude2 = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch3_magnitude = new System.Windows.Forms.TextBox();
            this.lb_ai_ch3_magnitude = new System.Windows.Forms.Label();
            this.lb_ai_ch3_freqency = new System.Windows.Forms.Label();
            this.tbox_ai_ch3_frequency = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch2_magnitude3 = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch2_magnitude2 = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch2_magnitude = new System.Windows.Forms.TextBox();
            this.lb_ai_ch2_magnitude = new System.Windows.Forms.Label();
            this.lb_ai_ch2_freqency = new System.Windows.Forms.Label();
            this.tbox_ai_ch2_frequency = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch1_magnitude3 = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch1_magnitude2 = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch1_magnitude = new System.Windows.Forms.TextBox();
            this.lb_ai_ch1_magnitude = new System.Windows.Forms.Label();
            this.lb_ai_ch1_freqency = new System.Windows.Forms.Label();
            this.tbox_ai_ch1_frequency = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch0_magnitude3 = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch0_magnitude2 = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch0_magnitude = new System.Windows.Forms.TextBox();
            this.lb_ai_ch0_magnitude = new System.Windows.Forms.Label();
            this.lb_ai_ch0_freqency = new System.Windows.Forms.Label();
            this.tbox_ai_ch0_frequency = new System.Windows.Forms.TextBox();
            this.gbox_ai_settings = new System.Windows.Forms.GroupBox();
            this.cbox_ai_trigger_source = new System.Windows.Forms.ComboBox();
            this.lb_ai_trigger_source = new System.Windows.Forms.Label();
            this.cbox_ai_channel_select = new System.Windows.Forms.ComboBox();
            this.lb_ai_channel_select = new System.Windows.Forms.Label();
            this.cbox_ai_channel_type = new System.Windows.Forms.ComboBox();
            this.cbox_ai_channel_range = new System.Windows.Forms.ComboBox();
            this.tbox_ai_sample_rate = new System.Windows.Forms.TextBox();
            this.lb_ai_channel_type = new System.Windows.Forms.Label();
            this.lb_ai_channel_range = new System.Windows.Forms.Label();
            this.lb_ai_sample_rate = new System.Windows.Forms.Label();
            this.zg_ai_wave_raw = new ZedGraph.ZedGraphControl();
            this.zg_ai_wave_fft = new ZedGraph.ZedGraphControl();
            this.lb_ai_ch3_amplitude = new System.Windows.Forms.Label();
            this.tbox_ai_ch3_amplitude = new System.Windows.Forms.TextBox();
            this.lb_ai_ch2_amplitude = new System.Windows.Forms.Label();
            this.tbox_ai_ch2_amplitude = new System.Windows.Forms.TextBox();
            this.lb_ai_ch1_amplitude = new System.Windows.Forms.Label();
            this.tbox_ai_ch1_amplitude = new System.Windows.Forms.TextBox();
            this.lb_ai_ch0_amplitude = new System.Windows.Forms.Label();
            this.tbox_ai_ch0_amplitude = new System.Windows.Forms.TextBox();
            this.gbox_device_operation.SuspendLayout();
            this.gbox_ai_operation.SuspendLayout();
            this.gbox_ai_sensor_settings.SuspendLayout();
            this.gbox_ai_status.SuspendLayout();
            this.gbox_ai_settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbox_device_type
            // 
            this.cbox_device_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_device_type.FormattingEnabled = true;
            this.cbox_device_type.Items.AddRange(new object[] {
            "USB-2405"});
            this.cbox_device_type.Location = new System.Drawing.Point(93, 32);
            this.cbox_device_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbox_device_type.Name = "cbox_device_type";
            this.cbox_device_type.Size = new System.Drawing.Size(140, 23);
            this.cbox_device_type.TabIndex = 2;
            this.cbox_device_type.SelectedIndexChanged += new System.EventHandler(this.cbox_device_type_SelectedIndexChanged);
            this.cbox_device_type.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_device_type.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // cbox_device_index
            // 
            this.cbox_device_index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_device_index.FormattingEnabled = true;
            this.cbox_device_index.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cbox_device_index.Location = new System.Drawing.Point(93, 62);
            this.cbox_device_index.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbox_device_index.Name = "cbox_device_index";
            this.cbox_device_index.Size = new System.Drawing.Size(140, 23);
            this.cbox_device_index.TabIndex = 3;
            this.cbox_device_index.SelectedIndexChanged += new System.EventHandler(this.cbox_device_index_SelectedIndexChanged);
            this.cbox_device_index.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_device_index.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // lb_device_type
            // 
            this.lb_device_type.AutoSize = true;
            this.lb_device_type.Location = new System.Drawing.Point(8, 36);
            this.lb_device_type.Name = "lb_device_type";
            this.lb_device_type.Size = new System.Drawing.Size(60, 15);
            this.lb_device_type.TabIndex = 0;
            this.lb_device_type.Text = "Card Type";
            this.lb_device_type.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_device_index
            // 
            this.lb_device_index.AutoSize = true;
            this.lb_device_index.Location = new System.Drawing.Point(8, 65);
            this.lb_device_index.Name = "lb_device_index";
            this.lb_device_index.Size = new System.Drawing.Size(79, 15);
            this.lb_device_index.TabIndex = 1;
            this.lb_device_index.Text = "Card Number";
            this.lb_device_index.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // gbox_device_operation
            // 
            this.gbox_device_operation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_device_operation.Controls.Add(this.btn_data_logger);
            this.gbox_device_operation.Controls.Add(this.tbox_ai_buf_ready_cnt);
            this.gbox_device_operation.Controls.Add(this.btn_device_start);
            this.gbox_device_operation.Controls.Add(this.btn_device_open);
            this.gbox_device_operation.Controls.Add(this.lb_device_type);
            this.gbox_device_operation.Controls.Add(this.cbox_device_index);
            this.gbox_device_operation.Controls.Add(this.lb_device_index);
            this.gbox_device_operation.Controls.Add(this.cbox_device_type);
            this.gbox_device_operation.Location = new System.Drawing.Point(16, 16);
            this.gbox_device_operation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbox_device_operation.Name = "gbox_device_operation";
            this.gbox_device_operation.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbox_device_operation.Size = new System.Drawing.Size(984, 100);
            this.gbox_device_operation.TabIndex = 0;
            this.gbox_device_operation.TabStop = false;
            this.gbox_device_operation.Text = "Device Opeation";
            this.gbox_device_operation.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // btn_data_logger
            // 
            this.btn_data_logger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_data_logger.Enabled = false;
            this.btn_data_logger.Location = new System.Drawing.Point(848, 22);
            this.btn_data_logger.Name = "btn_data_logger";
            this.btn_data_logger.Size = new System.Drawing.Size(120, 65);
            this.btn_data_logger.TabIndex = 7;
            this.btn_data_logger.Text = "Data Logger Control Panel";
            this.btn_data_logger.UseVisualStyleBackColor = true;
            this.btn_data_logger.Click += new System.EventHandler(this.btn_data_logger_Click);
            // 
            // tbox_ai_buf_ready_cnt
            // 
            this.tbox_ai_buf_ready_cnt.Location = new System.Drawing.Point(616, 62);
            this.tbox_ai_buf_ready_cnt.Name = "tbox_ai_buf_ready_cnt";
            this.tbox_ai_buf_ready_cnt.ReadOnly = true;
            this.tbox_ai_buf_ready_cnt.Size = new System.Drawing.Size(100, 23);
            this.tbox_ai_buf_ready_cnt.TabIndex = 4;
            this.tbox_ai_buf_ready_cnt.TabStop = false;
            this.tbox_ai_buf_ready_cnt.Visible = false;
            // 
            // btn_device_start
            // 
            this.btn_device_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_device_start.Enabled = false;
            this.btn_device_start.Location = new System.Drawing.Point(722, 58);
            this.btn_device_start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_device_start.Name = "btn_device_start";
            this.btn_device_start.Size = new System.Drawing.Size(120, 29);
            this.btn_device_start.TabIndex = 6;
            this.btn_device_start.Text = "Start Operation";
            this.btn_device_start.UseVisualStyleBackColor = true;
            this.btn_device_start.Click += new System.EventHandler(this.btn_device_start_Click);
            // 
            // btn_device_open
            // 
            this.btn_device_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_device_open.Location = new System.Drawing.Point(722, 22);
            this.btn_device_open.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_device_open.Name = "btn_device_open";
            this.btn_device_open.Size = new System.Drawing.Size(120, 29);
            this.btn_device_open.TabIndex = 5;
            this.btn_device_open.Text = "Open Device";
            this.btn_device_open.UseVisualStyleBackColor = true;
            this.btn_device_open.Click += new System.EventHandler(this.btn_device_open_Click);
            // 
            // gbox_ai_operation
            // 
            this.gbox_ai_operation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_ai_operation.Controls.Add(this.gbox_ai_sensor_settings);
            this.gbox_ai_operation.Controls.Add(this.gbox_ai_status);
            this.gbox_ai_operation.Controls.Add(this.gbox_ai_settings);
            this.gbox_ai_operation.Enabled = false;
            this.gbox_ai_operation.Location = new System.Drawing.Point(16, 124);
            this.gbox_ai_operation.Name = "gbox_ai_operation";
            this.gbox_ai_operation.Size = new System.Drawing.Size(984, 332);
            this.gbox_ai_operation.TabIndex = 1;
            this.gbox_ai_operation.TabStop = false;
            this.gbox_ai_operation.Text = "AI Operation";
            this.gbox_ai_operation.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // gbox_ai_sensor_settings
            // 
            this.gbox_ai_sensor_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbox_ai_sensor_settings.Controls.Add(this.cbox_ai_sensor_settings);
            this.gbox_ai_sensor_settings.Controls.Add(this.lb_ai_sensor_settings);
            this.gbox_ai_sensor_settings.Controls.Add(this.tbox_sensor_ch3_sensitivity);
            this.gbox_ai_sensor_settings.Controls.Add(this.lb_sensor_ch3_sensitivity);
            this.gbox_ai_sensor_settings.Controls.Add(this.tbox_sensor_ch1_sensitivity);
            this.gbox_ai_sensor_settings.Controls.Add(this.lb_sensor_ch1_sensitivity);
            this.gbox_ai_sensor_settings.Controls.Add(this.tbox_sensor_ch2_sensitivity);
            this.gbox_ai_sensor_settings.Controls.Add(this.lb_sensor_ch2_sensitivity);
            this.gbox_ai_sensor_settings.Controls.Add(this.tbox_sensor_ch0_sensitivity);
            this.gbox_ai_sensor_settings.Controls.Add(this.lb_sensor_ch0_sensitivity);
            this.gbox_ai_sensor_settings.Location = new System.Drawing.Point(16, 174);
            this.gbox_ai_sensor_settings.Name = "gbox_ai_sensor_settings";
            this.gbox_ai_sensor_settings.Size = new System.Drawing.Size(468, 143);
            this.gbox_ai_sensor_settings.TabIndex = 1;
            this.gbox_ai_sensor_settings.TabStop = false;
            this.gbox_ai_sensor_settings.Text = "Advanced Settings";
            this.gbox_ai_sensor_settings.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // cbox_ai_sensor_settings
            // 
            this.cbox_ai_sensor_settings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ai_sensor_settings.FormattingEnabled = true;
            this.cbox_ai_sensor_settings.Items.AddRange(new object[] {
            "Sensor Sensitivity"});
            this.cbox_ai_sensor_settings.Location = new System.Drawing.Point(100, 29);
            this.cbox_ai_sensor_settings.Name = "cbox_ai_sensor_settings";
            this.cbox_ai_sensor_settings.Size = new System.Drawing.Size(123, 23);
            this.cbox_ai_sensor_settings.TabIndex = 5;
            this.cbox_ai_sensor_settings.SelectedIndexChanged += new System.EventHandler(this.cbox_ai_sensor_settings_SelectedIndexChanged);
            this.cbox_ai_sensor_settings.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_ai_sensor_settings.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // lb_ai_sensor_settings
            // 
            this.lb_ai_sensor_settings.AutoSize = true;
            this.lb_ai_sensor_settings.Location = new System.Drawing.Point(8, 32);
            this.lb_ai_sensor_settings.Name = "lb_ai_sensor_settings";
            this.lb_ai_sensor_settings.Size = new System.Drawing.Size(83, 15);
            this.lb_ai_sensor_settings.TabIndex = 0;
            this.lb_ai_sensor_settings.Text = "Setting Option";
            this.lb_ai_sensor_settings.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_sensor_ch3_sensitivity
            // 
            this.tbox_sensor_ch3_sensitivity.Enabled = false;
            this.tbox_sensor_ch3_sensitivity.Location = new System.Drawing.Point(368, 107);
            this.tbox_sensor_ch3_sensitivity.Name = "tbox_sensor_ch3_sensitivity";
            this.tbox_sensor_ch3_sensitivity.Size = new System.Drawing.Size(83, 23);
            this.tbox_sensor_ch3_sensitivity.TabIndex = 9;
            this.tbox_sensor_ch3_sensitivity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_sensor_ch_sensitivity_KeyDown);
            this.tbox_sensor_ch3_sensitivity.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_sensor_ch3_sensitivity_Validating);
            // 
            // lb_sensor_ch3_sensitivity
            // 
            this.lb_sensor_ch3_sensitivity.AutoSize = true;
            this.lb_sensor_ch3_sensitivity.Location = new System.Drawing.Point(236, 110);
            this.lb_sensor_ch3_sensitivity.Name = "lb_sensor_ch3_sensitivity";
            this.lb_sensor_ch3_sensitivity.Size = new System.Drawing.Size(126, 15);
            this.lb_sensor_ch3_sensitivity.TabIndex = 4;
            this.lb_sensor_ch3_sensitivity.Text = "CH3 Sensitivity (mV/g)";
            this.lb_sensor_ch3_sensitivity.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_sensor_ch1_sensitivity
            // 
            this.tbox_sensor_ch1_sensitivity.Enabled = false;
            this.tbox_sensor_ch1_sensitivity.Location = new System.Drawing.Point(368, 77);
            this.tbox_sensor_ch1_sensitivity.Name = "tbox_sensor_ch1_sensitivity";
            this.tbox_sensor_ch1_sensitivity.Size = new System.Drawing.Size(83, 23);
            this.tbox_sensor_ch1_sensitivity.TabIndex = 7;
            this.tbox_sensor_ch1_sensitivity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_sensor_ch_sensitivity_KeyDown);
            this.tbox_sensor_ch1_sensitivity.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_sensor_ch1_sensitivity_Validating);
            // 
            // lb_sensor_ch1_sensitivity
            // 
            this.lb_sensor_ch1_sensitivity.AutoSize = true;
            this.lb_sensor_ch1_sensitivity.Location = new System.Drawing.Point(236, 80);
            this.lb_sensor_ch1_sensitivity.Name = "lb_sensor_ch1_sensitivity";
            this.lb_sensor_ch1_sensitivity.Size = new System.Drawing.Size(126, 15);
            this.lb_sensor_ch1_sensitivity.TabIndex = 2;
            this.lb_sensor_ch1_sensitivity.Text = "CH1 Sensitivity (mV/g)";
            this.lb_sensor_ch1_sensitivity.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_sensor_ch2_sensitivity
            // 
            this.tbox_sensor_ch2_sensitivity.Enabled = false;
            this.tbox_sensor_ch2_sensitivity.Location = new System.Drawing.Point(140, 107);
            this.tbox_sensor_ch2_sensitivity.Name = "tbox_sensor_ch2_sensitivity";
            this.tbox_sensor_ch2_sensitivity.Size = new System.Drawing.Size(83, 23);
            this.tbox_sensor_ch2_sensitivity.TabIndex = 8;
            this.tbox_sensor_ch2_sensitivity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_sensor_ch_sensitivity_KeyDown);
            this.tbox_sensor_ch2_sensitivity.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_sensor_ch2_sensitivity_Validating);
            // 
            // lb_sensor_ch2_sensitivity
            // 
            this.lb_sensor_ch2_sensitivity.AutoSize = true;
            this.lb_sensor_ch2_sensitivity.Location = new System.Drawing.Point(8, 110);
            this.lb_sensor_ch2_sensitivity.Name = "lb_sensor_ch2_sensitivity";
            this.lb_sensor_ch2_sensitivity.Size = new System.Drawing.Size(126, 15);
            this.lb_sensor_ch2_sensitivity.TabIndex = 3;
            this.lb_sensor_ch2_sensitivity.Text = "CH2 Sensitivity (mV/g)";
            this.lb_sensor_ch2_sensitivity.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_sensor_ch0_sensitivity
            // 
            this.tbox_sensor_ch0_sensitivity.Enabled = false;
            this.tbox_sensor_ch0_sensitivity.Location = new System.Drawing.Point(140, 77);
            this.tbox_sensor_ch0_sensitivity.Name = "tbox_sensor_ch0_sensitivity";
            this.tbox_sensor_ch0_sensitivity.Size = new System.Drawing.Size(83, 23);
            this.tbox_sensor_ch0_sensitivity.TabIndex = 6;
            this.tbox_sensor_ch0_sensitivity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_sensor_ch_sensitivity_KeyDown);
            this.tbox_sensor_ch0_sensitivity.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_sensor_ch0_sensitivity_Validating);
            // 
            // lb_sensor_ch0_sensitivity
            // 
            this.lb_sensor_ch0_sensitivity.AutoSize = true;
            this.lb_sensor_ch0_sensitivity.Location = new System.Drawing.Point(8, 80);
            this.lb_sensor_ch0_sensitivity.Name = "lb_sensor_ch0_sensitivity";
            this.lb_sensor_ch0_sensitivity.Size = new System.Drawing.Size(126, 15);
            this.lb_sensor_ch0_sensitivity.TabIndex = 1;
            this.lb_sensor_ch0_sensitivity.Text = "CH0 Sensitivity (mV/g)";
            this.lb_sensor_ch0_sensitivity.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // gbox_ai_status
            // 
            this.gbox_ai_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch3_amplitude);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch3_amplitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch2_amplitude);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch2_amplitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch1_amplitude);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch1_amplitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch0_amplitude);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch0_amplitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch_magnitude_unit);
            this.gbox_ai_status.Controls.Add(this.cbox_ai_ch_magnitude_unit);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch3_magnitude3);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch3_magnitude2);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch3_magnitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch3_magnitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch3_freqency);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch3_frequency);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch2_magnitude3);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch2_magnitude2);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch2_magnitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch2_magnitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch2_freqency);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch2_frequency);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch1_magnitude3);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch1_magnitude2);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch1_magnitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch1_magnitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch1_freqency);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch1_frequency);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch0_magnitude3);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch0_magnitude2);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch0_magnitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch0_magnitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch0_freqency);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch0_frequency);
            this.gbox_ai_status.Location = new System.Drawing.Point(500, 24);
            this.gbox_ai_status.Name = "gbox_ai_status";
            this.gbox_ai_status.Size = new System.Drawing.Size(468, 293);
            this.gbox_ai_status.TabIndex = 2;
            this.gbox_ai_status.TabStop = false;
            this.gbox_ai_status.Text = "AI status";
            this.gbox_ai_status.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_ai_ch_magnitude_unit
            // 
            this.lb_ai_ch_magnitude_unit.AutoSize = true;
            this.lb_ai_ch_magnitude_unit.Location = new System.Drawing.Point(8, 25);
            this.lb_ai_ch_magnitude_unit.Name = "lb_ai_ch_magnitude_unit";
            this.lb_ai_ch_magnitude_unit.Size = new System.Drawing.Size(92, 15);
            this.lb_ai_ch_magnitude_unit.TabIndex = 0;
            this.lb_ai_ch_magnitude_unit.Text = "Magnitude Unit";
            this.lb_ai_ch_magnitude_unit.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // cbox_ai_ch_magnitude_unit
            // 
            this.cbox_ai_ch_magnitude_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ai_ch_magnitude_unit.FormattingEnabled = true;
            this.cbox_ai_ch_magnitude_unit.Items.AddRange(new object[] {
            "V",
            "g"});
            this.cbox_ai_ch_magnitude_unit.Location = new System.Drawing.Point(122, 22);
            this.cbox_ai_ch_magnitude_unit.Name = "cbox_ai_ch_magnitude_unit";
            this.cbox_ai_ch_magnitude_unit.Size = new System.Drawing.Size(112, 23);
            this.cbox_ai_ch_magnitude_unit.TabIndex = 9;
            this.cbox_ai_ch_magnitude_unit.SelectedIndexChanged += new System.EventHandler(this.cbox_ai_ch_magnitude_unit_SelectedIndexChanged);
            this.cbox_ai_ch_magnitude_unit.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_ai_ch_magnitude_unit.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // tbox_ai_ch3_magnitude3
            // 
            this.tbox_ai_ch3_magnitude3.Location = new System.Drawing.Point(346, 259);
            this.tbox_ai_ch3_magnitude3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch3_magnitude3.Name = "tbox_ai_ch3_magnitude3";
            this.tbox_ai_ch3_magnitude3.ReadOnly = true;
            this.tbox_ai_ch3_magnitude3.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch3_magnitude3.TabIndex = 25;
            this.tbox_ai_ch3_magnitude3.Visible = false;
            // 
            // tbox_ai_ch3_magnitude2
            // 
            this.tbox_ai_ch3_magnitude2.Location = new System.Drawing.Point(234, 259);
            this.tbox_ai_ch3_magnitude2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch3_magnitude2.Name = "tbox_ai_ch3_magnitude2";
            this.tbox_ai_ch3_magnitude2.ReadOnly = true;
            this.tbox_ai_ch3_magnitude2.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch3_magnitude2.TabIndex = 24;
            this.tbox_ai_ch3_magnitude2.Visible = false;
            // 
            // tbox_ai_ch3_magnitude
            // 
            this.tbox_ai_ch3_magnitude.Location = new System.Drawing.Point(122, 259);
            this.tbox_ai_ch3_magnitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch3_magnitude.Name = "tbox_ai_ch3_magnitude";
            this.tbox_ai_ch3_magnitude.ReadOnly = true;
            this.tbox_ai_ch3_magnitude.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch3_magnitude.TabIndex = 23;
            this.tbox_ai_ch3_magnitude.Visible = false;
            // 
            // lb_ai_ch3_magnitude
            // 
            this.lb_ai_ch3_magnitude.AutoSize = true;
            this.lb_ai_ch3_magnitude.Location = new System.Drawing.Point(8, 262);
            this.lb_ai_ch3_magnitude.Name = "lb_ai_ch3_magnitude";
            this.lb_ai_ch3_magnitude.Size = new System.Drawing.Size(91, 15);
            this.lb_ai_ch3_magnitude.TabIndex = 8;
            this.lb_ai_ch3_magnitude.Text = "CH3 Magnitude";
            this.lb_ai_ch3_magnitude.Visible = false;
            this.lb_ai_ch3_magnitude.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_ai_ch3_freqency
            // 
            this.lb_ai_ch3_freqency.AutoSize = true;
            this.lb_ai_ch3_freqency.Location = new System.Drawing.Point(8, 240);
            this.lb_ai_ch3_freqency.Name = "lb_ai_ch3_freqency";
            this.lb_ai_ch3_freqency.Size = new System.Drawing.Size(112, 15);
            this.lb_ai_ch3_freqency.TabIndex = 7;
            this.lb_ai_ch3_freqency.Text = "CH3 Frequency (Hz)";
            this.lb_ai_ch3_freqency.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_ai_ch3_frequency
            // 
            this.tbox_ai_ch3_frequency.Location = new System.Drawing.Point(122, 237);
            this.tbox_ai_ch3_frequency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch3_frequency.Name = "tbox_ai_ch3_frequency";
            this.tbox_ai_ch3_frequency.ReadOnly = true;
            this.tbox_ai_ch3_frequency.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch3_frequency.TabIndex = 22;
            // 
            // tbox_ai_ch2_magnitude3
            // 
            this.tbox_ai_ch2_magnitude3.Location = new System.Drawing.Point(346, 205);
            this.tbox_ai_ch2_magnitude3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch2_magnitude3.Name = "tbox_ai_ch2_magnitude3";
            this.tbox_ai_ch2_magnitude3.ReadOnly = true;
            this.tbox_ai_ch2_magnitude3.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch2_magnitude3.TabIndex = 21;
            this.tbox_ai_ch2_magnitude3.Visible = false;
            // 
            // tbox_ai_ch2_magnitude2
            // 
            this.tbox_ai_ch2_magnitude2.Location = new System.Drawing.Point(234, 205);
            this.tbox_ai_ch2_magnitude2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch2_magnitude2.Name = "tbox_ai_ch2_magnitude2";
            this.tbox_ai_ch2_magnitude2.ReadOnly = true;
            this.tbox_ai_ch2_magnitude2.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch2_magnitude2.TabIndex = 20;
            this.tbox_ai_ch2_magnitude2.Visible = false;
            // 
            // tbox_ai_ch2_magnitude
            // 
            this.tbox_ai_ch2_magnitude.Location = new System.Drawing.Point(122, 205);
            this.tbox_ai_ch2_magnitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch2_magnitude.Name = "tbox_ai_ch2_magnitude";
            this.tbox_ai_ch2_magnitude.ReadOnly = true;
            this.tbox_ai_ch2_magnitude.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch2_magnitude.TabIndex = 19;
            this.tbox_ai_ch2_magnitude.Visible = false;
            // 
            // lb_ai_ch2_magnitude
            // 
            this.lb_ai_ch2_magnitude.AutoSize = true;
            this.lb_ai_ch2_magnitude.Location = new System.Drawing.Point(8, 208);
            this.lb_ai_ch2_magnitude.Name = "lb_ai_ch2_magnitude";
            this.lb_ai_ch2_magnitude.Size = new System.Drawing.Size(91, 15);
            this.lb_ai_ch2_magnitude.TabIndex = 6;
            this.lb_ai_ch2_magnitude.Text = "CH2 Magnitude";
            this.lb_ai_ch2_magnitude.Visible = false;
            this.lb_ai_ch2_magnitude.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_ai_ch2_freqency
            // 
            this.lb_ai_ch2_freqency.AutoSize = true;
            this.lb_ai_ch2_freqency.Location = new System.Drawing.Point(8, 186);
            this.lb_ai_ch2_freqency.Name = "lb_ai_ch2_freqency";
            this.lb_ai_ch2_freqency.Size = new System.Drawing.Size(112, 15);
            this.lb_ai_ch2_freqency.TabIndex = 5;
            this.lb_ai_ch2_freqency.Text = "CH2 Frequency (Hz)";
            this.lb_ai_ch2_freqency.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_ai_ch2_frequency
            // 
            this.tbox_ai_ch2_frequency.Location = new System.Drawing.Point(122, 183);
            this.tbox_ai_ch2_frequency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch2_frequency.Name = "tbox_ai_ch2_frequency";
            this.tbox_ai_ch2_frequency.ReadOnly = true;
            this.tbox_ai_ch2_frequency.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch2_frequency.TabIndex = 18;
            // 
            // tbox_ai_ch1_magnitude3
            // 
            this.tbox_ai_ch1_magnitude3.Location = new System.Drawing.Point(346, 151);
            this.tbox_ai_ch1_magnitude3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch1_magnitude3.Name = "tbox_ai_ch1_magnitude3";
            this.tbox_ai_ch1_magnitude3.ReadOnly = true;
            this.tbox_ai_ch1_magnitude3.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch1_magnitude3.TabIndex = 17;
            this.tbox_ai_ch1_magnitude3.Visible = false;
            // 
            // tbox_ai_ch1_magnitude2
            // 
            this.tbox_ai_ch1_magnitude2.Location = new System.Drawing.Point(234, 151);
            this.tbox_ai_ch1_magnitude2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch1_magnitude2.Name = "tbox_ai_ch1_magnitude2";
            this.tbox_ai_ch1_magnitude2.ReadOnly = true;
            this.tbox_ai_ch1_magnitude2.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch1_magnitude2.TabIndex = 16;
            this.tbox_ai_ch1_magnitude2.Visible = false;
            // 
            // tbox_ai_ch1_magnitude
            // 
            this.tbox_ai_ch1_magnitude.Location = new System.Drawing.Point(122, 151);
            this.tbox_ai_ch1_magnitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch1_magnitude.Name = "tbox_ai_ch1_magnitude";
            this.tbox_ai_ch1_magnitude.ReadOnly = true;
            this.tbox_ai_ch1_magnitude.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch1_magnitude.TabIndex = 15;
            this.tbox_ai_ch1_magnitude.Visible = false;
            // 
            // lb_ai_ch1_magnitude
            // 
            this.lb_ai_ch1_magnitude.AutoSize = true;
            this.lb_ai_ch1_magnitude.Location = new System.Drawing.Point(8, 154);
            this.lb_ai_ch1_magnitude.Name = "lb_ai_ch1_magnitude";
            this.lb_ai_ch1_magnitude.Size = new System.Drawing.Size(91, 15);
            this.lb_ai_ch1_magnitude.TabIndex = 4;
            this.lb_ai_ch1_magnitude.Text = "CH1 Magnitude";
            this.lb_ai_ch1_magnitude.Visible = false;
            this.lb_ai_ch1_magnitude.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_ai_ch1_freqency
            // 
            this.lb_ai_ch1_freqency.AutoSize = true;
            this.lb_ai_ch1_freqency.Location = new System.Drawing.Point(8, 132);
            this.lb_ai_ch1_freqency.Name = "lb_ai_ch1_freqency";
            this.lb_ai_ch1_freqency.Size = new System.Drawing.Size(112, 15);
            this.lb_ai_ch1_freqency.TabIndex = 3;
            this.lb_ai_ch1_freqency.Text = "CH1 Frequency (Hz)";
            this.lb_ai_ch1_freqency.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_ai_ch1_frequency
            // 
            this.tbox_ai_ch1_frequency.Location = new System.Drawing.Point(122, 129);
            this.tbox_ai_ch1_frequency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch1_frequency.Name = "tbox_ai_ch1_frequency";
            this.tbox_ai_ch1_frequency.ReadOnly = true;
            this.tbox_ai_ch1_frequency.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch1_frequency.TabIndex = 14;
            // 
            // tbox_ai_ch0_magnitude3
            // 
            this.tbox_ai_ch0_magnitude3.Location = new System.Drawing.Point(346, 97);
            this.tbox_ai_ch0_magnitude3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch0_magnitude3.Name = "tbox_ai_ch0_magnitude3";
            this.tbox_ai_ch0_magnitude3.ReadOnly = true;
            this.tbox_ai_ch0_magnitude3.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch0_magnitude3.TabIndex = 13;
            this.tbox_ai_ch0_magnitude3.Visible = false;
            // 
            // tbox_ai_ch0_magnitude2
            // 
            this.tbox_ai_ch0_magnitude2.Location = new System.Drawing.Point(234, 97);
            this.tbox_ai_ch0_magnitude2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch0_magnitude2.Name = "tbox_ai_ch0_magnitude2";
            this.tbox_ai_ch0_magnitude2.ReadOnly = true;
            this.tbox_ai_ch0_magnitude2.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch0_magnitude2.TabIndex = 12;
            this.tbox_ai_ch0_magnitude2.Visible = false;
            // 
            // tbox_ai_ch0_magnitude
            // 
            this.tbox_ai_ch0_magnitude.Location = new System.Drawing.Point(122, 97);
            this.tbox_ai_ch0_magnitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch0_magnitude.Name = "tbox_ai_ch0_magnitude";
            this.tbox_ai_ch0_magnitude.ReadOnly = true;
            this.tbox_ai_ch0_magnitude.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch0_magnitude.TabIndex = 11;
            this.tbox_ai_ch0_magnitude.Visible = false;
            // 
            // lb_ai_ch0_magnitude
            // 
            this.lb_ai_ch0_magnitude.AutoSize = true;
            this.lb_ai_ch0_magnitude.Location = new System.Drawing.Point(8, 100);
            this.lb_ai_ch0_magnitude.Name = "lb_ai_ch0_magnitude";
            this.lb_ai_ch0_magnitude.Size = new System.Drawing.Size(91, 15);
            this.lb_ai_ch0_magnitude.TabIndex = 2;
            this.lb_ai_ch0_magnitude.Text = "CH0 Magnitude";
            this.lb_ai_ch0_magnitude.Visible = false;
            this.lb_ai_ch0_magnitude.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_ai_ch0_freqency
            // 
            this.lb_ai_ch0_freqency.AutoSize = true;
            this.lb_ai_ch0_freqency.Location = new System.Drawing.Point(8, 78);
            this.lb_ai_ch0_freqency.Name = "lb_ai_ch0_freqency";
            this.lb_ai_ch0_freqency.Size = new System.Drawing.Size(112, 15);
            this.lb_ai_ch0_freqency.TabIndex = 1;
            this.lb_ai_ch0_freqency.Text = "CH0 Frequency (Hz)";
            this.lb_ai_ch0_freqency.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_ai_ch0_frequency
            // 
            this.tbox_ai_ch0_frequency.Location = new System.Drawing.Point(122, 75);
            this.tbox_ai_ch0_frequency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch0_frequency.Name = "tbox_ai_ch0_frequency";
            this.tbox_ai_ch0_frequency.ReadOnly = true;
            this.tbox_ai_ch0_frequency.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch0_frequency.TabIndex = 10;
            // 
            // gbox_ai_settings
            // 
            this.gbox_ai_settings.Controls.Add(this.cbox_ai_trigger_source);
            this.gbox_ai_settings.Controls.Add(this.lb_ai_trigger_source);
            this.gbox_ai_settings.Controls.Add(this.cbox_ai_channel_select);
            this.gbox_ai_settings.Controls.Add(this.lb_ai_channel_select);
            this.gbox_ai_settings.Controls.Add(this.cbox_ai_channel_type);
            this.gbox_ai_settings.Controls.Add(this.cbox_ai_channel_range);
            this.gbox_ai_settings.Controls.Add(this.tbox_ai_sample_rate);
            this.gbox_ai_settings.Controls.Add(this.lb_ai_channel_type);
            this.gbox_ai_settings.Controls.Add(this.lb_ai_channel_range);
            this.gbox_ai_settings.Controls.Add(this.lb_ai_sample_rate);
            this.gbox_ai_settings.Location = new System.Drawing.Point(16, 24);
            this.gbox_ai_settings.Name = "gbox_ai_settings";
            this.gbox_ai_settings.Size = new System.Drawing.Size(468, 144);
            this.gbox_ai_settings.TabIndex = 0;
            this.gbox_ai_settings.TabStop = false;
            this.gbox_ai_settings.Text = "AI Settings";
            this.gbox_ai_settings.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // cbox_ai_trigger_source
            // 
            this.cbox_ai_trigger_source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ai_trigger_source.Enabled = false;
            this.cbox_ai_trigger_source.FormattingEnabled = true;
            this.cbox_ai_trigger_source.Items.AddRange(new object[] {
            "Software"});
            this.cbox_ai_trigger_source.Location = new System.Drawing.Point(336, 33);
            this.cbox_ai_trigger_source.Name = "cbox_ai_trigger_source";
            this.cbox_ai_trigger_source.Size = new System.Drawing.Size(123, 23);
            this.cbox_ai_trigger_source.TabIndex = 6;
            this.cbox_ai_trigger_source.SelectedIndexChanged += new System.EventHandler(this.cbox_ai_trigger_source_SelectedIndexChanged);
            this.cbox_ai_trigger_source.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_ai_trigger_source.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // lb_ai_trigger_source
            // 
            this.lb_ai_trigger_source.AutoSize = true;
            this.lb_ai_trigger_source.Location = new System.Drawing.Point(236, 36);
            this.lb_ai_trigger_source.Name = "lb_ai_trigger_source";
            this.lb_ai_trigger_source.Size = new System.Drawing.Size(84, 15);
            this.lb_ai_trigger_source.TabIndex = 1;
            this.lb_ai_trigger_source.Text = "Trigger Source";
            this.lb_ai_trigger_source.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // cbox_ai_channel_select
            // 
            this.cbox_ai_channel_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ai_channel_select.FormattingEnabled = true;
            this.cbox_ai_channel_select.Items.AddRange(new object[] {
            "CH 0",
            "CH 0 ~ 1",
            "CH 0 ~ 2",
            "CH 0 ~ 3"});
            this.cbox_ai_channel_select.Location = new System.Drawing.Point(100, 33);
            this.cbox_ai_channel_select.Name = "cbox_ai_channel_select";
            this.cbox_ai_channel_select.Size = new System.Drawing.Size(123, 23);
            this.cbox_ai_channel_select.TabIndex = 5;
            this.cbox_ai_channel_select.SelectedIndexChanged += new System.EventHandler(this.cbox_ai_channel_select_SelectedIndexChanged);
            this.cbox_ai_channel_select.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_ai_channel_select.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // lb_ai_channel_select
            // 
            this.lb_ai_channel_select.AutoSize = true;
            this.lb_ai_channel_select.Location = new System.Drawing.Point(8, 36);
            this.lb_ai_channel_select.Name = "lb_ai_channel_select";
            this.lb_ai_channel_select.Size = new System.Drawing.Size(87, 15);
            this.lb_ai_channel_select.TabIndex = 0;
            this.lb_ai_channel_select.Text = "Channel Select";
            this.lb_ai_channel_select.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // cbox_ai_channel_type
            // 
            this.cbox_ai_channel_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ai_channel_type.FormattingEnabled = true;
            this.cbox_ai_channel_type.Items.AddRange(new object[] {
            "Differential with DC Coupling",
            "Differential with AC Coupling",
            "Differential with IEPE Enable",
            "Pseudo-Differential with DC Coupling",
            "Pseudo-Differential with AC Coupling",
            "Pseudo-Differential with IEPE Enable"});
            this.cbox_ai_channel_type.Location = new System.Drawing.Point(100, 105);
            this.cbox_ai_channel_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbox_ai_channel_type.Name = "cbox_ai_channel_type";
            this.cbox_ai_channel_type.Size = new System.Drawing.Size(359, 23);
            this.cbox_ai_channel_type.TabIndex = 9;
            this.cbox_ai_channel_type.SelectedIndexChanged += new System.EventHandler(this.cbox_ai_channel_type_SelectedIndexChanged);
            this.cbox_ai_channel_type.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_ai_channel_type.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // cbox_ai_channel_range
            // 
            this.cbox_ai_channel_range.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ai_channel_range.FormattingEnabled = true;
            this.cbox_ai_channel_range.Items.AddRange(new object[] {
            "-10 ~ 10 V"});
            this.cbox_ai_channel_range.Location = new System.Drawing.Point(100, 69);
            this.cbox_ai_channel_range.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbox_ai_channel_range.Name = "cbox_ai_channel_range";
            this.cbox_ai_channel_range.Size = new System.Drawing.Size(123, 23);
            this.cbox_ai_channel_range.TabIndex = 7;
            this.cbox_ai_channel_range.SelectedIndexChanged += new System.EventHandler(this.cbox_ai_channel_range_SelectedIndexChanged);
            this.cbox_ai_channel_range.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_ai_channel_range.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // tbox_ai_sample_rate
            // 
            this.tbox_ai_sample_rate.Location = new System.Drawing.Point(336, 69);
            this.tbox_ai_sample_rate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_sample_rate.Name = "tbox_ai_sample_rate";
            this.tbox_ai_sample_rate.Size = new System.Drawing.Size(123, 23);
            this.tbox_ai_sample_rate.TabIndex = 8;
            this.tbox_ai_sample_rate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_ai_sample_rate_KeyDown);
            this.tbox_ai_sample_rate.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_ai_sample_rate_Validating);
            this.tbox_ai_sample_rate.Validated += new System.EventHandler(this.tbox_ai_sample_rate_Validated);
            // 
            // lb_ai_channel_type
            // 
            this.lb_ai_channel_type.AutoSize = true;
            this.lb_ai_channel_type.Location = new System.Drawing.Point(8, 108);
            this.lb_ai_channel_type.Name = "lb_ai_channel_type";
            this.lb_ai_channel_type.Size = new System.Drawing.Size(79, 15);
            this.lb_ai_channel_type.TabIndex = 4;
            this.lb_ai_channel_type.Text = "Channel Type";
            this.lb_ai_channel_type.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_ai_channel_range
            // 
            this.lb_ai_channel_range.AutoSize = true;
            this.lb_ai_channel_range.Location = new System.Drawing.Point(8, 72);
            this.lb_ai_channel_range.Name = "lb_ai_channel_range";
            this.lb_ai_channel_range.Size = new System.Drawing.Size(88, 15);
            this.lb_ai_channel_range.TabIndex = 2;
            this.lb_ai_channel_range.Text = "Channel Range";
            this.lb_ai_channel_range.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_ai_sample_rate
            // 
            this.lb_ai_sample_rate.AutoSize = true;
            this.lb_ai_sample_rate.Location = new System.Drawing.Point(236, 72);
            this.lb_ai_sample_rate.Name = "lb_ai_sample_rate";
            this.lb_ai_sample_rate.Size = new System.Drawing.Size(98, 15);
            this.lb_ai_sample_rate.TabIndex = 3;
            this.lb_ai_sample_rate.Text = "Sample Rate (Hz)";
            this.lb_ai_sample_rate.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // zg_ai_wave_raw
            // 
            this.zg_ai_wave_raw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.zg_ai_wave_raw.Enabled = false;
            this.zg_ai_wave_raw.IsEnableWheelZoom = false;
            this.zg_ai_wave_raw.IsPrintFillPage = false;
            this.zg_ai_wave_raw.IsPrintKeepAspectRatio = false;
            this.zg_ai_wave_raw.IsPrintScaleAll = false;
            this.zg_ai_wave_raw.IsShowCopyMessage = false;
            this.zg_ai_wave_raw.Location = new System.Drawing.Point(16, 469);
            this.zg_ai_wave_raw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zg_ai_wave_raw.Name = "zg_ai_wave_raw";
            this.zg_ai_wave_raw.ScrollGrace = 0D;
            this.zg_ai_wave_raw.ScrollMaxX = 0D;
            this.zg_ai_wave_raw.ScrollMaxY = 0D;
            this.zg_ai_wave_raw.ScrollMaxY2 = 0D;
            this.zg_ai_wave_raw.ScrollMinX = 0D;
            this.zg_ai_wave_raw.ScrollMinY = 0D;
            this.zg_ai_wave_raw.ScrollMinY2 = 0D;
            this.zg_ai_wave_raw.Size = new System.Drawing.Size(484, 254);
            this.zg_ai_wave_raw.TabIndex = 2;
            // 
            // zg_ai_wave_fft
            // 
            this.zg_ai_wave_fft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zg_ai_wave_fft.Enabled = false;
            this.zg_ai_wave_fft.IsEnableWheelZoom = false;
            this.zg_ai_wave_fft.IsPrintFillPage = false;
            this.zg_ai_wave_fft.IsPrintKeepAspectRatio = false;
            this.zg_ai_wave_fft.IsPrintScaleAll = false;
            this.zg_ai_wave_fft.IsShowCopyMessage = false;
            this.zg_ai_wave_fft.Location = new System.Drawing.Point(516, 469);
            this.zg_ai_wave_fft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zg_ai_wave_fft.Name = "zg_ai_wave_fft";
            this.zg_ai_wave_fft.ScrollGrace = 0D;
            this.zg_ai_wave_fft.ScrollMaxX = 0D;
            this.zg_ai_wave_fft.ScrollMaxY = 0D;
            this.zg_ai_wave_fft.ScrollMaxY2 = 0D;
            this.zg_ai_wave_fft.ScrollMinX = 0D;
            this.zg_ai_wave_fft.ScrollMinY = 0D;
            this.zg_ai_wave_fft.ScrollMinY2 = 0D;
            this.zg_ai_wave_fft.Size = new System.Drawing.Size(484, 254);
            this.zg_ai_wave_fft.TabIndex = 3;
            // 
            // lb_ai_ch3_amplitude
            // 
            this.lb_ai_ch3_amplitude.AutoSize = true;
            this.lb_ai_ch3_amplitude.Location = new System.Drawing.Point(256, 239);
            this.lb_ai_ch3_amplitude.Name = "lb_ai_ch3_amplitude";
            this.lb_ai_ch3_amplitude.Size = new System.Drawing.Size(88, 15);
            this.lb_ai_ch3_amplitude.TabIndex = 29;
            this.lb_ai_ch3_amplitude.Text = "CH3 Amplitude";
            // 
            // tbox_ai_ch3_amplitude
            // 
            this.tbox_ai_ch3_amplitude.Location = new System.Drawing.Point(346, 236);
            this.tbox_ai_ch3_amplitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch3_amplitude.Name = "tbox_ai_ch3_amplitude";
            this.tbox_ai_ch3_amplitude.ReadOnly = true;
            this.tbox_ai_ch3_amplitude.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch3_amplitude.TabIndex = 33;
            // 
            // lb_ai_ch2_amplitude
            // 
            this.lb_ai_ch2_amplitude.AutoSize = true;
            this.lb_ai_ch2_amplitude.Location = new System.Drawing.Point(256, 185);
            this.lb_ai_ch2_amplitude.Name = "lb_ai_ch2_amplitude";
            this.lb_ai_ch2_amplitude.Size = new System.Drawing.Size(88, 15);
            this.lb_ai_ch2_amplitude.TabIndex = 28;
            this.lb_ai_ch2_amplitude.Text = "CH2 Amplitude";
            // 
            // tbox_ai_ch2_amplitude
            // 
            this.tbox_ai_ch2_amplitude.Location = new System.Drawing.Point(346, 182);
            this.tbox_ai_ch2_amplitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch2_amplitude.Name = "tbox_ai_ch2_amplitude";
            this.tbox_ai_ch2_amplitude.ReadOnly = true;
            this.tbox_ai_ch2_amplitude.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch2_amplitude.TabIndex = 32;
            // 
            // lb_ai_ch1_amplitude
            // 
            this.lb_ai_ch1_amplitude.AutoSize = true;
            this.lb_ai_ch1_amplitude.Location = new System.Drawing.Point(256, 131);
            this.lb_ai_ch1_amplitude.Name = "lb_ai_ch1_amplitude";
            this.lb_ai_ch1_amplitude.Size = new System.Drawing.Size(88, 15);
            this.lb_ai_ch1_amplitude.TabIndex = 27;
            this.lb_ai_ch1_amplitude.Text = "CH1 Amplitude";
            // 
            // tbox_ai_ch1_amplitude
            // 
            this.tbox_ai_ch1_amplitude.Location = new System.Drawing.Point(346, 128);
            this.tbox_ai_ch1_amplitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch1_amplitude.Name = "tbox_ai_ch1_amplitude";
            this.tbox_ai_ch1_amplitude.ReadOnly = true;
            this.tbox_ai_ch1_amplitude.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch1_amplitude.TabIndex = 31;
            // 
            // lb_ai_ch0_amplitude
            // 
            this.lb_ai_ch0_amplitude.AutoSize = true;
            this.lb_ai_ch0_amplitude.Location = new System.Drawing.Point(256, 77);
            this.lb_ai_ch0_amplitude.Name = "lb_ai_ch0_amplitude";
            this.lb_ai_ch0_amplitude.Size = new System.Drawing.Size(88, 15);
            this.lb_ai_ch0_amplitude.TabIndex = 26;
            this.lb_ai_ch0_amplitude.Text = "CH0 Amplitude";
            // 
            // tbox_ai_ch0_amplitude
            // 
            this.tbox_ai_ch0_amplitude.Location = new System.Drawing.Point(346, 74);
            this.tbox_ai_ch0_amplitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch0_amplitude.Name = "tbox_ai_ch0_amplitude";
            this.tbox_ai_ch0_amplitude.ReadOnly = true;
            this.tbox_ai_ch0_amplitude.Size = new System.Drawing.Size(112, 23);
            this.tbox_ai_ch0_amplitude.TabIndex = 30;
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 736);
            this.Controls.Add(this.zg_ai_wave_fft);
            this.Controls.Add(this.zg_ai_wave_raw);
            this.Controls.Add(this.gbox_ai_operation);
            this.Controls.Add(this.gbox_device_operation);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frm_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2405 AI Simultaneous";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_main_FormClosed);
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            this.gbox_device_operation.ResumeLayout(false);
            this.gbox_device_operation.PerformLayout();
            this.gbox_ai_operation.ResumeLayout(false);
            this.gbox_ai_sensor_settings.ResumeLayout(false);
            this.gbox_ai_sensor_settings.PerformLayout();
            this.gbox_ai_status.ResumeLayout(false);
            this.gbox_ai_status.PerformLayout();
            this.gbox_ai_settings.ResumeLayout(false);
            this.gbox_ai_settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_device_type;
        private System.Windows.Forms.ComboBox cbox_device_index;
        private System.Windows.Forms.Label lb_device_type;
        private System.Windows.Forms.Label lb_device_index;
        private System.Windows.Forms.GroupBox gbox_device_operation;
        private System.Windows.Forms.Button btn_device_open;
        private System.Windows.Forms.Button btn_device_start;
        private System.Windows.Forms.GroupBox gbox_ai_operation;
        private System.Windows.Forms.GroupBox gbox_ai_settings;
        private System.Windows.Forms.Label lb_ai_sample_rate;
        private System.Windows.Forms.ComboBox cbox_ai_channel_type;
        private System.Windows.Forms.ComboBox cbox_ai_channel_range;
        private System.Windows.Forms.TextBox tbox_ai_sample_rate;
        private System.Windows.Forms.Label lb_ai_channel_type;
        private System.Windows.Forms.Label lb_ai_channel_range;
        private System.Windows.Forms.GroupBox gbox_ai_status;
        private System.Windows.Forms.Label lb_ai_ch0_freqency;
        private System.Windows.Forms.TextBox tbox_ai_ch0_frequency;
        private ZedGraph.ZedGraphControl zg_ai_wave_raw;
        private System.Windows.Forms.TextBox tbox_ai_buf_ready_cnt;
        private ZedGraph.ZedGraphControl zg_ai_wave_fft;
        private System.Windows.Forms.ComboBox cbox_ai_channel_select;
        private System.Windows.Forms.Label lb_ai_channel_select;
        private System.Windows.Forms.ComboBox cbox_ai_trigger_source;
        private System.Windows.Forms.Label lb_ai_trigger_source;
        private System.Windows.Forms.Label lb_ai_ch0_magnitude;
        private System.Windows.Forms.TextBox tbox_ai_ch0_magnitude;
        private System.Windows.Forms.GroupBox gbox_ai_sensor_settings;
        private System.Windows.Forms.TextBox tbox_sensor_ch3_sensitivity;
        private System.Windows.Forms.Label lb_sensor_ch3_sensitivity;
        private System.Windows.Forms.TextBox tbox_sensor_ch1_sensitivity;
        private System.Windows.Forms.Label lb_sensor_ch1_sensitivity;
        private System.Windows.Forms.TextBox tbox_sensor_ch2_sensitivity;
        private System.Windows.Forms.Label lb_sensor_ch2_sensitivity;
        private System.Windows.Forms.TextBox tbox_sensor_ch0_sensitivity;
        private System.Windows.Forms.Label lb_sensor_ch0_sensitivity;
        private System.Windows.Forms.TextBox tbox_ai_ch0_magnitude3;
        private System.Windows.Forms.TextBox tbox_ai_ch0_magnitude2;
        private System.Windows.Forms.TextBox tbox_ai_ch3_magnitude3;
        private System.Windows.Forms.TextBox tbox_ai_ch3_magnitude2;
        private System.Windows.Forms.TextBox tbox_ai_ch3_magnitude;
        private System.Windows.Forms.Label lb_ai_ch3_magnitude;
        private System.Windows.Forms.Label lb_ai_ch3_freqency;
        private System.Windows.Forms.TextBox tbox_ai_ch3_frequency;
        private System.Windows.Forms.TextBox tbox_ai_ch2_magnitude3;
        private System.Windows.Forms.TextBox tbox_ai_ch2_magnitude2;
        private System.Windows.Forms.TextBox tbox_ai_ch2_magnitude;
        private System.Windows.Forms.Label lb_ai_ch2_magnitude;
        private System.Windows.Forms.Label lb_ai_ch2_freqency;
        private System.Windows.Forms.TextBox tbox_ai_ch2_frequency;
        private System.Windows.Forms.TextBox tbox_ai_ch1_magnitude3;
        private System.Windows.Forms.TextBox tbox_ai_ch1_magnitude2;
        private System.Windows.Forms.TextBox tbox_ai_ch1_magnitude;
        private System.Windows.Forms.Label lb_ai_ch1_magnitude;
        private System.Windows.Forms.Label lb_ai_ch1_freqency;
        private System.Windows.Forms.TextBox tbox_ai_ch1_frequency;
        private System.Windows.Forms.Button btn_data_logger;
        private System.Windows.Forms.ComboBox cbox_ai_sensor_settings;
        private System.Windows.Forms.Label lb_ai_sensor_settings;
        private System.Windows.Forms.ComboBox cbox_ai_ch_magnitude_unit;
        private System.Windows.Forms.Label lb_ai_ch_magnitude_unit;
        private System.Windows.Forms.Label lb_ai_ch3_amplitude;
        private System.Windows.Forms.TextBox tbox_ai_ch3_amplitude;
        private System.Windows.Forms.Label lb_ai_ch2_amplitude;
        private System.Windows.Forms.TextBox tbox_ai_ch2_amplitude;
        private System.Windows.Forms.Label lb_ai_ch1_amplitude;
        private System.Windows.Forms.TextBox tbox_ai_ch1_amplitude;
        private System.Windows.Forms.Label lb_ai_ch0_amplitude;
        private System.Windows.Forms.TextBox tbox_ai_ch0_amplitude;
    }
}

