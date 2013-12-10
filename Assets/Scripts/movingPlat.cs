using UnityEngine;
using System.Collections;

//move platform across the arena.

public class movingPlat : MonoBehaviour {

    //temp game object describing end position
    public GameObject ender;

    Vector3 start;
    Vector3 end;

    public bool switchCount; //switch from start to end. apparently there is already a var called "switch" so this is the new name
    public float speed = 5f; //speed of object
    
	
	// Use this for initialization
	void Start () {
        //set start, end positions
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

            if (switchCount)
                transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime);

            else
                transform.position = Vector3.MoveTowards(transform.position, start, speed * Time.deltaTime);
    }
}
