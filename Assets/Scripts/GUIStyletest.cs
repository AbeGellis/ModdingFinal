using UnityEngine;
using System.Collections;

/*
 * 11-20-13
 * Intended as a test for using GUIStyles (specifically will be used with title scene when ready)
 * Not working yet; simply click anywhere to advance to level select. 
 * Eventually want the color of the text to change on mouseover, and load level on button click
 * Maybe display a graphic of paint splashes. Juiciness can come later.
 */
public class GUIStyletest : MonoBehaviour {

    public GUIStyle buttonStyle;
    int xcoor = 60;
    int ycoor = 145;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //construct ray, raycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit = new RaycastHit();

        // simply load the next level for now.
        if (Physics.Raycast(ray, out rayHit, 10000f))
        {
            //load instructions screen on click
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel("overworld");
            }
        }
            //change the color of the text on mouseover
           // if (rayHit.collider.tag == "instructions")
            //{
             //   instruct.color = newColor;

           // }
	
	}

    void OnGUI()
    {
        GUI.Button(new Rect(xcoor, ycoor, 100, 100), "INSTRUCTIONS", buttonStyle);
        GUI.Button(new Rect(xcoor, ycoor + 25, 100, 100), "LEVEL SELECT", buttonStyle);
        GUI.Button(new Rect(xcoor + 40, ycoor + 50, 100, 100), "PLAY", buttonStyle);
        //if( GUI.Button(new Rect(xcoor, ycoor, 100, 100), "INSTRUCTIONS", buttonStyle ));
        //{
        //    Application.LoadLevel("overworld");
       // }

    }
}
