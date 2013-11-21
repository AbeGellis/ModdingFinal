using UnityEngine;
using System.Collections;

//Controls a character that follows the player without dropping off of platforms
public class WalkerBrain : Brain {
	
	public float turnSpeed;	//Speed the character turns to face the player
	
	public float closeDistance; //Distance from the player where the character stops following
	public float farDistance;	//Distance from the player where the character starts following
	
	bool following = true;	//Whether or not the character is following
	
	override public void Update () {
		base.Update();
		
		//Vector describing difference between player/character positions
		Vector3 toPlayer = CharacterControl.player.transform.position - body.transform.position;
		
		//Turn to face player
		Look(toPlayer, turnSpeed);
		
		
		
		if (following) {	//Follows until too close or about to fall off
			
			//Check for space to walk to
			Vector3 check = body.transform.forward;
			check.Scale(new Vector3(1f, 0f, 1f));
			check += Vector3.down;
			Ray checkGround = new Ray(transform.position, check);
			bool keepGoing = (Physics.Raycast(checkGround, 1.5f));
			Debug.DrawRay(transform.position, check, Color.green);
			
			if (!keepGoing || toPlayer.magnitude < closeDistance)
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
