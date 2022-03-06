using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This is going to be the controller for each button on the keyboard
public class ButtonController : MonoBehaviour { 
    [SerializeField] int number;
    [SerializeField] bool isBackSpace;
    [SerializeField] bool isEnter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void clicked()
    {
        if (!isEnter && !isBackSpace)
            transform.parent.SendMessage("addNumber", number);// A key containing digit
        if (isEnter)
            transform.parent.SendMessage("enter"); // Enter button
        if (isBackSpace)
            transform.parent.SendMessage("backspace"); // Backspace button
    }
}
