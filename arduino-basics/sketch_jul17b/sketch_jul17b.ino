/*
  Button

 Turns on and off a light emitting diode(LED) connected to digital
 pin 13, when pressing a pushbutton attached to pin 2.


 The circuit:
 * LED attached from pin 13 to ground
 * pushbutton attached to pin 2 from +5V
 * 10K resistor attached to pin 2 from ground

 * Note: on most Arduinos there is already an LED on the board
 attached to pin 13.


 created 2005
 by DojoDave <http://www.0j0.org>
 modified 30 Aug 2011
 by Tom Igoe

 This example code is in the public domain.

 http://www.arduino.cc/en/Tutorial/Button
 */

// constants won't change. They're used here to
// set pin numbers:
const int buttonPin = 2;     // the number of the pushbutton pin
const int buttonPin2 = 5;     // the number of the pushbutton pin
const int buttonPin3 = 6;     // the number of the pushbutton pin
const int buttonPin4 = 7;     // the number of the pushbutton pin

const int ledPin =  13;      // the number of the LED pin

// variables will change:
int buttonState = 0;         // variable for reading the pushbutton status
int buttonState2 = 0;         // variable for reading the pushbutton status
int buttonState3 = 0;         // variable for reading the pushbutton status
int buttonState4 = 0;         // variable for reading the pushbutton status


void setup() {
  // initialize the LED pin as an output:
  pinMode(ledPin, OUTPUT);
  // initialize the pushbutton pin as an input:
  pinMode(buttonPin, INPUT);

  Serial.begin(9600);

  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
  establishContact();  // send a byte to establish contact until receiver responds
 
}

void loop() {


  if (Serial.available() >= 0) {


     // read the state of the pushbutton value:

      bool bt1  = false;
      bool bt2  = false;
      bool bt3  = false; 
      bool bt4 = false;


     /* 1st button */
            buttonState = digitalRead(buttonPin);
            if (buttonState == HIGH) {
              // turn LED on:
              digitalWrite(ledPin, HIGH);
              bt1 = true;
            } else {
              // turn LED off:
              digitalWrite(ledPin, LOW);
            }

             /* 2nd button */
            buttonState2 = digitalRead(buttonPin2);
            if (buttonState2 == HIGH) {
              // turn LED on:
              digitalWrite(ledPin, HIGH);
              bt2 = true;
            } else {
              // turn LED off:
              digitalWrite(ledPin, LOW);
            }

             /* 3rd button */
            buttonState3 = digitalRead(buttonPin3);
            if (buttonState3 == HIGH) {
              // turn LED on:
              digitalWrite(ledPin, HIGH);
              bt3 = true;
            } else {
              // turn LED off:
              digitalWrite(ledPin, LOW);
            }

             /* 4th button */
            buttonState4 = digitalRead(buttonPin4);
            if (buttonState4 == HIGH) {
              // turn LED on:
              digitalWrite(ledPin, HIGH);
              bt4 = true;
            } else {
              // turn LED off:
              digitalWrite(ledPin, LOW);
            }           

    encodeButtons(bt1, bt2, bt3, bt4);    
  }
}

void encodeButtons(bool b1, bool b2, bool b3, bool b4){
  
  // 0000 //

  char * btn1 = (b1) ? "0001" : "0000";
  char * btn2 = (b2) ? "0010" : "0000";
  char * btn3 = (b3) ? "0100" : "0000";
  char * btn4 = (b4) ? "1000" : "0000";

  int value1 = strtol(btn1, (char**) NULL, 2);
  int value2 = strtol(btn2, (char**) NULL, 2);
  int value3 = strtol(btn3, (char**) NULL, 2);
  int value4 = strtol(btn4, (char**) NULL, 2);


  int message = value1 + value2 + value3 + value4;

  

  Serial.println(message);
  
  
  
}


void establishContact() {
//  while (Serial.available() <= 0) {
//    Serial.print('A');   // send a capital A
//    delay(300);
//  }
}
