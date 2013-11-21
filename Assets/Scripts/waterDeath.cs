using UnityEngine;
using System.Collections;
/*
 * Brian Kang
 * 11-19-13
 * Script meant to respawn (LATER = kill) player when they touch the water. 
 * */
public class waterDeath : MonoBehaviour {
	
	Vector3 startPosition; //remember the player's starting position
	
	// Use this for initialization
	void Start () {
		startPosition = CharacterControl.player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider swimmer)
	{
		//"respawn" player when they hit the water
		if (swimmer.gameObject == CharacterControl.player.gameObject)
			swimmer.gameObject.transform.position = startPosition;
		else
			Destroy(swimmer.gameObject);
	}
}
