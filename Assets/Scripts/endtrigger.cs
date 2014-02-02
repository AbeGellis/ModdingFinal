using UnityEngine;
using System.Collections;

/*Brian Kang
 * 11-26-13 update
 * added invisible walls to the level so that a misclick no longer applies. all misclick counts, etc have been commented out
 */

/* 12-25-13 update
 * now a control class for the triggers in overworld. level select purposes; in OnTriggerEnter call levelLoaded and change int using endtrigger.level
 */
public class endtrigger : MonoBehaviour {
	
    public static int level = 0;
    public GameObject character;

    //loads level according to value of level. again, change it using endtrigger.level
    public static void levelLoaded()
    {
        //if (level == 0)
        //    Application.LoadLevel("tutorial");
        if (level == 1)
            Application.LoadLevel("testlevel");

        if (level == 2)
            Application.LoadLevel("arena1");
    }
}
