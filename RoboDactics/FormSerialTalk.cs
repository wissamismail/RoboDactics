
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;


namespace RoboDactics
{
    public partial class FormConfig : Form
    {
        // Serial port
        public SerialPort serialPort = new SerialPort();
        const string TERM_CHAR = "\n";

        // Available baud rates
        private int[] baudrates = {
            4800,
            9600,
            14400,
            19200,
            28800,
            38400,
            57600,
            115200
        };

        // Threads
        public Thread t;
        ManualResetEvent runThread = new ManualResetEvent(false);

        // Delegates
        public delegate void DelegateAddToList(string msg);
        public DelegateAddToList m_DelegateAddToList;
        public delegate void DelegateStopPerfmormClick();
        public DelegateStopPerfmormClick m_DelegateStopPerfmormClick;


        public FormConfig()
        {
            InitializeComponent();
        }


        private void ReceiveThread()
        {
            while (true)
            {
                runThread.WaitOne(Timeout.Infinite);
                while (true)
                {
                    try
                    {
                        // receive data 
                        string msg = serialPort.ReadLine();
                        if (!msg.StartsWith("VMDPE"))
                            this.Invoke(this.m_DelegateAddToList, new Object[] { "R: " + msg });
                    }
                    catch
                    {
                        try
                        {
                            this.Invoke(this.m_DelegateStopPerfmormClick, new Object[] { });
                        }
                        catch { }
                        runThread.Reset();
                        break;
                    }

                }
            }
        }

        // Fill port combo box with available COM ports
        private void FillPortComboBox()
        { 
            port_combobox.Items.Clear();
            SerialPort tmp;
            foreach (string portname in SerialPort.GetPortNames())
            {

                if (port_combobox.Items.Contains(portname)) continue;
                tmp = new SerialPort(portname);
                try
                {
                    tmp.Open();
                    if (tmp.IsOpen)
                    {
                        tmp.Close();
                        port_combobox.Items.Add(portname);
                    }
                }
                catch { }

            }
              port_combobox.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Fill port_combobox
            FillPortComboBox();
            
            // Fill baudrate_combobox
            foreach (int baudrate in baudrates)
                baudrate_combobox.Items.Add(baudrate.ToString());
            
            baudrate_combobox.SelectedIndex = 1;

            // Set terminating character
            serialPort.NewLine = TERM_CHAR;

            m_DelegateAddToList = new DelegateAddToList(AddToList);
            m_DelegateStopPerfmormClick = new DelegateStopPerfmormClick(stop_button.PerformClick);
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

            t = new Thread(ReceiveThread);
            t.Start();
        }

        public void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // blocks until TERM_CHAR is received
            try
            {
                string msg = serialPort.ReadLine();
                this.Invoke(this.m_DelegateAddToList, new Object[] { "R: " + msg });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stop_button.PerformClick();
            }
            
        }

        private void AddToList(string msg)
        {
            int n = msg_listbox.Items.Add(msg);
            msg_listbox.SelectedIndex = n;
            msg_listbox.ClearSelected();
        }


        private void start_button_Click(object sender, EventArgs e)
        {
            if (port_combobox.Text == "" || baudrate_combobox.Text == "")
            {
                MessageBox.Show("You must specify serial port and baud rate.");
                return;
            }

            // Open serial port
            serialPort.PortName = port_combobox.Text;
            serialPort.BaudRate = Convert.ToInt32(baudrate_combobox.Text);

            try
            {
                serialPort.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            // Connection established
            send_button.Enabled = true;
            buttonSendDistVolt.Enabled = true;
            port_combobox.Enabled = false;
            baudrate_combobox.Enabled = false;
            start_button.Enabled = false;
            stop_button.Enabled = true;
            int n = msg_listbox.Items.Add("Connection established...");
            msg_listbox.SelectedIndex = n;
            msg_listbox.ClearSelected();

            runThread.Set();
            
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen == true)
                    // Connection  closed
                    serialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            runThread.Reset();

            send_button.Enabled = false;
            buttonSendDistVolt.Enabled = false;
            port_combobox.Enabled = true;
            baudrate_combobox.Enabled = true;
            start_button.Enabled = true;
            stop_button.Enabled = false;
            int n = msg_listbox.Items.Add("Connection closed.");
            msg_listbox.SelectedIndex = n;
            msg_listbox.ClearSelected();

            // Refill port_combobox
            FillPortComboBox();

        }

        private void send_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Send message
                if (msg_textbox.Text != "")
                {
                    serialPort.WriteLine(msg_textbox.Text);
                    int n = msg_listbox.Items.Add("S: " + msg_textbox.Text);
                    msg_listbox.SelectedIndex = n;
                    msg_listbox.ClearSelected();
                    msg_textbox.Text = ""; 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stop_button.PerformClick();
            }
        }

        private void msg_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {   
            if(e.KeyChar == '\r')
                e.Handled = true;
        }


        private void msg_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode){

                case Keys.Return:
                    send_button.PerformClick();
                    break;
            }

        }

       /* protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            // Close serial port (if opened)
            if (serialPort.IsOpen)
            {
                stop_button.PerformClick();
            }

            // Abort thread
            t.Abort();
            
        }*/

        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void buttonSendDistVolt_Click(object sender, EventArgs e)
        {
            this.msg_textbox.Text = 0 + "|" + 0 + "|" + (float)numericUpDownVoltage.Value + "|" + (float)numericUpDownDistance.Value;
            this.send_button.PerformClick();
        }
    }
}
