using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;
using UnityEngine.UI;
public class TCPClient : MonoBehaviour
{
    internal Boolean socketReady = false;
    TcpClient mySocket; // Tcp client
    NetworkStream theStream;
    StreamWriter theWriter; // Tcp writer
    StreamReader theReader; // Tcp reader
    String Host = "192.168.4.1"; // Host's IP
    Int32 Port = 8888; // Connection port
    //public InputField message;
    [SerializeField] GameObject valve1, valve2;
    float time;
    void Start()
    {
    }
    void Update()
    {
        // Sending state of valves every 5 seconds
		if (socketReady)
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                time = time - 5;
                write(); // Writing state of valves on our tcp connection 
            }
        }
    }
    public void setupSocket()
    {
        try // Setting up the tcp socket
        {
            mySocket = new TcpClient(Host, Port);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            socketReady = true;
			write(); // Writing state of valves on our tcp connection 
        }
        catch (Exception e) // error
        {
            Debug.Log("Socket error: " + e);
        }
    }
    public void write()
    {
        //writeSocket(message.text);
        writeSocket(valve1.GetComponent<ValveController>().getState()
         + valve2.GetComponent<ValveController>().getState()); // calling writeSocket function to send the message to the server
    }
    public void writeSocket(string theLine)
    {
		if (!socketReady) // We are not connected
            return; 
        //String foo = theLine + "\r\n";
        String foo = theLine + "\n\0"; // adding necessary last bits to our message
        theWriter.Write(foo); // Sending the message
        theWriter.Flush(); // flushing our buffer
    }
    public String readSocket()
    {
		if (!socketReady)// We are not connected
            return "";
        if (theStream.DataAvailable)
            return theReader.ReadLine(); // Returning the message recieved
        return "";
    }
    public void closeSocket()
    {
		if (!socketReady) //We are not connected
            return;
        // closing our socket connection
		theWriter.Close();
        theReader.Close();
        mySocket.Close();
        socketReady = false;
    }
}