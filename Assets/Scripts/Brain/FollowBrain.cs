using UnityEngine;
using System.Collections;

//Controls a simple character that follows the player
public class FollowBrain : Brain {
	
	public float turnSpeed;	//Speed the character turns to face the player
	
	public float closeDistance; //Distance from the player where the character stops following
	public float farDistance;	//Distance from the player where the character starts following
	
	override public void Update () {
		base.Update();
		Vector3 toPlayer = CharacterControl.player.transform.position - body.transform.position;
		Look(toPlayer, turnSpeed);
	}
}
