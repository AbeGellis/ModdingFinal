using UnityEngine;
using System.Collections;

/*
 * Brian Kang 
 * 11-10-13
 * Click to move to some location in the overworld. Question: what happens when Application.LoadLevel is called? Basically, can I use a bool for # times mouse is clicked?
 */
public class clicktoMove : MonoBehaviour {
	
	//stopping distance, which if exceeded does not give the move command
	//static float STOPPING_DISTANCE = 0f; 
	
	//initialize destination and direction vectors ahead of time
	Vector3 destination = new Vector3(388f, 3f, 140f); 
	Vector3 direction;
    float speed = 40f;
	public bool mouseClicked = false;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void fixedUpdate () {
	}
	
	void Update()
	{	
		//camera is oriented backwards. should change that later

		//create ray from the camera to the point on the world where player wants object to move
		Ray ray_cursor = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit = new RaycastHit();
		
		//when left mouse button is pressed and ray hits something, move the object
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray_cursor, out rayHit, 1000f) && mouseClicked == false)
		{
			//if the mouse was clicked before, do not go. Do not interfere with movement once it has started. OnTriggerEnter() should have mouseClick controls.
			mouseClicked = true;
			
			//set destination and direction
			destination = rayHit.point;
			direction = Vector3.Normalize(destination - transform.position);
			
			//move the object toward the destination at a certain speed
			rigidbody.AddForce(direction * speed, ForceMode.VelocityChange);
			
			//test if the raycast is working properly
			//Debug.DrawRay (transform.position, destination, Color.blue);
		} 
		
	}
	
}
