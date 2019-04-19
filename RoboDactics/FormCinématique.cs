using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboDactics
{
    public partial class FormCinématique : Form
    {

        public FormCinématique()
        {
            InitializeComponent();
            if (Program.frmSerialTalk != null)
                Program.frmSerialTalk.m_DelegateAddToList += ReceiveDataFromRobot;

            Robodactic1_DisableAllControls(true);
            radioButtonExperience1.Checked = true;
            radioButtonExperience1_CheckedChanged(this.radioButtonExperience1, new EventArgs());
            radioButtonRayon1.Checked = true;
            radioButtonRayon1_CheckedChanged(this.radioButtonRayon1, new EventArgs());
        }

        const decimal Re1 = (decimal)0.01905;
        const decimal Re2 = (decimal)0.03175;
        const decimal Re3 = (decimal)0.04445;
        const decimal Rr1 = (decimal)0.035;
        const decimal Rr2 = (decimal)0.05;
        const decimal TranslationVitesseDef = 0;//(decimal)0.12;
        const decimal RouesVitesseDef = 0;//5
        //const int Roues2 = 10;

        private void ParseMessageArrived(string msg)
        {
            //int n = msg_listbox.Items.Add(msg);

        }

        private void Robodactic1_DisableAllControls(Boolean blnStatus)
        {
            comboBoxTemps.SelectedIndex = 2;
            comboBoxTranslationPosition.SelectedIndex = 2;
            comboBoxTranslationVitesse.SelectedIndex = 2;
            comboBoxRouesRayon.SelectedIndex = 2;
            comboBoxRouesPosition.SelectedIndex = 2;
            comboBoxRouesVitesse.SelectedIndex = 2;

            comboBoxTemps.Enabled = false;
            numericUpDownTemps_T.ReadOnly = blnStatus;

            comboBoxTranslationPosition.Enabled = false;
            comboBoxTranslationVitesse.Enabled = false;
            numericUpDownTranslationPosition_X.ReadOnly = blnStatus;
            numericUpDownTranslationVitesse_V.ReadOnly = blnStatus;

            comboBoxRouesPosition.Enabled = false;
            comboBoxRouesRayon.Enabled = false;
            comboBoxRouesVitesse.Enabled = false;
            numericUpDownRouesPosition_O.ReadOnly = blnStatus;
            numericUpDownRouesRayon_R.ReadOnly = blnStatus;
            numericUpDownRouesVitesse_W.ReadOnly = blnStatus;

            numericUpDownTemps_T.Value = 0;
            numericUpDownTranslationPosition_X.Value = 0;
            numericUpDownTranslationVitesse_V.Value = TranslationVitesseDef;
            numericUpDownRouesPosition_O.Value = 0;
           // numericUpDownRouesRayon_R.Value = 0;
            numericUpDownRouesVitesse_W.Value = RouesVitesseDef;
        }
  
        private void radioButtonExperience1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonExperience1.Checked == false)
                return;

            Robodactic1_DisableAllControls(false);
            comboBoxTemps.SelectedIndex = 0;
            numericUpDownTemps_T.Enabled = true;

            comboBoxTranslationPosition.SelectedIndex = 1;
            comboBoxTranslationVitesse.SelectedIndex = 1;
            numericUpDownTranslationPosition_X.Enabled = false;
            numericUpDownTranslationVitesse_V.Enabled = false;

            comboBoxRouesRayon.SelectedIndex = 0;
            comboBoxRouesPosition.SelectedIndex = 1;
            comboBoxRouesVitesse.SelectedIndex = 0;
            numericUpDownRouesPosition_O.Enabled = false;
            numericUpDownRouesRayon_R.Enabled = true;
            //numericUpDownRouesRayon_R.Value = Roues1;
            numericUpDownRouesVitesse_W.Enabled = true;

            numericUpDownTemps_T.Value = 0;
            numericUpDownTranslationPosition_X.Value = 0;
            numericUpDownTranslationVitesse_V.Value = TranslationVitesseDef;
            //numericUpDownRouesRayon_R.Value = 0;
            numericUpDownRouesPosition_O.Value = 0;
            numericUpDownRouesVitesse_W.Value = RouesVitesseDef;

        }
        private void radioButtonExperience2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonExperience2.Checked == false)
                return;
            Robodactic1_DisableAllControls(false);

            comboBoxTemps.SelectedIndex = 0;
            numericUpDownTemps_T.Enabled = true;

            comboBoxTranslationPosition.SelectedIndex = 1;
            comboBoxTranslationVitesse.SelectedIndex = 1;
            numericUpDownTranslationPosition_X.Enabled = false;
            numericUpDownTranslationVitesse_V.Enabled = false;

            comboBoxRouesRayon.SelectedIndex = 0;
            comboBoxRouesPosition.SelectedIndex = 1;
            comboBoxRouesVitesse.SelectedIndex = 0;
            numericUpDownRouesPosition_O.Enabled = false;
            numericUpDownRouesRayon_R.Enabled = true;
            //numericUpDownRouesRayon_R.Value = Roues1;
            numericUpDownRouesVitesse_W.Enabled = true;

            numericUpDownTemps_T.Value = 0;
            numericUpDownTranslationPosition_X.Value = 0;
            numericUpDownTranslationVitesse_V.Value = TranslationVitesseDef;
            //numericUpDownRouesRayon_R.Value = 0;
            numericUpDownRouesPosition_O.Value = 0;
            numericUpDownRouesVitesse_W.Value = RouesVitesseDef;
        }
        private void radioButtonExperience3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonExperience3.Checked == false)
                return;

            Robodactic1_DisableAllControls(false);
            comboBoxTemps.SelectedIndex = 0;
            numericUpDownTemps_T.Enabled = true;

            comboBoxTranslationPosition.SelectedIndex = 1;
            comboBoxTranslationVitesse.SelectedIndex = 0;
            numericUpDownTranslationPosition_X.Enabled = false;
            numericUpDownTranslationVitesse_V.Enabled = true;

            comboBoxRouesRayon.SelectedIndex = 0;
            comboBoxRouesPosition.SelectedIndex = 1;
            comboBoxRouesVitesse.SelectedIndex = 1;
            numericUpDownRouesPosition_O.Enabled = false;
            numericUpDownRouesRayon_R.Enabled = true;
            //numericUpDownRouesRayon_R.Value = Roues1;
            numericUpDownRouesVitesse_W.Enabled = false;

            numericUpDownTemps_T.Value = 0;
            numericUpDownTranslationPosition_X.Value = 0;
            numericUpDownTranslationVitesse_V.Value = TranslationVitesseDef;
            //numericUpDownRouesRayon_R.Value = 0;
            numericUpDownRouesPosition_O.Value = 0;
            numericUpDownRouesVitesse_W.Value = RouesVitesseDef;
        }

        private void radioButtonExperience4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonExperience4.Checked == false)
                return;

            Robodactic1_DisableAllControls(false);
            comboBoxTemps.SelectedIndex = 0;
            numericUpDownTemps_T.Enabled = true;

            comboBoxTranslationPosition.SelectedIndex = 1;
            comboBoxTranslationVitesse.SelectedIndex = 0;
            numericUpDownTranslationPosition_X.Enabled = false;
            numericUpDownTranslationVitesse_V.Enabled = true;

            comboBoxRouesRayon.SelectedIndex = 0;
            comboBoxRouesPosition.SelectedIndex = 1;
            comboBoxRouesVitesse.SelectedIndex = 1;
            numericUpDownRouesPosition_O.Enabled = false;
            numericUpDownRouesRayon_R.Enabled = true;
            //numericUpDownRouesRayon_R.Value = Roues1;
            numericUpDownRouesVitesse_W.Enabled = false;

            numericUpDownTemps_T.Value = 0;
            numericUpDownTranslationPosition_X.Value = 0;
            numericUpDownTranslationVitesse_V.Value = TranslationVitesseDef;
            //numericUpDownRouesRayon_R.Value = 0;
            numericUpDownRouesPosition_O.Value = 0;
            numericUpDownRouesVitesse_W.Value = RouesVitesseDef;
        }

        private void buttonRobodactic1Start_Click(object sender, EventArgs e)
        {
            if (Program.frmSerialTalk == null) { 
                Program.frmSerialTalk = new FormConfig();
                Program.frmSerialTalk.Show();
                return;
            }
            if (!Program.frmSerialTalk.serialPort.IsOpen)
            {
                MessageBox.Show("Serial port is not opened", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Program.frmSerialTalk.Show();
                return;
            }

            if (this.radioButtonExperience1.Checked)
            {
                SendTo_Robodactic1_Experience1_2();
            }
            else if (this.radioButtonExperience2.Checked)
            {
                SendTo_Robodactic1_Experience1_2();
            }
            else if (this.radioButtonExperience3.Checked)
            {
                SendTo_Robodactic1_Experience3_4();
            }
            else if (this.radioButtonExperience4.Checked)
            {
                SendTo_Robodactic1_Experience3_4();
            }
        }

        private void SendTo_Robodactic1_Experience1_2()
        {
            float O = 0, X = 0, V = 0;
            try
            {
                float T = (float)numericUpDownTemps_T.Value;
                float R = (float)numericUpDownRouesRayon_R.Value;
                float W = (float)numericUpDownRouesVitesse_W.Value;

                cinStruct MyStruct1 = new cinStruct(Robot.Robot1, Experience.Exp1, T, X, V, R, O, W);
                Program.frmSerialTalk.msg_textbox.Text = MyStruct1.BuildMessage();
                Program.frmSerialTalk.send_button.PerformClick();

                V = R * W;
                X = V * T;
                O = W * T;
                Console.WriteLine("V = " + V);
                Console.WriteLine("X = " + X);
                Console.WriteLine("O = " + O);
                // SerialTest.StartTest();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendTo_Robodactic1_Experience3_4()
        {
            float O = 0, X = 0, W = 0;
            try
            {
                float T = (float)numericUpDownTemps_T.Value;
                float R = (float)numericUpDownRouesRayon_R.Value;
                float V = (float)numericUpDownTranslationVitesse_V.Value;

                cinStruct MyStruct1 = new cinStruct(Robot.Robot1, Experience.Exp3, T, X, V, R, O, W);
                Program.frmSerialTalk.msg_textbox.Text = MyStruct1.BuildMessage();
                Program.frmSerialTalk.send_button.PerformClick();

                W = V / R;
                X = V * T;
                O = W * T;
                Console.WriteLine("W = " + W);
                Console.WriteLine("X = " + X);
                Console.WriteLine("O = " + O);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Receive Data
        void ReceiveDataFromRobot(string msg)
        {
            progressBar1.Visible = false;
            try
            {
                String[] myMessage = msg.Split('|');
                if (myMessage.Length != 8)
                    return;

                switch (Int32.Parse(myMessage[0].Substring(3)))
                {
                    case 1:
                        Receive_ForRobodactic1_Exp(myMessage);
                        break;
                    case 2:
                        Console.WriteLine("Receive_ForRobodactic2_Exp");
                        break;
                    case 3:
                        Console.WriteLine("Receive_ForRobodactic3_Exp");
                        break;
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Receive_ForRobodactic1_Exp(String[] myMessage)
        {
 
            try
            {
                switch (Int32.Parse(myMessage[1]))
                {
                    case 1:
                    case 2:
                        numericUpDownTranslationPosition_X.Value = decimal.Parse(myMessage[3]);
                        numericUpDownTranslationVitesse_V.Value = decimal.Parse(myMessage[4]);
                        numericUpDownRouesPosition_O.Value = decimal.Parse(myMessage[6]);
                        break;
                    case 3:
                    case 4:
                        numericUpDownTranslationPosition_X.Value = decimal.Parse(myMessage[3]);
                        numericUpDownRouesPosition_O.Value = decimal.Parse(myMessage[6]);
                        numericUpDownRouesVitesse_W.Value = decimal.Parse(myMessage[7]);
                        break;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void radioButtonRayon1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRobot1.Checked==true)
                numericUpDownRouesRayon_R.Value = Rr1;
            else
                numericUpDownRouesRayon_R.Value = Re1;
        }

        private void radioButtonRayon2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRobot1.Checked == true)
                numericUpDownRouesRayon_R.Value = Rr2;
            else
                numericUpDownRouesRayon_R.Value = Re2;
        }

        private void radioButtonRayon3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRobot1.Checked == true)
                numericUpDownRouesRayon_R.Value = Rr1;
            else
                numericUpDownRouesRayon_R.Value = Re3;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            numericUpDownTemps_T.Value = 0;
            numericUpDownTranslationPosition_X.Value = 0;
            numericUpDownTranslationVitesse_V.Value = 0;//TranslationVitesseDef;
            //numericUpDownRouesRayon_R.che = 0;
            numericUpDownRouesPosition_O.Value = 0;
            numericUpDownRouesVitesse_W.Value = 0;// RouesVitesseDef;
        }

        private void radioButtonRobot1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonRobot1.Checked)
            {
                groupBoxRoues.Text = "Roues";
                labelRayon.Text = "Rayon de la roue (Rr) [m]";
                radioButtonRayon1.Text = "Rr1";
                radioButtonRayon2.Text = "Rr2";
                radioButtonRayon3.Text = "Rr3";
                radioButtonRayon3.Visible = false;
            }
            else
            {
                groupBoxRoues.Text = "Engrenage";
                labelRayon.Text = "Rayon de l'engrenage (Re) [m]";
                radioButtonRayon1.Text = "Re1";
                radioButtonRayon2.Text = "Re2";
                radioButtonRayon3.Text = "Re3";
                radioButtonRayon3.Visible = true;
            }
            radioButtonRayon1_CheckedChanged(this.radioButtonRayon1, new EventArgs());
        }
    }
}
