using UnityEngine;
using System.Collections;
/*
 * Brian Kang
 * 11-19-13
 * Script meant to respawn (LATER = kill) player when they touch the water. 
 * */
public class waterDeath : MonoBehaviour {
	
	//Vector3 startPosition; //remember the player's starting position
   // public GameObject lifeObject;
  //  int count; //count number of times trigger has been entered.
	
	// Use this for initialization
	void Start () {
		//startPosition = CharacterControl.player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider swimmer)
	{
      //  count++;

		//"respawn" player when they hit the water
        /*if (swimmer.gameObject == CharacterControl.player.gameObject)
        {
            //delete a heart for every death.
            //    lifeControl.lives --;
            //     lifeObject.GetComponent<lifeControl>().removeHeart();

            //respawn player
            //	swimmer.gameObject.transform.position = startPosition;
            //     swimmer.rigidbody.velocity = Vector3.zero;

            //else
            Destroy(swimmer.gameObject);
            Application.LoadLevel("GameOver");
        }*/
		if (swimmer.gameObject.GetComponent<CharacterControl>() != null) {
			swimmer.gameObject.GetComponentsInChildren<Brain>()[0].Kill();
		}

        else
            Destroy(swimmer.gameObject);
	}
}
