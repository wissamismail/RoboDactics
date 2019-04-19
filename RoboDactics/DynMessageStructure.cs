using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboDactics
{
   
    public struct dynStruct
      {
        Robot myRobot;
        float T_Temp;
        float PWM;
        float R1;
        float M1;
        float R2;
        float M2;
        float Res;

        public dynStruct(Robot Robot, float T, float pwm, float Rayon1, float Mass1, float Rayon2, float Mass2, float Resist)
        {
            myRobot = Robot;
            T_Temp = T;
            PWM = pwm;
            R1 = Rayon1;
            R2 = Rayon2;
            M1 = Mass1;
            M2 = Mass2;
            Res = Resist;

        }

        public string BuildSendMessage()
        {
            // StringBuilder;
            return (int)myRobot  + "|" + T_Temp + "|" + PWM + "|" + R1 + "|" + M1 + "|" + R2 + "|" + M2 + "|" + Res;
        }  

    }


}
