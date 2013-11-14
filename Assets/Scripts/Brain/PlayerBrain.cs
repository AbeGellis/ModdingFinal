using UnityEngine;
using System.Collections;

//Controls player based on key/mouse input
public class PlayerBrain : Brain {
	
	public KeyCode forward;
	public KeyCode back;
	public KeyCode left;
	public KeyCode right;
	
	public float mouseSensitivity = 1f;
	
	public Vector3 camOffset;
	
	Camera cam;
	
	//Input to controls
	override public void Update () {
		base.Update();
		
		//Assigns camera here because it wasn't working elsewhere
		if (cam == null)
			cam = Camera.main;
		
		//Movement
		if (Input.GetKey(forward))
			body.Move(body.transform.forward);
		if (Input.GetKey(back))
			body.Move(-body.transform.forward);
		if (Input.GetKey(left))
			body.Move(-body.transform.right);
		if (Input.GetKey(right))
			body.Move(body.transform.right);
		
		if (Input.GetKeyDown(KeyCode.Space))
			body.Jump();
		
		//Rotation - rotates character based on mouse and camera too (because body can't pitch, but camera should)
		Vector3 mouseDiff = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * mouseSensitivity;
		Look(new Vector3(-mouseDiff.y, mouseDiff.x, 0f));
		cam.transform.RotateAround(body.transform.position, body.transform.right, -mouseDiff.y);
		
		//Locks the cursor into the screen if the screen is active and the cursor is over it
		if (new Rect(0f, 0f, Screen.width, Screen.height).Contains(Input.mousePosition)) {
			Screen.lockCursor = true;
			
		
		}
	}
}
