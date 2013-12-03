using UnityEngine;
using System.Collections;

/*
 * Brian Kang
 * 11-19-13
 * Script for moving a platform "diagonally" across the arena.
 * */

public class movingPlat : MonoBehaviour {
	int count;
	Ray ray;
	Vector3 direction;
	public float speed = 5f;
	
	// Use this for initialization
	void Start () {
        count = 0;
		direction = transform.forward;
		//initial force
		//rigidbody.AddForce (direction * speed, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
	    
        //ray pointing forward to test if there are objects ahead: MAKE SURE BOTS/PLAYERS ARE ON IGNORE RAYCAST LAYER
		ray = new Ray(transform.position, direction);
		RaycastHit rayHit = new RaycastHit();

        if (Physics.Raycast(ray, out rayHit, 20f))
        {
            if (count % 2 == 0)
            {
                //when the count is an even number, plat moves "forward"
               // rigidbody.velocity = Vector3.zero;
                transform.position += transform.forward * speed * Time.deltaTime;

                count++;
            }

            else
            {
                //when the count is odd, plat moves "backward"
                //rigidbody.velocity = Vector3.zero;
                transform.position += -transform.forward * Time.deltaTime;

                count++;
            }
        }
	}
	
	void FixedUpdate(){
		
		/*//ray pointing forward to test if there are objects ahead: MAKE SURE BOTS/PLAYERS ARE ON IGNORE RAYCAST LAYER
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
		}*/
	}
}
