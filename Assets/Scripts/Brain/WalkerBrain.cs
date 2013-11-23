using UnityEngine;
using System.Collections;

//Controls a character that follows the player without dropping off of platforms
public class WalkerBrain : Brain {
	
	public float turnSpeed;	//Speed the character turns to face the player
	
	public float closeDistance; //Maximum distance from the player where the character stops following
	public float farDistance;	//Minimum distance from the player where the character starts following
	
	public float sightDistance;	//Distance at which it can see the player
	
	bool following = true;	//Whether or not the character is following
	
	override public void Update () {
		base.Update();
		
		//Vector describing difference between player/character positions
		Vector3 toPlayer = CharacterControl.player.transform.position - body.transform.position;
		
		//Check to see if player is within view
		Ray sightLine = new Ray(body.transform.position, toPlayer);
		RaycastHit sightRay = new RaycastHit();
		Physics.Raycast(sightLine, out sightRay, toPlayer.magnitude);
		bool seesPlayer = (toPlayer.magnitude <= sightDistance && 
			(sightRay.collider.transform == CharacterControl.player.collider.transform));
		//Compares transforms because comparing colliders wasn't working.  Total hack.
		
		if (seesPlayer)
			Look(toPlayer, turnSpeed);	//Turn to face player
		
		if (following) {	//Follows until too close or about to fall off
			//Check for space to walk to
			Vector3 check = body.transform.forward;
			check.Scale(new Vector3(1f, 0f, 1f));
			check += Vector3.down;
			Ray checkGround = new Ray(transform.position, check);
			bool keepGoing = (Physics.Raycast(checkGround, 1.5f));
			
			if (!seesPlayer || !keepGoing || toPlayer.magnitude < closeDistance)
				following = false;
			else {
				//Only follow if looking in player's general direction
				if (Vector3.Angle(toPlayer, transform.forward) < 45f)	
					body.Move(body.transform.forward);
			}
		}
		else {	//Waits until too far
			if (toPlayer.magnitude > farDistance)
				following = true;
		}
	}
}
