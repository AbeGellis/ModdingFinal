using UnityEngine;
using System.Collections;

//Controls a simple character that follows the player
public class FollowBrain : Brain {
	
	public float turnSpeed;	//Speed the character turns to face the player
	
	public float closeDistance; //Distance from the player where the character stops following
	public float farDistance;	//Distance from the player where the character starts following
	
	bool following = true;	//Whether or not the character is following
	
	override public void Update () {
		base.Update();

		if (CharacterControl.player != null) {

			//Vector describing difference between player/character positions
			Vector3 toPlayer = CharacterControl.player.transform.position - body.transform.position;
			
			//Turn to face player
			Look(toPlayer, turnSpeed);
			
			if (following) {	//Follows until too close
				if (toPlayer.magnitude < closeDistance)
					following = false;
				else {
					//Only follow if looking in player's general direction
					if (Vector3.Angle(toPlayer, transform.forward) < 45f)	{
						body.Move(body.transform.forward);
						print ("Moving");
					}
				}
			}
			else {	//Waits until too far
				if (toPlayer.magnitude > farDistance)
					following = true;
			}
		}
	}
}
