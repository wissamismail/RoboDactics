using RoboDactics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboDactics
{

    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonCinématique_Click(object sender, EventArgs e)
        {
            FormCinématique myCinématique = new FormCinématique();
            myCinématique.Show();

        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            if (Program.frmSerialTalk == null)
                Program.frmSerialTalk = new FormConfig();
            Program.frmSerialTalk.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close serial port (if opened)
            if (Program.frmSerialTalk == null)
                return;
                if (Program.frmSerialTalk.serialPort.IsOpen)
            {
                Program.frmSerialTalk.stop_button.PerformClick();
            }

            // Abort thread
            Program.frmSerialTalk.t.Abort();
        }

        private void buttonDynamique_Click(object sender, EventArgs e)
        {
            FormDynamique myDynamique = new FormDynamique();
            myDynamique.Show();
        }
    }
}
