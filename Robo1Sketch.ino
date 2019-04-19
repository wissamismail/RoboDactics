#include "Timer.h"

// connect motor controller pins to Arduino digital pins
#define pwmMotor1 10 // motor one
#define directionMotor1 A1
#define pwmMotor2 11 // motor Two
#define directionMotor2 A2
int PotentialPWM = 128; //Pulse width modulation motor
Timer myTimer;
int timeStart;
const String Splitter = "|";

//
#define INPUT_SIZE 30
int Robot;
int Experience;
float T_Temp;
float X_Position;
float V_Vitess;
float R_Rayon;
float O_PositionAng;
float W_VitessAng;
float voltage = 7.4;

// Motor Speed Sensor
int const encoderHoles_pin = 2; // pulse output from the module, Interrupt 0 is digital pin 8,
int nbHoles; // number of Holes
int encoderLast = LOW;
int encoderCurrent = LOW;
bool useencoder;
#define pulsesPerTurn 32 // number of pulses per revolution based on your encoder disc

// Define pins for ultrasonic
int const trigPin = 13;
int const echoPin = 12;
float distance0 = 2;

void setup()
{
	Serial.begin(9600);
	Serial.println(">> Run <<");

	// set all the motor control pins to outputs
	pinMode(pwmMotor1, OUTPUT);
	pinMode(directionMotor1, OUTPUT);
	pinMode(pwmMotor2, OUTPUT);
	pinMode(directionMotor2, OUTPUT);

	// Initialize Wheel Encoder Disc
	pinMode(encoderHoles_pin, INPUT);    //so that is where the IR detector is connected

	pinMode(trigPin, OUTPUT); // trig pin will have pulses output
	pinMode(echoPin, INPUT); // echo pin should be input to get pulse width

	Serial.println("voltage = " + (String)voltage);
	Serial.println("distance max(m) = " + (String)distance0);
	Serial.println("1|1|5|0|0|0.035|0|5");
	
}


void loop()
{
	myTimer.update();
	if (useencoder == true)
	{
		encoderCurrent = digitalRead(encoderHoles_pin);
		if ((encoderLast == LOW) && (encoderCurrent == HIGH)) {
		nbHoles++;
		}
	encoderLast = encoderCurrent;
	}
	//check whether arduino is receiving signal or not
	if (Serial.available() > 0) {
		char input[INPUT_SIZE + 1];
		byte size = Serial.readBytes(input, INPUT_SIZE); //reads the signal;
		splitCommand(input);
		StartRobot();
	}

}

void Robo1Exp1_2()                              // go function
{
	//Prepaire Hole Sensor
	nbHoles = 0;
	encoderLast = LOW;
	useencoder = true;
	//attachInterrupt(digitalPinToInterrupt(pulsesReading_pin), InterruptCounter, FALLING);

	//Set the Time of Experience
	myTimer.after(T_Temp * 1000, takeReadingRobo1Exp1_2, (void*)0);

	//Start Motion at specific PWM
	PotentialPWM = W_VitessAng / 0.05;
	Serial.println("PotentialPWM = " + (String)PotentialPWM);
	ForwardMotion(PotentialPWM);
}

void takeReadingRobo1Exp1_2(void *context)
{
	float distance2;
	StopMotion();
	useencoder = false;
	// Robot; Experience; T_Temp; X_Position?; V_Vitess?; R_Rayon; O_PositionAng?; W_VitessAng;
	Serial.println("---Results of experiment are:---");
	// Calculate Distance - linear displacement(Position linéaire) X
	distance2 = calculateTraverseDistanse();
	Serial.println("distance2 = " + (String)distance2);
	X_Position = distance0 - ((distance2) / 100);
	Serial.println("X = " + (String)X_Position);

	// Calculate Angular Velocity (Vitesse angulaire) O
	Serial.println("nbHoles = " + (String)nbHoles);
	O_PositionAng = (2 * PI * nbHoles) / 32;
	Serial.println("O_PositionAng = " + (String)O_PositionAng);

	// Calculate  linear Velocity (Vitesse linéaire) V
	V_Vitess = X_Position / T_Temp;
	Serial.println("V_Vitess = " + (String)V_Vitess);
	Serial.println(Robot + Splitter + Experience + Splitter + T_Temp + Splitter + X_Position + Splitter + V_Vitess + Splitter +
		R_Rayon + Splitter + O_PositionAng + Splitter + W_VitessAng);
}

void Robo1Exp3_4()                              // go function
{
	//Prepaire Hole Sensor
	nbHoles = 0;
	encoderLast = LOW;
	useencoder = true;
	//attachInterrupt(digitalPinToInterrupt(pulsesReading_pin), InterruptCounter, FALLING);

	//Set the Time of Experience
	myTimer.after(T_Temp * 1000, takeReadingRobo1Exp3_4, (void*)0);

	//Start Motion at specific PWM
	PotentialPWM = (V_Vitess / R_Rayon) / 0.05;
	Serial.println("PotentialPWM = " + (String)PotentialPWM);
	ForwardMotion(PotentialPWM);
}

void takeReadingRobo1Exp3_4(void *context)
{
	float distance2;
	StopMotion();
	useencoder = false;
	// Robot; Experience; T_Temp; X_Position?; V_Vitess?; R_Rayon; O_PositionAng?; W_VitessAng;
	Serial.println("---Results of experiment are:---");
	// Calculate Distance - linear displacement(Position linéaire) X
	distance2 = calculateTraverseDistanse();
	Serial.println("distance2 = " + (String)distance2);
	X_Position = distance0 - ((distance2) / 100);
	Serial.println("X = " + (String)X_Position);

	// Calculate Angular Velocity (Vitesse angulaire) O
	Serial.println("nbHoles = " + (String)nbHoles);
	O_PositionAng = (2 * PI * nbHoles) / 32;
	Serial.println("O_PositionAng = " + (String)O_PositionAng);

	// Calculate Angular Displacement (Position angulaire) W
	W_VitessAng = O_PositionAng / T_Temp;
	Serial.println("V_Vitess = " + (String)V_Vitess);

	// Send Response
	Serial.println(Robot + Splitter + Experience + Splitter + T_Temp + Splitter + X_Position + Splitter + V_Vitess + Splitter +
		R_Rayon + Splitter + O_PositionAng + Splitter + W_VitessAng);
}


