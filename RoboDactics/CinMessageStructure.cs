using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboDactics
{
    public enum Robot
    {Test,Robot1,Robot2,Robot3};

    public enum Experience
    { Exp1=1, Exp2, Exp3, Exp4 };

    public enum Motion
    { Stop, Forward, Backward, Accelerate, Decelerate,  RPM };

    public struct cinStruct
      {
         Robot myRobot;
         Experience myExperience;
        float T_Temp;
        float X_Position;
        float V_Vitess;
        float R_Rayon;
        float O_PositionAng;
        float W_VitessAng;

        public cinStruct(Robot myRobot, Experience myExperience, float t_Temp, float x_Position, 
                       float v_Vitess, float r_Rayon, float o_PositionAng, float w_VitessAng)
        {
            this.myRobot = myRobot;
            this.myExperience = myExperience;
            T_Temp = t_Temp;
            X_Position = x_Position;
            V_Vitess = v_Vitess;
            R_Rayon = r_Rayon;
            O_PositionAng = o_PositionAng;
            W_VitessAng = w_VitessAng;
        }

        public string BuildMessage()
        {
           // StringBuilder;
           return (int)myRobot +"|"+ (int)myExperience + "|" + T_Temp + "|" + X_Position + "|" + V_Vitess + "|" + 
                  R_Rayon + "|" + O_PositionAng +"|" + W_VitessAng;
        }  

    }
   

}
