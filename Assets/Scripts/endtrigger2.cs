using UnityEngine;
using System.Collections;

/*Brian Kang
 *11-12-13
 * when player goes into trigger, kill velocity and load "testlevel"
 * should maybe change the script so that a misclick doesn't lead to loading a level automatically.
 */
public class endtrigger2 : MonoBehaviour
{

    public GameObject character;
    public clicktoMove mouseClicked;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        character.rigidbody.velocity = Vector3.zero;
        //change the mouseClicked bool in clicktoMove to false so that when overworld level loads again, movement can resume.
        mouseClicked.mouseClicked = false;

        //load Max's "zombie" test level
        Application.LoadLevel("testlevel");
    }
}
