int switchPin1 = 7;  // digital pin to attach the switch
int potenciometro = A0;
int dato1;
int dato2;

void setup()
{
  Serial.begin(9600);
  pinMode(switchPin1, INPUT);  // set digital pin 0 as input
  pinMode (potenciometro, INPUT);
  
}

void loop()
{
  dato1 = digitalRead(switchPin1);
  dato2 = analogRead(potenciometro);
  Serial.print(dato1);
  Serial.print(",");
  Serial.print(dato2);
  Serial.println();
  Serial.flush();
  delay(20);
  
}
