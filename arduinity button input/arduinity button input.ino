#include "Ardunity.h"
#include "DigitalInput.h"

DigitalInput dInput4(4, 5, true);
DigitalInput dInput1(1, 2, true);
DigitalInput dInput2(2, 7, true);
DigitalInput dInput3(3, 6, true);

void setup()
{
  ArdunityApp.attachController((ArdunityController*)&dInput4);
  ArdunityApp.attachController((ArdunityController*)&dInput1);
  ArdunityApp.attachController((ArdunityController*)&dInput2);
  ArdunityApp.attachController((ArdunityController*)&dInput3);
  ArdunityApp.resolution(256, 1024);
  ArdunityApp.timeout(5000);
  ArdunityApp.begin(115200);
}

void loop()
{
  ArdunityApp.process();
}
