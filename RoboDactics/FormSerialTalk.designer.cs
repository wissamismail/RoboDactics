namespace RoboDactics
{
    partial class FormConfig
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stop_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.baudrate_combobox = new System.Windows.Forms.ComboBox();
            this.port_combobox = new System.Windows.Forms.ComboBox();
            this.msg_textbox = new System.Windows.Forms.TextBox();
            this.send_button = new System.Windows.Forms.Button();
            this.msg_listbox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownDistance = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVoltage = new System.Windows.Forms.NumericUpDown();
            this.buttonSendDistVolt = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoltage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stop_button);
            this.groupBox1.Controls.Add(this.start_button);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.baudrate_combobox);
            this.groupBox1.Controls.Add(this.port_combobox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial communication settings";
            // 
            // stop_button
            // 
            this.stop_button.Enabled = false;
            this.stop_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stop_button.Location = new System.Drawing.Point(189, 44);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(58, 20);
            this.stop_button.TabIndex = 4;
            this.stop_button.Text = "STOP";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // start_button
            // 
            this.start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.start_button.Location = new System.Drawing.Point(189, 18);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(58, 20);
            this.start_button.TabIndex = 3;
            this.start_button.Text = "START";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Baud rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Port";
            // 
            // baudrate_combobox
            // 
            this.baudrate_combobox.DropDownHeight = 100;
            this.baudrate_combobox.FormattingEnabled = true;
            this.baudrate_combobox.IntegralHeight = false;
            this.baudrate_combobox.Location = new System.Drawing.Point(67, 45);
            this.baudrate_combobox.Name = "baudrate_combobox";
            this.baudrate_combobox.Size = new System.Drawing.Size(97, 21);
            this.baudrate_combobox.TabIndex = 6;
            // 
            // port_combobox
            // 
            this.port_combobox.DropDownHeight = 100;
            this.port_combobox.FormattingEnabled = true;
            this.port_combobox.IntegralHeight = false;
            this.port_combobox.ItemHeight = 13;
            this.port_combobox.Items.AddRange(new object[] {
            "COM 1",
            "COM 2",
            "COM 3",
            "COM 4",
            "COM 5",
            "COM 6",
            "COM 7",
            "COM 8",
            "COM 9"});
            this.port_combobox.Location = new System.Drawing.Point(67, 18);
            this.port_combobox.Name = "port_combobox";
            this.port_combobox.Size = new System.Drawing.Size(97, 21);
            this.port_combobox.TabIndex = 5;
            // 
            // msg_textbox
            // 
            this.msg_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msg_textbox.Location = new System.Drawing.Point(12, 143);
            this.msg_textbox.Name = "msg_textbox";
            this.msg_textbox.Size = new System.Drawing.Size(204, 20);
            this.msg_textbox.TabIndex = 1;
            this.msg_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msg_textbox_KeyDown);
            this.msg_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.msg_textbox_KeyPress);
            // 
            // send_button
            // 
            this.send_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.send_button.Enabled = false;
            this.send_button.Location = new System.Drawing.Point(222, 143);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(62, 21);
            this.send_button.TabIndex = 2;
            this.send_button.Text = "send";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // msg_listbox
            // 
            this.msg_listbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msg_listbox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msg_listbox.FormattingEnabled = true;
            this.msg_listbox.ItemHeight = 16;
            this.msg_listbox.Location = new System.Drawing.Point(12, 169);
            this.msg_listbox.Name = "msg_listbox";
            this.msg_listbox.Size = new System.Drawing.Size(272, 260);
            this.msg_listbox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Distance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Voltage";
            // 
            // numericUpDownDistance
            // 
            this.numericUpDownDistance.DecimalPlaces = 3;
            this.numericUpDownDistance.Location = new System.Drawing.Point(98, 89);
            this.numericUpDownDistance.Name = "numericUpDownDistance";
            this.numericUpDownDistance.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownDistance.TabIndex = 8;
            // 
            // numericUpDownVoltage
            // 
            this.numericUpDownVoltage.DecimalPlaces = 3;
            this.numericUpDownVoltage.Location = new System.Drawing.Point(98, 115);
            this.numericUpDownVoltage.Name = "numericUpDownVoltage";
            this.numericUpDownVoltage.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownVoltage.TabIndex = 9;
            // 
            // buttonSendDistVolt
            // 
            this.buttonSendDistVolt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendDistVolt.Enabled = false;
            this.buttonSendDistVolt.Location = new System.Drawing.Point(197, 91);
            this.buttonSendDistVolt.Name = "buttonSendDistVolt";
            this.buttonSendDistVolt.Size = new System.Drawing.Size(62, 21);
            this.buttonSendDistVolt.TabIndex = 10;
            this.buttonSendDistVolt.Text = "send";
            this.buttonSendDistVolt.UseVisualStyleBackColor = true;
            this.buttonSendDistVolt.Click += new System.EventHandler(this.buttonSendDistVolt_Click);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 439);
            this.Controls.Add(this.buttonSendDistVolt);
            this.Controls.Add(this.numericUpDownVoltage);
            this.Controls.Add(this.numericUpDownDistance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.msg_listbox);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.msg_textbox);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(312, 361);
            this.Name = "FormConfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robot Talk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfig_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoltage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button stop_button;
        public System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox baudrate_combobox;
        private System.Windows.Forms.ComboBox port_combobox;
        private System.Windows.Forms.ListBox msg_listbox;
        public System.Windows.Forms.TextBox msg_textbox;
        public System.Windows.Forms.Button send_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownDistance;
        private System.Windows.Forms.NumericUpDown numericUpDownVoltage;
        public System.Windows.Forms.Button buttonSendDistVolt;
    }
}

