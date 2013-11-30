using UnityEngine;
using System.Collections;


//GUIStyle, etc. to be used in game. 
public class ingameGUI : MonoBehaviour {

    public GUIStyle scoreStyle;
    public int xcoor = 10;
    public int ycoor = 10;
    public int health = 0; //change to a health bar later
    public int ammo = 0;
    public int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onGUI()
    {
        // Make the first button. Eventually a health bar.
        GUI.Button(new Rect(Screen.width /2 , ycoor + 15, 80, 20), "Health: " + health);

        // Make the second button. Ammo count.
        GUI.Button(new Rect(xcoor + 150, ycoor + 15, 80, 20), "Ammo: " + ammo);

        //third button. score
        GUI.Button(new Rect(xcoor + 270, ycoor + 15, 80, 20), "SCORE: " + score, scoreStyle);
    }
}
