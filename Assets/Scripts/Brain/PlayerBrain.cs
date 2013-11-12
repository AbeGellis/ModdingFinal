using UnityEngine;
using System.Collections;

//Controls player based on key/mouse input
public class PlayerBrain : Brain {
	
	public KeyCode forward;
	public KeyCode back;
	public KeyCode left;
	public KeyCode right;
	
	//Considers the environment 
	override public void Update () {
		base.Update();
		
		if (Input.GetKey(forward))
			body.Move(Vector3.forward);
		if (Input.GetKey(back))
			body.Move(-Vector3.forward);
		if (Input.GetKey(left))
			body.Move(Vector3.left);
		if (Input.GetKey(right))
			body.Move(Vector3.right);
	}
}
