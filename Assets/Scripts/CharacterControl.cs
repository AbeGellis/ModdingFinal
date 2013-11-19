using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Moves the character around based on the brain
public class CharacterControl : MonoBehaviour {

	public static CharacterControl player;					//The player entity (whatever has a playerbrain)
	public static List<CharacterControl> characters;		//Character container (tracks all characters)
	
	public float groundSpeed;	//Acceleration on the ground
	public float maxSpeed;		//Maximum velocity
	public float jumpForce;		//Strength of jumps
	
	public float stopSpeed = .2f;	//Minimum threshold to keep moving
	public float drag = 2f; 		//Friction while grounded
	
	bool grounded;	//On ground or not
	
	Vector3 horizontalMove = Vector3.zero;	//Current movement impetus
	
	Vector3 lookChange = Vector3.zero;	//Change in look direction each frame
	
	Vector3 flatten = new Vector3(1f, 0f, 1f);	
	
	//Brain sends movement commands
	public Brain brain;
	
	void Awake() {
		characters = new List<CharacterControl>();
		characters.Add(this);
		brain.Assign(this);
	}
	
	//Applies given movement to movement in next update
	public void Move(Vector3 move) {
		horizontalMove += move;
	}
	
	//Applies upward force
	public void Jump() {
		print (grounded);
		if (grounded)
			rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
	}
	
	//Applies given rotation to direction in next update
	public void Turn(Vector3 changeAngles) {
		lookChange += changeAngles;
	}
	
	void Update() {
		brain.Update();
	}
	
	void FixedUpdate() {
		horizontalMove.Scale(flatten);
		Vector3 hor = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z) + horizontalMove.normalized;
		
		//Apply current rotation
		transform.Rotate(Vector3.up, lookChange.x);
		
		//Apply current movement
		rigidbody.AddForce(horizontalMove.normalized * groundSpeed, ForceMode.VelocityChange); 
		
		//Grounded check
		Vector3 colliderBottom = collider.bounds.center - new Vector3(0f, collider.bounds.extents.y, 0f);
		Ray checkGround = new Ray(transform.position, Vector3.down*2);
		Debug.DrawRay(transform.position, Vector3.down*2, Color.black);
		
		RaycastHit groundInfo = new RaycastHit();
		grounded = Physics.Raycast(checkGround, out groundInfo, 1.5f);
		
		//Friction while grounded
		if (grounded)
			rigidbody.drag = drag;
		else
			rigidbody.drag = 0f;
		
		//Static friction to prevent slipping when not moving - placed here to prevent microslipping
		if (rigidbody.velocity.magnitude > 0f && rigidbody.velocity.magnitude < stopSpeed
			&& horizontalMove == Vector3.zero) {
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation |
				RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		}
		else
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		
		
		
		//Cap speed
		if (hor.magnitude > maxSpeed)
			rigidbody.velocity = new Vector3(rigidbody.velocity.x * maxSpeed / hor.magnitude, rigidbody.velocity.y,
				rigidbody.velocity.z * maxSpeed / hor.magnitude);
		
		//Reset movement input
		horizontalMove = Vector3.zero;
		lookChange = Vector3.zero;
	}
}
