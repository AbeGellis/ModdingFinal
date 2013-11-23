using UnityEngine;
using System.Collections;

/* Brian Kang
 * 11-21-13
 * update GUI: kills/score, timer, health, ammo.
 */
public class GUIupdate : MonoBehaviour {
	
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
	
	void OnGUI() {
		// Make a background box
		GUI.Box(new Rect(xcoor,ycoor, 600, 40), "Example Stats");

		// Make the first button. Eventually a health bar.
		GUI.Button(new Rect(xcoor+30,ycoor+15,80,20), "Health: " + health);
		
		// Make the second button. Ammo count.
		GUI.Button(new Rect(xcoor + 150, ycoor + 15,80,20), "Ammo: " + ammo);
		
		GUI.Button(new Rect(xcoor+270, ycoor+15, 80, 20), "SCORE: " + score);
		
		GUI.Label (new Rect (10,40,100,20), GUI.tooltip);
		
		// Make third button. Energy/oil count.
	}
}
