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

	}

    void OnGUI()
    {

        //clicking any of these buttons results in loading the relevant level
        if (GUI.Button(new Rect(xcoor-10, ycoor, 340, 50), " INSTRUCTIONS", buttonStyle))
            Application.LoadLevel("overworld");

        //to be replaced by a tutorial
        if (GUI.Button(new Rect(xcoor, ycoor + yoffset, 320, 60), " LEVEL SELECT", buttonStyle))
        {
            Application.LoadLevel("overworld");
        }

        if (GUI.Button(new Rect(xcoor + xoffset, ycoor + (yoffset * 2), 150, 50), " PLAY!", buttonStyle))
            Application.LoadLevel("testlevel");


    }
}
