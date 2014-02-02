using UnityEngine;
using System.Collections;

/*Brian Kang
 * 11-26-13 update
 * added invisible walls to the level so that a misclick no longer applies. all misclick counts, etc have been commented out
 */
/*
 * 12-25-13 update
 * now a universal OnTriggerEnter() control. 
 */
public class endtrigger2 : MonoBehaviour
{
    public GameObject character;
    public Collider arena; //trigger for Brian's "fly" level
   // public Collider tutorial; //trigger for tutorial level
    public Collider testlevel; //trigger for Max's zombie level

    void OnTriggerEnter(Collider trig)
    {
        character.rigidbody.velocity = Vector3.zero;

        //load Max's "zombie" test level
        if (trig.tag.Equals("TestLevel")) {
            endtrigger.level = 1;
            endtrigger.levelLoaded();
        }

        if (trig.tag.Equals("Arena"))
        {
            endtrigger.level = 2;
            endtrigger.levelLoaded();
        }

       // if (trig == tutorial)
        //{
         //   endtrigger.level = 0;
          //  endtrigger.levelLoaded();
        //}
    }
}
