using UnityEngine;
using System.Collections;

// if player presses ESC, load the main menu scene (awkwardly called "Instructions")
public class escMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetKey(KeyCode.Q))
        {
            Application.LoadLevel("instructions");
        }
	}
}
