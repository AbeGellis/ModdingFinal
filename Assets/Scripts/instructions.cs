using UnityEngine;
using System.Collections;

/*
 * 11-22-13
 * Change the color of the text on mouseover, click loads the instructions scene
 * idea: have splahes of paint appear on the screen on mouseover (how to implement?)
 * */
public class instructions : MonoBehaviour {
	
	public TextMesh instruct;
	Color newColor;
	Color startColor;
	
	// Use this for initialization
	void Start () {
		
		startColor = instruct.color;
		newColor = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
		//original color of text if not on mouseover
		instruct.color = startColor;
		
		//construct ray, raycast
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit = new RaycastHit();
		
		// if rayHit = sheep
		if (Physics.Raycast (ray, out rayHit, 10000f))
		{
			//change the color of the text on mouseover
			if (rayHit.collider.tag == "instructions")
			{
				instruct.color = newColor;
				
				//load instructions screen on click
				if(Input.GetMouseButtonDown(0))
				{
					Application.LoadLevel (1);
				}
			}
		
		}
		
	}
}
