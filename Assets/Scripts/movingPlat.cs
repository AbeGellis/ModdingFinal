using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//move platform across the arena.

public class movingPlat : MonoBehaviour {

    //temp game object describing end position
    public GameObject ender;

	List<GameObject> riders;

    Vector3 start;
    Vector3 end;

    public bool switchCount; //switch from start to end. apparently there is already a var called "switch" so this is the new name
    public float speed = 5f; //speed of object
    
	
	// Use this for initialization
	void Start () {
        //set start, end positions
		riders = new List<GameObject>();
        start = transform.position;
        end = ender.transform.position;
        Destroy(ender);
	}
	
	// Update is called once per frame
    void Update()
    {

	    if (transform.position == start)
	        switchCount = true;
	    else if (transform.position == end)
	        switchCount = false;

	    //if the object is in the end position, go to start and vice versa


		Vector3 positionChange = transform.position;

	    if (switchCount)
	        transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime);

	    else
	        transform.position = Vector3.MoveTowards(transform.position, start, speed * Time.deltaTime);

		positionChange = transform.position - positionChange;

		foreach (GameObject g in riders) {
			g.transform.position += positionChange;
		}
    }

	void OnCollisionEnter(Collision collisionInfo) {
		if (collisionInfo.gameObject.GetComponent<CharacterControl>() != null) {
			riders.Add(collisionInfo.gameObject);
		}
	}

	void OnCollisionExit(Collision collisionInfo) {
		if (riders.Contains(collisionInfo.gameObject)) {
			riders.Remove(collisionInfo.gameObject);
		}
	}
}
