# IOT-Solenoid-Valve-Controller
An Arduino code with a mobile app interface for controlling two Solenoid valves made in Unity Game engine.
In our setup we ran the Arduino code on Arduino UNO Rev3 with a Wi-Fi esp8266 module for TCP/IP connection, breadbord, two Relays, and two Selenoid valves.
## Arduino Code
In our setup, We used an Arduino UNO Rev3 and connected the two pin number 12 and 13 to the two relays controlling the electrical flow going to the Selenoid valves.
Pins number 2 & 3 are connected to the Wi-Fi esp8266 module for recieving and sending data repectively.
The Arduino code creates a TCP server and the aforementioned Unity Project will make a TCP client and connect to it.
## Unity Project
The Unity project containes one scene, in which there are two keyboards for setting the timers for flipping each valve's state. 
You can run the Unity project on windows, Ios, or Android devices. 
We installed and ran the project on an HTC M8 phone.
Here is a demo showing the app and the timers functionality
![]("Valves-Unity-Demo.gif")
