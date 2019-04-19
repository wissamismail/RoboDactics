/*
 Name:		Robo3Sketch.ino
 Created:	3/27/2019 11:07:22 PM
 Author:	Wissam Ismail
*/

#include "Timer.h"

// connect motor controller pins to Arduino digital pins
#define pwmMotor 9 // PWM regulate speed
#define enaMotor 8 // On Off
#define enableMotor1 13 //  Driver Enable
int PotentialPWM = 50; //Pulse width modulation motor
Timer myTimer;
int timeStart;
const String Splitter = "|";

//
#define INPUT_SIZE 50
int Robot;
int Experience;
float T_Temp;

float R1_Rayon ;
float R2_Rayon ;

float m1_Masse ;
float m2_Masse;
float m3_Masse;
float Resistancs;

float F_Force;
float O1_PositionAng;
float W1_VitessAng;
float M1_Moment;
float O2_PositionAng;
float W2_VitessAng;
float M2_Moment;

#define Loops 1000
double VoltageBattery = 0;
double U1 = 0;// VoltageMotorIN
double U2 = 0;// VoltageMotorOUT
double Ur = 0;// VoltageMotorOUT
double I1 = 0;// CurrentMotorIN
double P1 = 0;
double P2 = 0;

// Encoder Disc
#define encoderHoles1_pin  2 // pulse output from the module
#define encoderHoles2_pin  A0 // pulse output from the module

int encoderLast1 = LOW;
int encoderCurrent1 = LOW;
int encoderLast2 = LOW;
int encoderCurrent2 = LOW;
int nbHoles1; // number of Holes
int nbHoles2; // number of Holes
bool useencoder;

#define analogInCurrent  A0

void setup()
{
	Serial.begin(9600);
	Serial.println(">> Run <<");

	// set all the motor control pins to outputs
	pinMode(pwmMotor, OUTPUT);
	pinMode(enaMotor, OUTPUT);
	//pinMode(enableMotor1, OUTPUT);
	//digitalWrite(enableMotor1, HIGH);

	// Initialize Wheel Encoder Disc
	pinMode(encoderHoles1_pin, INPUT);    //so that is where the IR detector is connected
	pinMode(encoderHoles2_pin, INPUT);    //so that is where the IR detector is connected

	//Serial.println("voltage = " + (String)voltage);
	Serial.println("3|1|5|0.03175|0.04445|80|0|0|0|0|0|0");
}

void loop()
{
	if (useencoder == true)
	{
		encoderCurrent2 = analogRead(encoderHoles2_pin);
		encoderCurrent1 = digitalRead(encoderHoles1_pin);
		
		if ((encoderLast2 < 200) && (encoderCurrent2 > 200)) {
			nbHoles2++;
		}
		if ((encoderLast1 == LOW) && (encoderCurrent1 == HIGH)) {
			nbHoles1++;
		}
		
		encoderLast2 = encoderCurrent2;
		encoderLast1 = encoderCurrent1;
	}
	myTimer.update();
	//check whether arduino is receiving signal or not
	if (Serial.available() > 0) {
	
		char input[INPUT_SIZE + 1];
		byte size = Serial.readBytes(input, INPUT_SIZE); //reads the signal;
		splitCommand(input);
		StartRobot();
	}

}

void splitCommand(char* oneLine) {

	// Returns first token
	char* chpt = strtok(oneLine, "|");
	if (chpt != NULL) {
		Robot = atof(chpt);
		Serial.println("Robot = " + (String)Robot);
	}
	else { return; }

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		T_Temp = atof(chpt);
		Serial.println("T_Temp = " + (String)T_Temp);
	}
	else { return; }


	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		PotentialPWM = atof(chpt);
		Serial.println("PotentialPWM = " + (String)PotentialPWM);
	}
	else { return; }

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		R1_Rayon = atof(chpt);
		Serial.println("R1_Rayon = " + (String)R1_Rayon);
	}
	else { return; }
	
	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		m1_Masse = atof(chpt);
		Serial.println("m1_Masse = " + (String)m1_Masse);
	}
	else { return; }

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		R2_Rayon = atof(chpt);
		Serial.println("R2_Rayon = " + (String)R2_Rayon);
	}
	else { return; }

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		m2_Masse = atof(chpt);
		Serial.println("m2_Masse = " + (String)m2_Masse);
	}
	else { return; }

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		Resistancs = atof(chpt);
		Serial.println("Resistancs = " + (String)Resistancs);
	}
	else { return; }

}

