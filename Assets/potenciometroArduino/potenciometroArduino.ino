int Pin1 = A0;
int switchPin1 = 7; 
int data1;

void setup()
{
  Serial.begin(9600);
  pinMode(Pin1, INPUT);
  pinMode(switchPin1, INPUT);
}

void loop()
{
  data1 = analogRead(Pin1);
  Serial.println(data1);
  Serial.flush();
  delay(20);
  }
