using UnityEngine;
using System.Collections;

/*
 * Brian Kang
 * 11-19-13
 * Script for moving a platform "diagonally" across the arena.
 * */

public class movingPlat : MonoBehaviour {
	int count = 0;
	Ray ray;
	Vector3 direction;
	public float speed = 5f;
	
	// Use this for initialization
	void Start () {
		direction = transform.forward;
		//initial force
		rigidbody.AddForce (direction * speed, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate(){
		
		//ray pointing forward to test if there are objects ahead: MAKE SURE BOTS/PLAYERS ARE ON IGNORE RAYCAST LAYER
		ray = new Ray(transform.position, direction);
		RaycastHit rayHit = new RaycastHit();
		
		if (Physics.Raycast (ray, out rayHit, 20f))
		{
			//when the count is an even number, plat moves "forward"
			if (count % 2 == 0)
			{
				//plat stops and changes direction
				rigidbody.velocity = Vector3.zero;
				direction = transform.forward;
				
				//add force to plat, update count
				rigidbody.AddForce (direction * speed, ForceMode.VelocityChange); 
				count ++;
			}
			
			//when the count is an odd number, plat moves "backward"
			else
			{
				//plat stops and changes direction
				rigidbody.velocity = Vector3.zero;
				direction = -transform.forward;
				
				//add force to plat, update count
				rigidbody.AddForce (direction * speed, ForceMode.VelocityChange); 
				count++;
			}
		}
	}
}
