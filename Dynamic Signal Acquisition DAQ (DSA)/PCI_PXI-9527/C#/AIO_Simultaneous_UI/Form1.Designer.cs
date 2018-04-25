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
            this.tbox_ai_buf_ready_cnt = new System.Windows.Forms.TextBox();
            this.tbox_ao_buf_ready_cnt = new System.Windows.Forms.TextBox();
            this.btn_device_start = new System.Windows.Forms.Button();
            this.cbox_ai_enabled = new System.Windows.Forms.CheckBox();
            this.cbox_ao_enabled = new System.Windows.Forms.CheckBox();
            this.btn_device_open = new System.Windows.Forms.Button();
            this.gbox_ao_operation = new System.Windows.Forms.GroupBox();
            this.gbox_ao_sine_settings = new System.Windows.Forms.GroupBox();
            this.tbox_ao_sine_amplitude = new System.Windows.Forms.TextBox();
            this.lb_ao_sine_freqency = new System.Windows.Forms.Label();
            this.tbox_ao_sine_freqency = new System.Windows.Forms.TextBox();
            this.lb_ao_sine_amplitude = new System.Windows.Forms.Label();
            this.gbox_ao_settings = new System.Windows.Forms.GroupBox();
            this.cbox_ao_channel_type = new System.Windows.Forms.ComboBox();
            this.cbox_ao_channel_range = new System.Windows.Forms.ComboBox();
            this.lb_ao_channel_type = new System.Windows.Forms.Label();
            this.tbox_ao_sample_rate = new System.Windows.Forms.TextBox();
            this.lb_ao_sample_rate = new System.Windows.Forms.Label();
            this.lb_ao_channel_range = new System.Windows.Forms.Label();
            this.gbox_ai_operation = new System.Windows.Forms.GroupBox();
            this.gbox_ai_status = new System.Windows.Forms.GroupBox();
            this.lb_ai_ch0_freqency = new System.Windows.Forms.Label();
            this.tbox_ai_ch0_frequency = new System.Windows.Forms.TextBox();
            this.gbox_ai_settings = new System.Windows.Forms.GroupBox();
            this.cbox_ai_channel_type = new System.Windows.Forms.ComboBox();
            this.cbox_ai_channel_range = new System.Windows.Forms.ComboBox();
            this.tbox_ai_sample_rate = new System.Windows.Forms.TextBox();
            this.lb_ai_channel_type = new System.Windows.Forms.Label();
            this.lb_ai_channel_range = new System.Windows.Forms.Label();
            this.lb_ai_sample_rate = new System.Windows.Forms.Label();
            this.zg_ai_wave_raw = new ZedGraph.ZedGraphControl();
            this.zg_ai_wave_fft = new ZedGraph.ZedGraphControl();
            this.lb_ai_ch1_freqency = new System.Windows.Forms.Label();
            this.tbox_ai_ch1_frequency = new System.Windows.Forms.TextBox();
            this.lb_ao_channel_select = new System.Windows.Forms.Label();
            this.cbox_ao_channel_select = new System.Windows.Forms.ComboBox();
            this.cbox_ai_channel_select = new System.Windows.Forms.ComboBox();
            this.lb_ai_channel_select = new System.Windows.Forms.Label();
            this.lb_ao_trigger_source = new System.Windows.Forms.Label();
            this.cbox_ao_trigger_source = new System.Windows.Forms.ComboBox();
            this.cbox_ai_trigger_source = new System.Windows.Forms.ComboBox();
            this.lb_ai_trigger_source = new System.Windows.Forms.Label();
            this.lb_ai_ch0_magnitude = new System.Windows.Forms.Label();
            this.tbox_ai_ch0_magnitude = new System.Windows.Forms.TextBox();
            this.tbox_ai_ch1_magnitude = new System.Windows.Forms.TextBox();
            this.lb_ai_ch1_magnitude = new System.Windows.Forms.Label();
            this.gbox_device_operation.SuspendLayout();
            this.gbox_ao_operation.SuspendLayout();
            this.gbox_ao_sine_settings.SuspendLayout();
            this.gbox_ao_settings.SuspendLayout();
            this.gbox_ai_operation.SuspendLayout();
            this.gbox_ai_status.SuspendLayout();
            this.gbox_ai_settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbox_device_type
            // 
            this.cbox_device_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_device_type.FormattingEnabled = true;
            this.cbox_device_type.Items.AddRange(new object[] {
            "PCI-9527",
            "PXI-9527"});
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
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbox_device_index.Location = new System.Drawing.Point(93, 68);
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
            this.lb_device_index.Location = new System.Drawing.Point(8, 72);
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
            this.gbox_device_operation.Controls.Add(this.tbox_ai_buf_ready_cnt);
            this.gbox_device_operation.Controls.Add(this.tbox_ao_buf_ready_cnt);
            this.gbox_device_operation.Controls.Add(this.btn_device_start);
            this.gbox_device_operation.Controls.Add(this.cbox_ai_enabled);
            this.gbox_device_operation.Controls.Add(this.cbox_ao_enabled);
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
            // tbox_ai_buf_ready_cnt
            // 
            this.tbox_ai_buf_ready_cnt.Location = new System.Drawing.Point(748, 68);
            this.tbox_ai_buf_ready_cnt.Name = "tbox_ai_buf_ready_cnt";
            this.tbox_ai_buf_ready_cnt.ReadOnly = true;
            this.tbox_ai_buf_ready_cnt.Size = new System.Drawing.Size(100, 23);
            this.tbox_ai_buf_ready_cnt.TabIndex = 9;
            this.tbox_ai_buf_ready_cnt.TabStop = false;
            this.tbox_ai_buf_ready_cnt.Visible = false;
            // 
            // tbox_ao_buf_ready_cnt
            // 
            this.tbox_ao_buf_ready_cnt.Location = new System.Drawing.Point(748, 32);
            this.tbox_ao_buf_ready_cnt.Name = "tbox_ao_buf_ready_cnt";
            this.tbox_ao_buf_ready_cnt.ReadOnly = true;
            this.tbox_ao_buf_ready_cnt.Size = new System.Drawing.Size(100, 23);
            this.tbox_ao_buf_ready_cnt.TabIndex = 8;
            this.tbox_ao_buf_ready_cnt.TabStop = false;
            this.tbox_ao_buf_ready_cnt.Visible = false;
            // 
            // btn_device_start
            // 
            this.btn_device_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_device_start.Enabled = false;
            this.btn_device_start.Location = new System.Drawing.Point(854, 64);
            this.btn_device_start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_device_start.Name = "btn_device_start";
            this.btn_device_start.Size = new System.Drawing.Size(120, 29);
            this.btn_device_start.TabIndex = 7;
            this.btn_device_start.Text = "Start Operation";
            this.btn_device_start.UseVisualStyleBackColor = true;
            this.btn_device_start.Click += new System.EventHandler(this.btn_device_start_Click);
            // 
            // cbox_ai_enabled
            // 
            this.cbox_ai_enabled.AutoSize = true;
            this.cbox_ai_enabled.Checked = true;
            this.cbox_ai_enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_ai_enabled.Location = new System.Drawing.Point(264, 70);
            this.cbox_ai_enabled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbox_ai_enabled.Name = "cbox_ai_enabled";
            this.cbox_ai_enabled.Size = new System.Drawing.Size(135, 19);
            this.cbox_ai_enabled.TabIndex = 5;
            this.cbox_ai_enabled.Text = "Enable AI Operation";
            this.cbox_ai_enabled.UseVisualStyleBackColor = true;
            this.cbox_ai_enabled.CheckedChanged += new System.EventHandler(this.cbox_ai_enabled_CheckedChanged);
            // 
            // cbox_ao_enabled
            // 
            this.cbox_ao_enabled.AutoSize = true;
            this.cbox_ao_enabled.Checked = true;
            this.cbox_ao_enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_ao_enabled.Location = new System.Drawing.Point(264, 34);
            this.cbox_ao_enabled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbox_ao_enabled.Name = "cbox_ao_enabled";
            this.cbox_ao_enabled.Size = new System.Drawing.Size(135, 19);
            this.cbox_ao_enabled.TabIndex = 4;
            this.cbox_ao_enabled.Text = "Enable AO Opeation";
            this.cbox_ao_enabled.UseVisualStyleBackColor = true;
            this.cbox_ao_enabled.CheckedChanged += new System.EventHandler(this.cbox_ao_enabled_CheckedChanged);
            // 
            // btn_device_open
            // 
            this.btn_device_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_device_open.Location = new System.Drawing.Point(854, 28);
            this.btn_device_open.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_device_open.Name = "btn_device_open";
            this.btn_device_open.Size = new System.Drawing.Size(120, 29);
            this.btn_device_open.TabIndex = 6;
            this.btn_device_open.Text = "Open Device";
            this.btn_device_open.UseVisualStyleBackColor = true;
            this.btn_device_open.Click += new System.EventHandler(this.btn_device_open_Click);
            // 
            // gbox_ao_operation
            // 
            this.gbox_ao_operation.Controls.Add(this.gbox_ao_sine_settings);
            this.gbox_ao_operation.Controls.Add(this.gbox_ao_settings);
            this.gbox_ao_operation.Enabled = false;
            this.gbox_ao_operation.Location = new System.Drawing.Point(16, 124);
            this.gbox_ao_operation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbox_ao_operation.Name = "gbox_ao_operation";
            this.gbox_ao_operation.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbox_ao_operation.Size = new System.Drawing.Size(486, 306);
            this.gbox_ao_operation.TabIndex = 1;
            this.gbox_ao_operation.TabStop = false;
            this.gbox_ao_operation.Text = "AO Operation";
            this.gbox_ao_operation.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // gbox_ao_sine_settings
            // 
            this.gbox_ao_sine_settings.Controls.Add(this.tbox_ao_sine_amplitude);
            this.gbox_ao_sine_settings.Controls.Add(this.lb_ao_sine_freqency);
            this.gbox_ao_sine_settings.Controls.Add(this.tbox_ao_sine_freqency);
            this.gbox_ao_sine_settings.Controls.Add(this.lb_ao_sine_amplitude);
            this.gbox_ao_sine_settings.Location = new System.Drawing.Point(8, 174);
            this.gbox_ao_sine_settings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbox_ao_sine_settings.Name = "gbox_ao_sine_settings";
            this.gbox_ao_sine_settings.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbox_ao_sine_settings.Size = new System.Drawing.Size(468, 124);
            this.gbox_ao_sine_settings.TabIndex = 1;
            this.gbox_ao_sine_settings.TabStop = false;
            this.gbox_ao_sine_settings.Text = "AO Sine Wave Settings";
            this.gbox_ao_sine_settings.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_ao_sine_amplitude
            // 
            this.tbox_ao_sine_amplitude.Location = new System.Drawing.Point(100, 69);
            this.tbox_ao_sine_amplitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ao_sine_amplitude.Name = "tbox_ao_sine_amplitude";
            this.tbox_ao_sine_amplitude.Size = new System.Drawing.Size(123, 23);
            this.tbox_ao_sine_amplitude.TabIndex = 3;
            this.tbox_ao_sine_amplitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_ao_sine_amplitude_KeyDown);
            this.tbox_ao_sine_amplitude.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_ao_sine_amplitude_Validating);
            // 
            // lb_ao_sine_freqency
            // 
            this.lb_ao_sine_freqency.AutoSize = true;
            this.lb_ao_sine_freqency.Location = new System.Drawing.Point(8, 36);
            this.lb_ao_sine_freqency.Name = "lb_ao_sine_freqency";
            this.lb_ao_sine_freqency.Size = new System.Drawing.Size(87, 15);
            this.lb_ao_sine_freqency.TabIndex = 0;
            this.lb_ao_sine_freqency.Text = "Frequency (Hz)";
            this.lb_ao_sine_freqency.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_ao_sine_freqency
            // 
            this.tbox_ao_sine_freqency.Location = new System.Drawing.Point(100, 33);
            this.tbox_ao_sine_freqency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ao_sine_freqency.Name = "tbox_ao_sine_freqency";
            this.tbox_ao_sine_freqency.Size = new System.Drawing.Size(123, 23);
            this.tbox_ao_sine_freqency.TabIndex = 2;
            this.tbox_ao_sine_freqency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_ao_sine_freqency_KeyDown);
            this.tbox_ao_sine_freqency.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_ao_sine_freqency_Validating);
            // 
            // lb_ao_sine_amplitude
            // 
            this.lb_ao_sine_amplitude.AutoSize = true;
            this.lb_ao_sine_amplitude.Location = new System.Drawing.Point(8, 72);
            this.lb_ao_sine_amplitude.Name = "lb_ao_sine_amplitude";
            this.lb_ao_sine_amplitude.Size = new System.Drawing.Size(95, 15);
            this.lb_ao_sine_amplitude.TabIndex = 1;
            this.lb_ao_sine_amplitude.Text = "Amplitude (Vpp)";
            this.lb_ao_sine_amplitude.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // gbox_ao_settings
            // 
            this.gbox_ao_settings.Controls.Add(this.cbox_ao_trigger_source);
            this.gbox_ao_settings.Controls.Add(this.lb_ao_trigger_source);
            this.gbox_ao_settings.Controls.Add(this.cbox_ao_channel_select);
            this.gbox_ao_settings.Controls.Add(this.lb_ao_channel_select);
            this.gbox_ao_settings.Controls.Add(this.cbox_ao_channel_type);
            this.gbox_ao_settings.Controls.Add(this.cbox_ao_channel_range);
            this.gbox_ao_settings.Controls.Add(this.lb_ao_channel_type);
            this.gbox_ao_settings.Controls.Add(this.tbox_ao_sample_rate);
            this.gbox_ao_settings.Controls.Add(this.lb_ao_sample_rate);
            this.gbox_ao_settings.Controls.Add(this.lb_ao_channel_range);
            this.gbox_ao_settings.Location = new System.Drawing.Point(8, 24);
            this.gbox_ao_settings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbox_ao_settings.Name = "gbox_ao_settings";
            this.gbox_ao_settings.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbox_ao_settings.Size = new System.Drawing.Size(468, 142);
            this.gbox_ao_settings.TabIndex = 0;
            this.gbox_ao_settings.TabStop = false;
            this.gbox_ao_settings.Text = "AO Settings";
            this.gbox_ao_settings.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // cbox_ao_channel_type
            // 
            this.cbox_ao_channel_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ao_channel_type.FormattingEnabled = true;
            this.cbox_ao_channel_type.Items.AddRange(new object[] {
            "Differential",
            "Pseudo-Differential"});
            this.cbox_ao_channel_type.Location = new System.Drawing.Point(100, 105);
            this.cbox_ao_channel_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbox_ao_channel_type.Name = "cbox_ao_channel_type";
            this.cbox_ao_channel_type.Size = new System.Drawing.Size(359, 23);
            this.cbox_ao_channel_type.TabIndex = 7;
            this.cbox_ao_channel_type.SelectedIndexChanged += new System.EventHandler(this.cbox_ao_channel_type_SelectedIndexChanged);
            this.cbox_ao_channel_type.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_ao_channel_type.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // cbox_ao_channel_range
            // 
            this.cbox_ao_channel_range.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ao_channel_range.FormattingEnabled = true;
            this.cbox_ao_channel_range.Items.AddRange(new object[] {
            "-10 ~ 10 V",
            "-1 ~ 1 V",
            "-100 ~ 100 mV"});
            this.cbox_ao_channel_range.Location = new System.Drawing.Point(100, 69);
            this.cbox_ao_channel_range.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbox_ao_channel_range.Name = "cbox_ao_channel_range";
            this.cbox_ao_channel_range.Size = new System.Drawing.Size(123, 23);
            this.cbox_ao_channel_range.TabIndex = 6;
            this.cbox_ao_channel_range.SelectedIndexChanged += new System.EventHandler(this.cbox_ao_channel_range_SelectedIndexChanged);
            this.cbox_ao_channel_range.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_ao_channel_range.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // lb_ao_channel_type
            // 
            this.lb_ao_channel_type.AutoSize = true;
            this.lb_ao_channel_type.Location = new System.Drawing.Point(8, 108);
            this.lb_ao_channel_type.Name = "lb_ao_channel_type";
            this.lb_ao_channel_type.Size = new System.Drawing.Size(79, 15);
            this.lb_ao_channel_type.TabIndex = 2;
            this.lb_ao_channel_type.Text = "Channel Type";
            this.lb_ao_channel_type.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_ao_sample_rate
            // 
            this.tbox_ao_sample_rate.Location = new System.Drawing.Point(336, 69);
            this.tbox_ao_sample_rate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ao_sample_rate.Name = "tbox_ao_sample_rate";
            this.tbox_ao_sample_rate.Size = new System.Drawing.Size(123, 23);
            this.tbox_ao_sample_rate.TabIndex = 9;
            this.tbox_ao_sample_rate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_ao_sample_rate_KeyDown);
            this.tbox_ao_sample_rate.Validating += new System.ComponentModel.CancelEventHandler(this.tbox_ao_sample_rate_Validating);
            this.tbox_ao_sample_rate.Validated += new System.EventHandler(this.tbox_ao_sample_rate_Validated);
            // 
            // lb_ao_sample_rate
            // 
            this.lb_ao_sample_rate.AutoSize = true;
            this.lb_ao_sample_rate.Location = new System.Drawing.Point(236, 72);
            this.lb_ao_sample_rate.Name = "lb_ao_sample_rate";
            this.lb_ao_sample_rate.Size = new System.Drawing.Size(98, 15);
            this.lb_ao_sample_rate.TabIndex = 4;
            this.lb_ao_sample_rate.Text = "Sample Rate (Hz)";
            this.lb_ao_sample_rate.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_ao_channel_range
            // 
            this.lb_ao_channel_range.AutoSize = true;
            this.lb_ao_channel_range.Location = new System.Drawing.Point(8, 72);
            this.lb_ao_channel_range.Name = "lb_ao_channel_range";
            this.lb_ao_channel_range.Size = new System.Drawing.Size(88, 15);
            this.lb_ao_channel_range.TabIndex = 1;
            this.lb_ao_channel_range.Text = "Channel Range";
            this.lb_ao_channel_range.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // gbox_ai_operation
            // 
            this.gbox_ai_operation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_ai_operation.Controls.Add(this.gbox_ai_status);
            this.gbox_ai_operation.Controls.Add(this.gbox_ai_settings);
            this.gbox_ai_operation.Enabled = false;
            this.gbox_ai_operation.Location = new System.Drawing.Point(514, 124);
            this.gbox_ai_operation.Name = "gbox_ai_operation";
            this.gbox_ai_operation.Size = new System.Drawing.Size(486, 306);
            this.gbox_ai_operation.TabIndex = 2;
            this.gbox_ai_operation.TabStop = false;
            this.gbox_ai_operation.Text = "AI Operation";
            this.gbox_ai_operation.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // gbox_ai_status
            // 
            this.gbox_ai_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch1_magnitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch1_magnitude);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch0_magnitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch0_magnitude);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch1_freqency);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch1_frequency);
            this.gbox_ai_status.Controls.Add(this.lb_ai_ch0_freqency);
            this.gbox_ai_status.Controls.Add(this.tbox_ai_ch0_frequency);
            this.gbox_ai_status.Location = new System.Drawing.Point(8, 174);
            this.gbox_ai_status.Name = "gbox_ai_status";
            this.gbox_ai_status.Size = new System.Drawing.Size(468, 124);
            this.gbox_ai_status.TabIndex = 1;
            this.gbox_ai_status.TabStop = false;
            this.gbox_ai_status.Text = "AI status";
            this.gbox_ai_status.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_ai_ch0_freqency
            // 
            this.lb_ai_ch0_freqency.AutoSize = true;
            this.lb_ai_ch0_freqency.Location = new System.Drawing.Point(8, 36);
            this.lb_ai_ch0_freqency.Name = "lb_ai_ch0_freqency";
            this.lb_ai_ch0_freqency.Size = new System.Drawing.Size(112, 15);
            this.lb_ai_ch0_freqency.TabIndex = 0;
            this.lb_ai_ch0_freqency.Text = "CH0 Frequency (Hz)";
            this.lb_ai_ch0_freqency.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // tbox_ai_ch0_frequency
            // 
            this.tbox_ai_ch0_frequency.Location = new System.Drawing.Point(124, 33);
            this.tbox_ai_ch0_frequency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch0_frequency.Name = "tbox_ai_ch0_frequency";
            this.tbox_ai_ch0_frequency.ReadOnly = true;
            this.tbox_ai_ch0_frequency.Size = new System.Drawing.Size(99, 23);
            this.tbox_ai_ch0_frequency.TabIndex = 4;
            // 
            // gbox_ai_settings
            // 
            this.gbox_ai_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.gbox_ai_settings.Location = new System.Drawing.Point(8, 24);
            this.gbox_ai_settings.Name = "gbox_ai_settings";
            this.gbox_ai_settings.Size = new System.Drawing.Size(468, 142);
            this.gbox_ai_settings.TabIndex = 0;
            this.gbox_ai_settings.TabStop = false;
            this.gbox_ai_settings.Text = "AI Settings";
            this.gbox_ai_settings.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // cbox_ai_channel_type
            // 
            this.cbox_ai_channel_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ai_channel_type.FormattingEnabled = true;
            this.cbox_ai_channel_type.Items.AddRange(new object[] {
            "Differential with DC Coupling",
            "Differential with AC Coupling",
            "Differential with IEPE Enable",
            "Pseudo-Diff with DC Coupling",
            "Pseudo-Diff with AC Coupling",
            "Pseudo-Diff with IEPE Enable"});
            this.cbox_ai_channel_type.Location = new System.Drawing.Point(100, 105);
            this.cbox_ai_channel_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbox_ai_channel_type.Name = "cbox_ai_channel_type";
            this.cbox_ai_channel_type.Size = new System.Drawing.Size(359, 23);
            this.cbox_ai_channel_type.TabIndex = 7;
            this.cbox_ai_channel_type.SelectedIndexChanged += new System.EventHandler(this.cbox_ai_channel_type_SelectedIndexChanged);
            this.cbox_ai_channel_type.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_ai_channel_type.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // cbox_ai_channel_range
            // 
            this.cbox_ai_channel_range.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ai_channel_range.FormattingEnabled = true;
            this.cbox_ai_channel_range.Items.AddRange(new object[] {
            "-40 ~ 40 V",
            "-10 ~ 10 V",
            "-3.16 ~ 3.16 V",
            "-1 ~ 1 V",
            "-316 ~ 316 mV"});
            this.cbox_ai_channel_range.Location = new System.Drawing.Point(100, 69);
            this.cbox_ai_channel_range.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbox_ai_channel_range.Name = "cbox_ai_channel_range";
            this.cbox_ai_channel_range.Size = new System.Drawing.Size(123, 23);
            this.cbox_ai_channel_range.TabIndex = 6;
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
            this.tbox_ai_sample_rate.TabIndex = 9;
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
            this.lb_ai_channel_type.TabIndex = 2;
            this.lb_ai_channel_type.Text = "Channel Type";
            this.lb_ai_channel_type.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_ai_channel_range
            // 
            this.lb_ai_channel_range.AutoSize = true;
            this.lb_ai_channel_range.Location = new System.Drawing.Point(8, 72);
            this.lb_ai_channel_range.Name = "lb_ai_channel_range";
            this.lb_ai_channel_range.Size = new System.Drawing.Size(88, 15);
            this.lb_ai_channel_range.TabIndex = 1;
            this.lb_ai_channel_range.Text = "Channel Range";
            this.lb_ai_channel_range.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // lb_ai_sample_rate
            // 
            this.lb_ai_sample_rate.AutoSize = true;
            this.lb_ai_sample_rate.Location = new System.Drawing.Point(236, 72);
            this.lb_ai_sample_rate.Name = "lb_ai_sample_rate";
            this.lb_ai_sample_rate.Size = new System.Drawing.Size(98, 15);
            this.lb_ai_sample_rate.TabIndex = 4;
            this.lb_ai_sample_rate.Text = "Sample Rate (Hz)";
            this.lb_ai_sample_rate.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            // 
            // zg_ai_wave_raw
            // 
            this.zg_ai_wave_raw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zg_ai_wave_raw.Enabled = false;
            this.zg_ai_wave_raw.IsEnableVPan = false;
            this.zg_ai_wave_raw.IsEnableVZoom = false;
            this.zg_ai_wave_raw.IsEnableWheelZoom = false;
            this.zg_ai_wave_raw.IsPrintFillPage = false;
            this.zg_ai_wave_raw.IsPrintKeepAspectRatio = false;
            this.zg_ai_wave_raw.IsPrintScaleAll = false;
            this.zg_ai_wave_raw.IsShowCopyMessage = false;
            this.zg_ai_wave_raw.Location = new System.Drawing.Point(16, 438);
            this.zg_ai_wave_raw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zg_ai_wave_raw.Name = "zg_ai_wave_raw";
            this.zg_ai_wave_raw.ScrollGrace = 0D;
            this.zg_ai_wave_raw.ScrollMaxX = 0D;
            this.zg_ai_wave_raw.ScrollMaxY = 0D;
            this.zg_ai_wave_raw.ScrollMaxY2 = 0D;
            this.zg_ai_wave_raw.ScrollMinX = 0D;
            this.zg_ai_wave_raw.ScrollMinY = 0D;
            this.zg_ai_wave_raw.ScrollMinY2 = 0D;
            this.zg_ai_wave_raw.Size = new System.Drawing.Size(486, 285);
            this.zg_ai_wave_raw.TabIndex = 3;
            // 
            // zg_ai_wave_fft
            // 
            this.zg_ai_wave_fft.Enabled = false;
            this.zg_ai_wave_fft.IsEnableVPan = false;
            this.zg_ai_wave_fft.IsEnableVZoom = false;
            this.zg_ai_wave_fft.IsEnableWheelZoom = false;
            this.zg_ai_wave_fft.IsPrintFillPage = false;
            this.zg_ai_wave_fft.IsPrintKeepAspectRatio = false;
            this.zg_ai_wave_fft.IsPrintScaleAll = false;
            this.zg_ai_wave_fft.IsShowCopyMessage = false;
            this.zg_ai_wave_fft.Location = new System.Drawing.Point(514, 438);
            this.zg_ai_wave_fft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zg_ai_wave_fft.Name = "zg_ai_wave_fft";
            this.zg_ai_wave_fft.ScrollGrace = 0D;
            this.zg_ai_wave_fft.ScrollMaxX = 0D;
            this.zg_ai_wave_fft.ScrollMaxY = 0D;
            this.zg_ai_wave_fft.ScrollMaxY2 = 0D;
            this.zg_ai_wave_fft.ScrollMinX = 0D;
            this.zg_ai_wave_fft.ScrollMinY = 0D;
            this.zg_ai_wave_fft.ScrollMinY2 = 0D;
            this.zg_ai_wave_fft.Size = new System.Drawing.Size(486, 285);
            this.zg_ai_wave_fft.TabIndex = 4;
            // 
            // lb_ai_ch1_freqency
            // 
            this.lb_ai_ch1_freqency.AutoSize = true;
            this.lb_ai_ch1_freqency.Location = new System.Drawing.Point(8, 72);
            this.lb_ai_ch1_freqency.Name = "lb_ai_ch1_freqency";
            this.lb_ai_ch1_freqency.Size = new System.Drawing.Size(112, 15);
            this.lb_ai_ch1_freqency.TabIndex = 1;
            this.lb_ai_ch1_freqency.Text = "CH1 Frequency (Hz)";
            // 
            // tbox_ai_ch1_frequency
            // 
            this.tbox_ai_ch1_frequency.Location = new System.Drawing.Point(124, 69);
            this.tbox_ai_ch1_frequency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch1_frequency.Name = "tbox_ai_ch1_frequency";
            this.tbox_ai_ch1_frequency.ReadOnly = true;
            this.tbox_ai_ch1_frequency.Size = new System.Drawing.Size(99, 23);
            this.tbox_ai_ch1_frequency.TabIndex = 5;
            // 
            // lb_ao_channel_select
            // 
            this.lb_ao_channel_select.AutoSize = true;
            this.lb_ao_channel_select.Location = new System.Drawing.Point(8, 36);
            this.lb_ao_channel_select.Name = "lb_ao_channel_select";
            this.lb_ao_channel_select.Size = new System.Drawing.Size(87, 15);
            this.lb_ao_channel_select.TabIndex = 0;
            this.lb_ao_channel_select.Text = "Channel Select";
            // 
            // cbox_ao_channel_select
            // 
            this.cbox_ao_channel_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ao_channel_select.FormattingEnabled = true;
            this.cbox_ao_channel_select.Items.AddRange(new object[] {
            "CH 0",
            "CH 1",
            "CH 0 & CH1"});
            this.cbox_ao_channel_select.Location = new System.Drawing.Point(100, 33);
            this.cbox_ao_channel_select.Name = "cbox_ao_channel_select";
            this.cbox_ao_channel_select.Size = new System.Drawing.Size(123, 23);
            this.cbox_ao_channel_select.TabIndex = 5;
            this.cbox_ao_channel_select.SelectedIndexChanged += new System.EventHandler(this.cbox_ao_channel_select_SelectedIndexChanged);
            this.cbox_ao_channel_select.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_ao_channel_select.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // cbox_ai_channel_select
            // 
            this.cbox_ai_channel_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ai_channel_select.FormattingEnabled = true;
            this.cbox_ai_channel_select.Items.AddRange(new object[] {
            "CH 0",
            "CH 1",
            "CH 0 & CH1"});
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
            // 
            // lb_ao_trigger_source
            // 
            this.lb_ao_trigger_source.AutoSize = true;
            this.lb_ao_trigger_source.Location = new System.Drawing.Point(236, 36);
            this.lb_ao_trigger_source.Name = "lb_ao_trigger_source";
            this.lb_ao_trigger_source.Size = new System.Drawing.Size(84, 15);
            this.lb_ao_trigger_source.TabIndex = 3;
            this.lb_ao_trigger_source.Text = "Trigger Source";
            // 
            // cbox_ao_trigger_source
            // 
            this.cbox_ao_trigger_source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ao_trigger_source.Enabled = false;
            this.cbox_ao_trigger_source.FormattingEnabled = true;
            this.cbox_ao_trigger_source.Items.AddRange(new object[] {
            "Software",
            "External Digital"});
            this.cbox_ao_trigger_source.Location = new System.Drawing.Point(336, 33);
            this.cbox_ao_trigger_source.Name = "cbox_ao_trigger_source";
            this.cbox_ao_trigger_source.Size = new System.Drawing.Size(123, 23);
            this.cbox_ao_trigger_source.TabIndex = 8;
            this.cbox_ao_trigger_source.SelectedIndexChanged += new System.EventHandler(this.cbox_ao_trigger_source_SelectedIndexChanged);
            this.cbox_ao_trigger_source.MouseLeave += new System.EventHandler(this.cbox_xxxxx_MouseLeave);
            this.cbox_ao_trigger_source.MouseHover += new System.EventHandler(this.cbox_xxxxx_MouseHover);
            // 
            // cbox_ai_trigger_source
            // 
            this.cbox_ai_trigger_source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ai_trigger_source.Enabled = false;
            this.cbox_ai_trigger_source.FormattingEnabled = true;
            this.cbox_ai_trigger_source.Items.AddRange(new object[] {
            "Software",
            "External Digital"});
            this.cbox_ai_trigger_source.Location = new System.Drawing.Point(336, 33);
            this.cbox_ai_trigger_source.Name = "cbox_ai_trigger_source";
            this.cbox_ai_trigger_source.Size = new System.Drawing.Size(123, 23);
            this.cbox_ai_trigger_source.TabIndex = 8;
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
            this.lb_ai_trigger_source.TabIndex = 3;
            this.lb_ai_trigger_source.Text = "Trigger Source";
            // 
            // lb_ai_ch0_magnitude
            // 
            this.lb_ai_ch0_magnitude.AutoSize = true;
            this.lb_ai_ch0_magnitude.Location = new System.Drawing.Point(236, 36);
            this.lb_ai_ch0_magnitude.Name = "lb_ai_ch0_magnitude";
            this.lb_ai_ch0_magnitude.Size = new System.Drawing.Size(116, 15);
            this.lb_ai_ch0_magnitude.TabIndex = 2;
            this.lb_ai_ch0_magnitude.Text = "CH0 Magnitude (dB)";
            // 
            // tbox_ai_ch0_magnitude
            // 
            this.tbox_ai_ch0_magnitude.Location = new System.Drawing.Point(356, 33);
            this.tbox_ai_ch0_magnitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch0_magnitude.Name = "tbox_ai_ch0_magnitude";
            this.tbox_ai_ch0_magnitude.ReadOnly = true;
            this.tbox_ai_ch0_magnitude.Size = new System.Drawing.Size(103, 23);
            this.tbox_ai_ch0_magnitude.TabIndex = 6;
            // 
            // tbox_ai_ch1_magnitude
            // 
            this.tbox_ai_ch1_magnitude.Location = new System.Drawing.Point(356, 69);
            this.tbox_ai_ch1_magnitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbox_ai_ch1_magnitude.Name = "tbox_ai_ch1_magnitude";
            this.tbox_ai_ch1_magnitude.ReadOnly = true;
            this.tbox_ai_ch1_magnitude.Size = new System.Drawing.Size(103, 23);
            this.tbox_ai_ch1_magnitude.TabIndex = 7;
            // 
            // lb_ai_ch1_magnitude
            // 
            this.lb_ai_ch1_magnitude.AutoSize = true;
            this.lb_ai_ch1_magnitude.Location = new System.Drawing.Point(236, 72);
            this.lb_ai_ch1_magnitude.Name = "lb_ai_ch1_magnitude";
            this.lb_ai_ch1_magnitude.Size = new System.Drawing.Size(116, 15);
            this.lb_ai_ch1_magnitude.TabIndex = 3;
            this.lb_ai_ch1_magnitude.Text = "CH1 Magnitude (dB)";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 736);
            this.Controls.Add(this.zg_ai_wave_fft);
            this.Controls.Add(this.zg_ai_wave_raw);
            this.Controls.Add(this.gbox_ai_operation);
            this.Controls.Add(this.gbox_ao_operation);
            this.Controls.Add(this.gbox_device_operation);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frm_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "9527 AIO Simultaneous";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_main_FormClosed);
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.MouseCaptureChanged += new System.EventHandler(this.frm_xxxxx_MouseCaptureChanged);
            this.gbox_device_operation.ResumeLayout(false);
            this.gbox_device_operation.PerformLayout();
            this.gbox_ao_operation.ResumeLayout(false);
            this.gbox_ao_sine_settings.ResumeLayout(false);
            this.gbox_ao_sine_settings.PerformLayout();
            this.gbox_ao_settings.ResumeLayout(false);
            this.gbox_ao_settings.PerformLayout();
            this.gbox_ai_operation.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gbox_ao_operation;
        private System.Windows.Forms.GroupBox gbox_ao_sine_settings;
        private System.Windows.Forms.GroupBox gbox_ao_settings;
        private System.Windows.Forms.ComboBox cbox_ao_channel_type;
        private System.Windows.Forms.ComboBox cbox_ao_channel_range;
        private System.Windows.Forms.Label lb_ao_channel_type;
        private System.Windows.Forms.TextBox tbox_ao_sample_rate;
        private System.Windows.Forms.Label lb_ao_sample_rate;
        private System.Windows.Forms.Label lb_ao_channel_range;
        private System.Windows.Forms.Label lb_ao_sine_amplitude;
        private System.Windows.Forms.Label lb_ao_sine_freqency;
        private System.Windows.Forms.TextBox tbox_ao_sine_amplitude;
        private System.Windows.Forms.TextBox tbox_ao_sine_freqency;
        private System.Windows.Forms.CheckBox cbox_ai_enabled;
        private System.Windows.Forms.CheckBox cbox_ao_enabled;
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
        private System.Windows.Forms.TextBox tbox_ao_buf_ready_cnt;
        private ZedGraph.ZedGraphControl zg_ai_wave_fft;
        private System.Windows.Forms.Label lb_ai_ch1_freqency;
        private System.Windows.Forms.TextBox tbox_ai_ch1_frequency;
        private System.Windows.Forms.Label lb_ao_channel_select;
        private System.Windows.Forms.ComboBox cbox_ao_channel_select;
        private System.Windows.Forms.ComboBox cbox_ai_channel_select;
        private System.Windows.Forms.Label lb_ai_channel_select;
        private System.Windows.Forms.ComboBox cbox_ao_trigger_source;
        private System.Windows.Forms.Label lb_ao_trigger_source;
        private System.Windows.Forms.ComboBox cbox_ai_trigger_source;
        private System.Windows.Forms.Label lb_ai_trigger_source;
        private System.Windows.Forms.Label lb_ai_ch0_magnitude;
        private System.Windows.Forms.TextBox tbox_ai_ch1_magnitude;
        private System.Windows.Forms.Label lb_ai_ch1_magnitude;
        private System.Windows.Forms.TextBox tbox_ai_ch0_magnitude;
    }
}

