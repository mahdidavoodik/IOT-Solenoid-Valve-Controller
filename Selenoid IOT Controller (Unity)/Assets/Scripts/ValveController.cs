using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValveController : MonoBehaviour {
    [SerializeField] string state;
    Animator animator;
    [SerializeField] Text tv;
    GameObject mainCamera;
	// Use this for initialization
	void Start () {
        state = "off"; // Initial state of valves
        animator = GetComponent<Animator>();
        mainCamera = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}
    public void changeState()
    {
        if (state == "off") // Valve is closed and we want to open it
        {
            state = "on "; // Changing state of valve
            // Running opening animation on valve
			animator.SetBool("Open", true);
            animator.SetBool("Close", false);
            // changing display's text
			tv.text = "On ";
        }
        else if (state == "on ")
        {
			state = "off";// Changing state of valve
			// Running closing animation on valve
            animator.SetBool("Close", true);
            animator.SetBool("Open", false);
			// changing display's text
			tv.text = "Off";
        }
        mainCamera.SendMessage("write"); // send the changes to the write funcition in tcpclient.cs in order to chnage the state of valves
    }

    public string getState(){ //‌ Returning the state string
        return state;
    }
}
