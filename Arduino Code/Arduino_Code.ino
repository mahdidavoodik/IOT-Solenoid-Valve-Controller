#include <SoftwareSerial.h>
int key1 = 12;  // set water valves 
int key2 = 13;
SoftwareSerial esp8266(2,3);// 2 ->RX   3->TX
char get_line[1024];  
int index;
void setup() { // This function only runs at the begining of code execution.
  pinMode(key1, OUTPUT); // initalize water valves as outputs.
  pinMode(key2, OUTPUT);
  esp8266.begin(115200);
  index = 0;
  Serial.begin(115200);
}
void loop() { // The loop function

  if (esp8266.available() > 0) // if wifi module is available
  {
    char c = esp8266.read(); // Read a charachter from wifi module
    Serial.write(c);  // Write this charachter in serial monitor
    get_line[index] = c;  // Save this charachter in get_line array
    index = index + 1;  // index is a counter for get_line array
    
    if (c == '\0'){  // if charachter c is '\0' -->  it is the end of the line so index1 counter and also i counter become to zero
      int index1 = 0;
      int i = 0;
      while (get_line[index1]!=':'){  // going forward until ':'
        index1 = index1 + 1;  // going forward index1 counter
      }
      index1 = index1 + 1; 

      //  check the middle charachter of the first command 
      if(abs(get_line[index1+1]-'f')<2) // tolerating few errors in recieved messages --> if it is true, the first command is off
        digitalWrite(key1, HIGH); // to close the first valv
      if(abs(get_line[index1+1]-'n')<2) // tolerating few errors in recieved messages --> if it is true, the first command is on
        digitalWrite(key1, LOW);  // to open the first valv

      //  check the middle charachter of the second command 
      if(abs(get_line[index1+3+1]-'f')<2) // tolerating few errors in recieved messages --> if it is true, the second command is off
        digitalWrite(key2, HIGH); // to close the second valv
      if(abs(get_line[index1+3+1]-'n')<2) // tolerating few errors in recieved messages --> if it is true, the second command is on
        digitalWrite(key2, LOW);  // to open the second valv
        
      for (i=index1 ; i<index-1 ; i=i+1){ // print from ':' to end of the line.
        Serial.write(get_line[i]);
      }
      index = 0;
    }
    if (index > 1024) // The max. of get-line array is 1024
      index = 0;
  }
  
  // It is for sending commands of serial monitor to wifi module
  if (Serial.available() > 0) // if serial monitor is available 
  {
    delay(1000);  // delay for 1 second
    String command = "";  
    while (Serial.available())  // if serial monitor is available 
    {
      command += (char)Serial.read(); // read charachters from serial monitor
 
    }
    esp8266.println(command);  // send command to wifi module
  }
 
}
