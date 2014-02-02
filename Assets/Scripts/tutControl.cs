using UnityEngine;
using System.Collections;

//manages controls for the tutorial scene.
public class tutControl : MonoBehaviour {

    //arena levels
    public GameObject floor1;
    public GameObject floor2;

    //check for enemy deaths
    public GameObject firstEnemy;
    public GameObject secondEnemy;

    public GameObject player;
    Vector3 respawnPt;

    int x = 1; //seconds to wait before respawn
    int count = 0; //control for the number of times player has respawned.

	// Use this for initialization
	void Start () {

        //calculate respawn point, which should be in the same point as the start except in a different arena
        respawnPt = player.transform.position + (floor2.transform.position - floor1.transform.position);
	}

	void Update () {
        //respawn player if first enemy is dead
        if (!firstEnemy && count == 0)
        {
            StartCoroutine(Respawn());
        }

        //Q to go back to main menu
        if (Input.GetKey(KeyCode.Q))
            Application.LoadLevel("titleScreen");

        if (!secondEnemy)
        {
            Application.LoadLevel("titleScreen");
        }
	}

    //wait x seconds before respawn
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(x);
        count++; //so that player is not stuck in the same position
        player.transform.position = respawnPt;

        //change color back to default for arena2
        CharacterControl character = player.gameObject.GetComponent<CharacterControl>();
        character.setColor = ColorArea.CharColor.None;
    }
}
