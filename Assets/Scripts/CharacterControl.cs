using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Moves the character around based on the brain
public class CharacterControl : MonoBehaviour {

	public static CharacterControl player;					//The player entity (whatever has a playerbrain)
	public static List<CharacterControl> characters;		//Character container (tracks all characters)
	
	public float groundSpeed;	//Acceleration on the ground
	public float airSpeed;		//Acceleration in the air
	public float maxSpeed;		//Maximum velocity
	public float jumpForce;		//Strength of jumps
	public float jumpBoost;		//Strength of variable jumps
	
	public float stopSpeed = .2f;	//Minimum threshold to keep moving
	public float drag = 2f; 		//Friction while grounded
	
	bool grounded;	//On ground or not
	bool jump; //About to jump
	bool rise; //Rising with variable jumping
	
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

	public void TouchColorArea(ColorArea.CharColor touch) {
		brain.TouchColorArea(touch);
	}

	//Applies given movement to movement in next update
	public void Move(Vector3 move) {
		horizontalMove += move;
	}
	
	//Applies upward force
	public void Jump() {
		if (grounded) 
			jump = true;
	}
	
	public bool IsRising() {
		return rise;
	}
	
	//End variable jump
	public void StopRising() {
		rise = false;
	}
	
	//Applies given rotation to direction in next update
	public void Turn(Vector3 changeAngles) {
		lookChange += changeAngles;
	}

	void OnCollisionEnter(Collision collision) {
		CharacterControl character = collision.gameObject.GetComponent<CharacterControl>();
		if (character != null) {
			brain.TouchCharacter(character);
		}
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
		if (grounded)
			rigidbody.velocity += horizontalMove.normalized * groundSpeed;
		else
			rigidbody.velocity += horizontalMove.normalized * airSpeed;
		
		//Grounded check
		Ray checkGround = new Ray(transform.position, Vector3.down);
		
		grounded = (Mathf.Abs(rigidbody.velocity.y) < 2f && Physics.Raycast(checkGround, 1f) );
		
		//Apply jump
		if (jump) {
			jump = false;
			grounded = false;
			rise = true;
			//Ugly hacks
			rigidbody.velocity = Vector3.up * jumpForce + rigidbody.velocity;
		}
		
		//Apply rise
		if (rise) {
			if (rigidbody.velocity.y > 0f)
				rigidbody.velocity += Vector3.up * jumpBoost;
			else
				rise = false;
		}
		
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
