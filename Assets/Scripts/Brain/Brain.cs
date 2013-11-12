using UnityEngine;
using System.Collections;

//Controls a character - make child classes to make new AI patterns
//To implement a brain, create a prefab with only that script attached (if none exists)
//Transform controls look direction
public class Brain : MonoBehaviour {
	
	//Body this is attached to
	protected CharacterControl body;
	
	//Matches it to the body
	public void Assign(CharacterControl body) {
		this.body = body;
	}
	
	//Turns both the sight and the body
	protected void Look(Vector3 changeAngles) {
		transform.Rotate(changeAngles);
		body.Look(changeAngles);
	}
	
	//Override this for update-cycle logic
	virtual public void Update () {
		//Lets you see where the character is looking
		Debug.DrawRay(body.transform.position, transform.forward * 3f, Color.blue);
	}
}
