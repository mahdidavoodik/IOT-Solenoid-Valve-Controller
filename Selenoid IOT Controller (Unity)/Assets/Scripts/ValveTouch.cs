using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveTouch : MonoBehaviour {
    Camera cam;
    Ray ray; //Used for detecting touch/mouse click positions
	void Start () {
        cam = Camera.main;
	}

	void Update () {
        if (Input.GetMouseButtonDown(0)) // To Detect starting of touch or mouse left button
        {
            //print(Input.mousePosition);
            ray = cam.ScreenPointToRay(Input.mousePosition); // A ray from camera to the touch position
        }
        if (Input.GetMouseButtonUp(0)) // to detect if the mousebutton is released or the touch has been finished
        {
            RaycastHit hit; // The raycast to detect the touched object
            if (Physics.Raycast(ray, out hit))
            {
                switch(hit.transform.tag){
                    case "Valve":
                        hit.transform.SendMessage("changeState"); // Changing the state of valve
                        break;
                    case "Button":
                        hit.transform.SendMessage("clicked"); // Changing the state of valve
                        break;
                    case "TcpButton":
                        if (hit.transform.GetComponent<TCPButton>().getConnect()) // to realize if it is connect button
                            transform.SendMessage("setupSocket"); // To setup tcp connection 
                        else
						    transform.SendMessage("closeSocket"); // To close tcp connection
                        break;
                }
            }
        }   
	}
}