void StartRobot()                              // go function
{
	switch (Robot)
	{
	case 0:
		break;
	case 3:
		Robo3Exp1_2();
		break;
	}
}

void Robo3Exp1_2()                              // go function
{
	//Prepaire Hole Sensor
	nbHoles1 = 0;
	encoderLast1 = LOW;
	nbHoles2 = 0;
	encoderLast2 = LOW;
	useencoder = true;

	//Set the Time of Experience
	myTimer.after(T_Temp * 1000, takeReadingRobo1Exp1_2, (void*)0);
	//Start Motion at specific PWM
	ForwardMotion(PotentialPWM);
	//delay(10);

}

void takeReadingRobo1Exp1_2(void *context)
{
	calculateAll();

	StopMotion();
	useencoder = false;
	//Experience; T_Temp; R1_Rayon; R2_Rayon; F_Force; O1_PositionAng; W1_VitessAng; M1_Moment; O2_PositionAng; W2_VitessAng; M2_Moment;
	Serial.println("---Results of experiment are:---");

	// Calculate Position Angulaire O1 & Vitesse angulaire W1 
	Serial.println("nbHoles1 = " + (String)nbHoles1);
	O1_PositionAng = (2 * PI * nbHoles1) / 32;
	Serial.println("O1_PositionAng = " + (String)(O1_PositionAng,4));
	
	W1_VitessAng = O1_PositionAng / T_Temp;
	Serial.println("W1_VitessAng = " + (String)(W1_VitessAng, 4));

	//P1 = U1 * I1;
	//Serial.println("P1 = " + (String)P1);

	Serial.println("nbHoles2 = " + (String)nbHoles2);
	O2_PositionAng = (2 * PI * nbHoles2) / 32;
	Serial.println("O2_PositionAng = " + (String)(O2_PositionAng, 4));
	
	W2_VitessAng = O2_PositionAng / T_Temp;
	Serial.println("W2_VitessAng = " + (String)(W2_VitessAng, 4));

	F_Force = (m1_Masse *  R1_Rayon * W1_VitessAng * W1_VitessAng / 4 * O1_PositionAng)
		+ (U2 * U2 / W2_VitessAng * R2_Rayon * Resistancs);
	Serial.println("F_Force = " + (String)(F_Force, 4));

	M1_Moment = R1_Rayon * F_Force;
	Serial.println("M1_Moment = " + (String)(M1_Moment, 4));

	M2_Moment = R2_Rayon * F_Force;
	Serial.println("M2_Moment = " + (String)(M2_Moment, 4));

	P2 = U2 * U2 / Resistancs;
	Serial.println("P2 = " + (String)(P2, 4));

	// Send Response
	Serial.println(3 + Splitter + String(F_Force, 4) 
				 + Splitter + String(O1_PositionAng, 4)  + Splitter + String(W1_VitessAng, 4) + Splitter + String(M1_Moment, 4)
				 + Splitter + String(U1, 4) + Splitter + String(I1, 4) + Splitter + String(P1, 4)
				 + Splitter + String(O2_PositionAng, 4) + Splitter + String(W2_VitessAng, 4)  + Splitter + String(M2_Moment, 4)
				 + Splitter + String(U2, 4) + Splitter + String(P2, 4));
}
void calculateAll() {
	
	for (int i = 0; i < Loops; i++) {   	// Voltage is Sensed 1000 Times for precision
	//	U1  = U1  + analogRead(A1);//VoltageMotor + map(analogRead(A1), 0, 1023, 0, 25)  ;
		U2 = U2 + analogRead(A2);//VoltageMotor + map(analogRead(A1), 0, 1023, 0, 25)  ;
	//	Ur = Ur + analogRead(A3);
		//VoltageBattery  = VoltageBattery  + analogRead(A5); 
		//I1  = I1  + analogRead(A2);
		//I2 = I2 + analogRead(A2);
		delay(1);
	}
	
//	U1 = U1 * 0.025 / Loops;// Convert the analog reading (which goes from 0 - 1023) to a voltage (0 - 25V)
	//Serial.print("\n Voltage Motor IN(V) = "); //  Current is Sensed 1000 Times for precision (25 / 1023 = 0.0244)
	//Serial.print(U1, 4);

	U2 = U2 * 0.025 / Loops;// Convert the analog reading (which goes from 0 - 1023) to a voltage (0 - 25V)
	Serial.print("\n Voltage Motor OUT(V) = "); //  Current is Sensed 1000 Times for precision (25 / 1023 = 0.0244)
	Serial.print(U2, 4);

	//Ur = Ur * 0.025 / Loops;// Convert the analog reading (which goes from 0 - 1023) to a voltage (0 - 25V)
	//Serial.print("\n Voltage Motor OUT(V) = "); //  Current is Sensed 1000 Times for precision (25 / 1023 = 0.0244)
	//Serial.print(Ur, 4);
	
	//I1 = U1 / 10;//(.0264 * I1/Loops) ;//    5/1023 = 0.004887585532746823069403714565
	//Serial.print("\n Current Motor IN(I) = ");
	//Serial.println(I1, 4);

	//I2 = (.0264 * I2/Loops);//    5/1023 = 0.004887585532746823069403714565
	//Serial.print("\n Current Motor OUT(I) = ");
	//Serial.println(I2, 4);

}


