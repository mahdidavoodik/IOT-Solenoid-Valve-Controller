using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCPButton : MonoBehaviour {
    bool isConnect; // To realize the type of our button (Connect or disconnect)
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool getConnect(){
		return isConnect;
	}

}
