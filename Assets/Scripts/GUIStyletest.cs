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

    //xcoor and ycoor are the coordinates of the top left corner of GUIText rectangles
    int xcoor = 200;
    int ycoor = 370;

    //xoffset and yoffset describe the coordinates of text relative to "INSTRUCTIONS" which is on top.
    int yoffset = 75;
    int xoffset = 75;

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
        GUI.Button(new Rect(xcoor, ycoor + yoffset, 100, 100), "LEVEL SELECT", buttonStyle);
        GUI.Button(new Rect(xcoor + xoffset, ycoor + (yoffset * 2), 100, 100), "PLAY", buttonStyle);
        //if( GUI.Button(new Rect(xcoor, ycoor, 100, 100), "INSTRUCTIONS", buttonStyle ));
        //{
        //    Application.LoadLevel("overworld");
       // }

    }
}