void calculateCurrentMotorIN() {

	for (int i = 0; i < Loops; i++) {
		I1 = I1 +  analogRead(A4) ;
		delay(1);
	}
	I1 = I1 / Loops;//    5/1023 = 0.004887585532746823069403714565
	Serial.print("\n Current Motor IN(I) = "); 
	Serial.print(((.0264 *I1) - 13.51), 4);
	Serial.print("\n Current Motor30 IN(I) = ");
	Serial.print((.044 * I1 - 3.78), 4);
	Serial.print("\n Current Motor5 IN(I) = ");
	Serial.print((I1 * 5/1023), 4);
	Serial.print("\n Current Motor20 IN(I) = ");
	Serial.print((I1 *20/1023), 4);
	Serial.print("\n Current Motor30 IN(I) = ");
	Serial.print((I1 *30/1023), 4);
	I1 = 0;
}


void DCCurrentMeasuring() {

	for (int i = 0; i < Loops; i++) {
		VoltageBattery = VoltageBattery + (analogRead(A3)) / Loops;
		delay(1);
	}
	for (int i = 0; i < Loops; i++) {
		//VoltageMotor = VoltageMotor + (analogRead(A4)) / 1000;
		////	for (int i = 0; i < 1000; i++) {
		//VoltageMotor = VoltageMotor + (.0264 * analogRead(A4) - 13.51) / 1000;
		//5A mode, if 20A or 30A mode, need to modify this formula to 
		//(.19 * analogRead(A0) -25) for 20A mode and 
		//(.044 * analogRead(A0) -3.78) for 30A mode

		delay(1);
	}
	}

void  ForwardMotion (int intPWM) {
	/*********For Forward motion*********/
	Serial.println("FORWARD Started: PWM = " + (String) intPWM);
	// set speed to 200 out of possible range 0~255
	//digitalWrite(enableMotor1, HIGH);
	digitalWrite(enaMotor, LOW);
	analogWrite(pwmMotor, intPWM);

}

void StopMotion() {
	/*********Stop*********/
	Serial.println("Motion Stopped ");
	digitalWrite(enaMotor, LOW);
	digitalWrite(pwmMotor, LOW);
	//digitalWrite(enableMotor1, HIGH);
}


