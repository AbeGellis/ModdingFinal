using UnityEngine;
using System.Collections;

// if player presses Q key, load the main menu scene (awkwardly called "Instructions")
public class escMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetKey(KeyCode.Q))
        {
            ScoreControl.score = 0;
            endtrigger.level = 0;
            Application.LoadLevel("titleScreen");

        }
	}
}
