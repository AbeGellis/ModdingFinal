using UnityEngine;
using System.Collections;

/* Brian Kang
 * 11-19-13
 * testing overworld GUI/feel
 */
public class GUItest : MonoBehaviour {
	
	public int xcoor = 10;
	public int ycoor = 10;
	public int paper = 0;
	public int ammo = 0;
	public int food = 0;
	
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
		GUI.Button(new Rect(xcoor+30,ycoor+15,80,20), "Paper: " + paper);
		
		// Make the second button. Ammo count.
		GUI.Button(new Rect(xcoor + 150, ycoor + 15,80,20), "Ammo: " + ammo);
		
		// Make third button. Energy/oil count.
	}
}
