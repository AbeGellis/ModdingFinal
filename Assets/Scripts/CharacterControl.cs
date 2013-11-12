using UnityEngine;
using System.Collections;


//Moves the character around based on the brain
public class CharacterControl : MonoBehaviour {
	
	public float groundSpeed;	//Acceleration on the ground
	public float maxSpeed;		//Maximum velocity
	
	public float stopSpeed = .2f;
	
	bool grounded;
	
	Vector3 horizontalMove = Vector3.zero;
	
	//Brain sends movement commands
	public Brain brain;
	
	void Start() {
		brain.Assign(this);
	}
	
	//Applies given movement to movement in next update
	public void Move(Vector3 move) {
		horizontalMove += move;
	}
	
	void Update() {
		brain.Update();
		
		//Static friction to prevent slipping when not moving - placed here to prevent microslipping
		if (rigidbody.velocity.magnitude > .00001f && rigidbody.velocity.magnitude < stopSpeed
			&& horizontalMove == Vector3.zero) {
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation |
				RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		}
		else
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
	}
	
	void FixedUpdate () {
		Vector3 hor = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z) + horizontalMove.normalized;
		
		//Apply current movement
		rigidbody.AddForce(horizontalMove.normalized * groundSpeed, ForceMode.VelocityChange); 
		
		//Cap speed
		if (hor.magnitude > maxSpeed)
			rigidbody.velocity = new Vector3(rigidbody.velocity.x * maxSpeed / hor.magnitude, rigidbody.velocity.y,
				rigidbody.velocity.z * maxSpeed / hor.magnitude);
		
		//Reset movement input
		horizontalMove = Vector3.zero;
	}
}