void splitCommand(char* oneLine) {
	int errors = 0;
	String printText;

	// Returns first token
	char* chpt = strtok(oneLine, "|");
	if (chpt != NULL) {
		Serial.print("Robot = ");
		Robot = atof(chpt);
		Serial.println(Robot);
	}
	else {
		return;
	}

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		Serial.print("Experience = ");
		Experience = atof(chpt);
		Serial.println(Experience);
	}
	else {
		return;
	}

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		Serial.print("T_Temp = ");
		Serial.println(chpt);
		T_Temp = atof(chpt);
	}
	else {
		return;
	}

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		Serial.print("X_Position = ");
		Serial.println(chpt);
		X_Position = atof(chpt);
	}
	else {
		return;
	}

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		Serial.print("V_Vitess = ");
		Serial.println(chpt);
		V_Vitess = atof(chpt);
	}
	else {
		return;
	}

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		Serial.print("R_Rayon = ");
		Serial.println(chpt);
		R_Rayon = atof(chpt);
	}
	else {
		return;
	}

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		Serial.print("O_PositionAng = ");
		Serial.println(chpt);
		O_PositionAng = atof(chpt);
	}
	else {
		return;
	}

	chpt = strtok(NULL, "|");
	if (chpt != NULL) {
		Serial.print("W_VitessAng = ");
		Serial.println(chpt);
		W_VitessAng = atof(chpt);
	}
	else {
		return;
	}
}

void StartRobot()                              // go function
{
	switch (Robot)
	{
	case 0:
		SetConfiguration();
		break;
	case 1:
		StartRobo1Experiences();
		break;
	case 2:
		StartRobo2Experiences();
		break;
	case 3:
		break;
	}
}

void StartRobo1Experiences()                              // go function
{
	switch (Experience)
	{
	case 1:
	case 2:
		Robo1Exp1_2();
		break;
	case 3:
	case 4:
		Robo1Exp3_4();
		break;
	}
}

void StartRobo2Experiences()                              // go function
{
	switch (Experience)
	{
	case 1:
		Robo1Exp1_2();
		break;
	case 2:
		Robo1Exp1_2();
		break;
	case 3:
		break;
	}
}

void SetConfiguration() {
	voltage = T_Temp;
	distance0 = X_Position;
	Serial.println("voltage = " + (String)voltage);
	Serial.println("distance = " + (String)distance0);
}

void go()                              // go function
{
	// Print out prompt for user.
	Serial.println("Choose an option:");  // Print a blank line
	Serial.println(" 0) Stop Motion");
	Serial.println(" 1) For Forward motion");
	Serial.println(" 2) For Backward Motion");
	Serial.println(" 3) Accelerate Motion");
	Serial.println(" 4) Decelerate Motion");

	Serial.print("Experience = ");
	Serial.println(Experience);
	switch (Experience)
	{
	case 1:
		ForwardMotion(PotentialPWM);       // Full speed forward
		break;
	case 2:
		BackwardMotion();     // Full speed backward
		break;
	case 3:
		ControlPotentialPWM(true);     // Accelerate Motion
		break;
	case 4:
		ControlPotentialPWM(false);     // Decelerate Motion
		break;
	case 0:
		StopMotion();       // Stop
		break;
	}
}


float calculateTraverseDistanse()
{
	// Duration will be the input pulse width and distance will be the distance to the obstacle in centimeters
	float duration, distance;

	// Output pulse with 1ms width on trigPin
	digitalWrite(trigPin, HIGH);
	delay(1);
	digitalWrite(trigPin, LOW);

	// Measure the pulse input in echo pin
	duration = pulseIn(echoPin, HIGH);

	// Distance is half the duration devided by 29.1
	distance = (duration / 2) / 29.1;
	return distance;
}

void ForwardMotion(int intPWM) {
	/*********For Forward motion*********/
	Serial.println("FORWARD Started");
	// this function will run the motors in both directions at a fixed speed
	digitalWrite(directionMotor2, LOW);
	digitalWrite(directionMotor1, LOW);
	// set speed to 200 out of possible range 0~255
	analogWrite(pwmMotor1, intPWM);
	analogWrite(pwmMotor2, intPWM);
}

void BackwardMotion() {
	/*********For Backward Motion*********/
	Serial.println("Backward  Started");
	digitalWrite(directionMotor1, HIGH);
	digitalWrite(directionMotor2, HIGH);
	analogWrite(pwmMotor1, PotentialPWM);
	analogWrite(pwmMotor2, PotentialPWM);
}

void ControlPotentialPWM(bool Accelerate) {
	/*********Control Potential PWM*********/
	if (Accelerate) {
		Serial.print("Potential PWM = ");
		Serial.println(PotentialPWM);
		PotentialPWM = PotentialPWM + 1;
	}
	else {
		Serial.print("Potential PWM = ");
		Serial.println(PotentialPWM);
		PotentialPWM = PotentialPWM - 1;
	}
}

void StopMotion() {
	/*********Stop*********/
	Serial.println("Motion Stopped ");
	analogWrite(pwmMotor1, 0);
	analogWrite(pwmMotor2, 0);
}

