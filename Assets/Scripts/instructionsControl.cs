using UnityEngine;
using System.Collections;

//code managing the instructions scene
public class instructionsControl : MonoBehaviour {

    public TextMesh advance;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
    void Update()
    {
        //"blink" the relevant text mesh
        bool oddeven = (int) Time.time % 2 == 0;
        advance.renderer.enabled = oddeven;
        
        //click to advance to tutorial level
        if (Input.GetMouseButton(0))
            Application.LoadLevel("tutorial");

        //Q to go back to main menu
        if (Input.GetKey(KeyCode.Q))
            Application.LoadLevel("titleScreen");
    }
}
