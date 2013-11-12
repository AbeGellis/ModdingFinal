using UnityEngine;
using System.Collections;

//Controls a character - make child classes to make new AI patterns
//To implement a brain, create a prefab with only that script attached (if none exists)
public class Brain : MonoBehaviour {
	
	//Body this is attached to
	protected CharacterControl body;
	
	//Matches it to the body
	public void Assign(CharacterControl body) {
		this.body = body;
	}
	
	//Override this for update-cycle logic
	virtual public void Update () {
	}
}
