using UnityEngine;
using System.Collections;


//Moves the character around based on the brain
public class CharacterControl : MonoBehaviour {
	
	public float groundSpeed;	//Acceleration on the ground
	public float maxSpeed;		//Maximum velocity
	
	public float stopSpeed = .2f;	//Minimum threshold to keep moving
	public float drag = 2f; 		//Friction while grounded
	
	bool grounded;	//On ground or not
	
	Vector3 horizontalMove = Vector3.zero;	//Current movement impetus
	
	
	Vector3 lookChange = Vector3.zero;	//Change in look direction each frame
	
	Vector3 flatten = new Vector3(1f, 0f, 1f);	
	
	//Brain sends movement commands
	public Brain brain;
	
	void Awake() {
		brain.Assign(this);
	}
	
	//Applies given movement to movement in next update
	public void Move(Vector3 move) {
		horizontalMove += move;
	}
	
	public void Jump(float force) {
		rigidbody.AddForce(Vector3.up * force, ForceMode.VelocityChange);
	}
	
	//Applies given rotation to direction in next update
	public void Look(Vector3 changeAngles) {
		lookChange += changeAngles;
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
	
	void FixedUpdate() {
		horizontalMove.Scale(flatten);
		Vector3 hor = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z) + horizontalMove.normalized;
		
		//Apply current rotation
		transform.Rotate(0f, lookChange.y, lookChange.z);
		
		//Apply current movement
		rigidbody.AddForce(horizontalMove.normalized * groundSpeed, ForceMode.VelocityChange); 
		
		//Grounded check
		Vector3 colliderBottom = collider.bounds.center + new Vector3(0f, collider.bounds.extents.y, 0f);
		Ray checkGround = new Ray(colliderBottom, Vector3.down);
		RaycastHit groundInfo = new RaycastHit();
		grounded = collider.Raycast(checkGround, out groundInfo, 0.4f);
		
		//Friction while grounded
		if (grounded)
			rigidbody.drag = drag;
		else
			rigidbody.drag = 0f;
		
		
		//Cap speed
		if (hor.magnitude > maxSpeed)
			rigidbody.velocity = new Vector3(rigidbody.velocity.x * maxSpeed / hor.magnitude, rigidbody.velocity.y,
				rigidbody.velocity.z * maxSpeed / hor.magnitude);
		
		//Reset movement input
		horizontalMove = Vector3.zero;
		lookChange = Vector3.zero;
	}
}
