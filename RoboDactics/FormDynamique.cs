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
    public partial class FormDynamique : Form
    {
        const decimal RePetit = (decimal)0.01905;
        const decimal ReMoyenn = (decimal)0.03175;
        const decimal ReGrand = (decimal)0.04445;

        decimal m1_Masse;
        decimal m2_Masse;
        const decimal Masse_Petit = (decimal)0.006;
        const decimal Masse_Moyenn = (decimal)0.012;
        const decimal Masse_Grand = (decimal)0.027;

        const decimal Resistance1 = (decimal)470;
        const decimal Resistance2 = (decimal)940;
        const decimal Resistance3 = (decimal)1410;
        const decimal Resistance4 = (decimal)1880;

        public FormDynamique()
        {
            InitializeComponent();
            if (Program.frmSerialTalk != null)
                Program.frmSerialTalk.m_DelegateAddToList += ReceiveDataFromRobot;
            Experience1();
            //comboBoxRayon1.SelectedIndex = 0;
            //comboBoxRayon2.SelectedIndex = 0;
        }

        private void Experience1()
        {
            comboBoxTemps.SelectedIndex = 0;
            comboBoxPWM.SelectedIndex = 0;

            comboBoxEngrenageD1Position.SelectedIndex = 1;
            comboBoxEngrenageD1Vitesse.SelectedIndex = 1;
            numericUpDownD1_R1.ReadOnly = true;
            numericUpDownEngrenageD1Position_O1.ReadOnly = true;
            numericUpDownEngrenageD1Vitesse_W1.ReadOnly = true;

            comboBoxEngrenageD2Position.SelectedIndex = 1;
            comboBoxEngrenageD2Vitesse.SelectedIndex = 1;
            numericUpDownD2_R2.ReadOnly = true;
            numericUpDownEngrenageD2Position_O2.ReadOnly = true;
            numericUpDownEngrenageD2Vitesse_W2.ReadOnly = true;

            comboBoxForce.SelectedIndex = 1;
            comboBoxM1.SelectedIndex = 1;
            comboBoxM2.SelectedIndex = 1;
            numericUpDownForce.ReadOnly = true;
            numericUpDownM1.ReadOnly = true;
            numericUpDownM2.ReadOnly = true;

            comboBoxU1.SelectedIndex = 1;
            comboBoxI1.SelectedIndex = 1;
            comboBoxP1.SelectedIndex = 1;
            numericUpDownU1.ReadOnly = true;
            numericUpDownI1.ReadOnly = true;
            numericUpDownP1.ReadOnly = true;

            comboBoxU2.SelectedIndex = 1;
            comboBoxP2.SelectedIndex = 1;
            numericUpDownU2.ReadOnly = true;
            numericUpDownResistance.ReadOnly = true;
            numericUpDownP2.ReadOnly = true;
        }


        private void Reset_Click(object sender, EventArgs e)
        {
            numericUpDownEngrenageD1Position_O1.Value = 0;
            numericUpDownEngrenageD1Vitesse_W1.Value = 0;
            numericUpDownM1.Value = 0;
            numericUpDownEngrenageD2Position_O2.Value = 0;
            numericUpDownEngrenageD2Vitesse_W2.Value = 0;
            numericUpDownM2.Value = 0;
            numericUpDownTemps_T.Value = 0;
            numericUpDownForce.Value = 0;
            numericUpDownPWM.Value = 0;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (Program.frmSerialTalk == null)
            {
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
            progressBar1.Visible = true;
            SendTo_Experience1();
        }

        private void SendTo_Experience1()
        {
            try
            {

                float T = (float)numericUpDownTemps_T.Value;
                float PWM = (float)numericUpDownPWM.Value;
                float F = (float)numericUpDownForce.Value;
                float R1 = (float)numericUpDownD1_R1.Value;
                float R2 = (float)numericUpDownD2_R2.Value ;
                float Res = (float)numericUpDownResistance.Value;
                dynStruct MyStruct = new dynStruct(Robot.Robot3,T, PWM, R1, (float)m1_Masse, R2, (float)m2_Masse, Res);
                Program.frmSerialTalk.msg_textbox.Text = MyStruct.BuildSendMessage();
                Program.frmSerialTalk.send_button.PerformClick();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ReceiveDataFromRobot(string msg)
        {
         
            try
            {
                String[] myMessage = msg.Split('|');
                if (myMessage.Length != 13)
                    return;
                progressBar1.Visible = false;
                switch (Int32.Parse(myMessage[0].Substring(3)))
                {
                    case 1:
                    case 2:
                        break;
                    case 3:
                        Receive_ForRobodactic3_Exp(myMessage);
                        break;
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Receive_ForRobodactic3_Exp(String[] myMessage)
        {

            try
            {
         
                        numericUpDownForce.Value = decimal.Parse(myMessage[1]);
                        numericUpDownEngrenageD1Position_O1.Value = decimal.Parse(myMessage[2]);
                        numericUpDownEngrenageD1Vitesse_W1.Value = decimal.Parse(myMessage[3]);
                        numericUpDownM1.Value = decimal.Parse(myMessage[4]);
                        numericUpDownU1.Value = decimal.Parse(myMessage[5]);
                        numericUpDownI1.Value = decimal.Parse(myMessage[6]);
                        numericUpDownP1.Value = decimal.Parse(myMessage[7]);

                        numericUpDownEngrenageD2Position_O2.Value = decimal.Parse(myMessage[8]);
                        numericUpDownEngrenageD2Vitesse_W2.Value = decimal.Parse(myMessage[9]);
                        numericUpDownM2.Value = decimal.Parse(myMessage[10]);
                        numericUpDownU2.Value = Math.Abs(decimal.Parse(myMessage[11]));
                       // numericUpDownResistance.Value = Math.Abs(decimal.Parse(myMessage[12]));
                        numericUpDownP2.Value = decimal.Parse(myMessage[12]);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBoxRayon1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxRayon1.SelectedIndex)
            {
                case 0:
                    numericUpDownD1_R1.Value = RePetit;
                    m1_Masse = Masse_Petit;
                    break;
                case 1:
                    numericUpDownD1_R1.Value = ReMoyenn;
                    m1_Masse = Masse_Moyenn;
                    break;
                case 2:
                    numericUpDownD1_R1.Value = ReGrand;
                    m1_Masse = Masse_Grand;
                    break;
            }
        }

        private void comboBoxRayon2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxRayon2.SelectedIndex)
            {
                case 0:
                    numericUpDownD2_R2.Value = RePetit;
                    m2_Masse = Masse_Petit;
                    break;
                case 1:
                    numericUpDownD2_R2.Value = ReMoyenn;
                    m2_Masse = Masse_Moyenn;
                    break;
                case 2:
                    numericUpDownD2_R2.Value = ReGrand;
                    m2_Masse = Masse_Grand;
                    break;
            }
        }

        private void comboBoxResistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxResistance.SelectedIndex)
            {
                case 0:
                    numericUpDownResistance.Value = Resistance1;
                    break;
                case 1:
                    numericUpDownResistance.Value = Resistance2;
                    break;
                case 2:
                    numericUpDownResistance.Value = Resistance3;
                    break;
                case 3:
                    numericUpDownResistance.Value = Resistance4;
                    break;
            }
        }
    }

  
}
