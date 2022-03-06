using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour {
    int number;
    [SerializeField] Text displayText;
    bool isLocked;
    [SerializeField] ValveController my_Valve;
    float tempTime;
    //int lastTime;
	// Use this for initialization
	void Start () {
        number = 0;
        showNumber();
        isLocked = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isLocked)
        {
            timer(); // To count down for the time to change the valve's state
        }
	}
    void timer()
    {
        tempTime -= Time.deltaTime; // Count down code
        if (number - tempTime > 0.5f) // To detect if it is the time to reduce the timer number by one
        {
            number -= 1;
            showNumber();  // To update the display's number
        }
    }
    public void addNumber(int addnumber)
    {
        if (!isLocked)
        {
            if (number < 1000) // The maximum number for the display's text is 9999
            {
                number = number * 10 + addnumber; // To make this the least significant digit of the number
            }
			showNumber(); // To update the display's number
        }
    }
    public void backspace()
    {
        if (!isLocked)
        {
			number = number / 10; // To omit the least significant digit of our number;
			showNumber(); // To update the display's number
        }
        else
        {
            CancelInvoke("changeState"); // To cancel invoking our function
            isLocked = false;
            changeTextColor(); // To  change the display's color
        }
    }
    public void enter()
    {
		if (!isLocked){ // Starting count down
            isLocked = true; // To lock the device
            //lastTime = number;
            tempTime = number; // Setting tempTime variable
			changeTextColor(); // To  change the display's color
			Invoke("changeState", number); // To invoke the function after 'number' seconds
        }
    }
    void changeState()
    {
        my_Valve.SendMessage("changeState"); // To inform the valve to change its state
		isLocked = false; // To unlock the device
		changeTextColor(); // To  change the display's color
    }
    void showNumber()
    {
        displayText.text = number.ToString(); // To change the integer to String in order to show it on our display
        //lastTime = number;
    }
    void changeTextColor()
    {
        if (isLocked)
        {
            displayText.color = Color.red; // Change the display's color to red
        }
        else
        {
			displayText.color = Color.black; // Change the display's color to black
        }
    }
}
