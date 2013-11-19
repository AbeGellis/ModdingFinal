using UnityEngine;
using System.Collections;

/* Brian Kang
 * 11-13-13
 * testing GUI look/feel
 */
public class GUItest : MonoBehaviour {
	
	public int xcoor = 10;
	public int ycoor = 10;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		// Make a background box
		GUI.Box(new Rect(xcoor,ycoor,100,90), "Loader Menu");

		// Make the first button. Eventually a health bar.
		GUI.Button(new Rect(xcoor+10,ycoor+30,80,20), "Level 1");
		
		// Make the second button. Ammo count.
		GUI.Button(new Rect(20,70,80,20), "Level 2");
		
		// Make third button. Energy/oil count.
	}
}
