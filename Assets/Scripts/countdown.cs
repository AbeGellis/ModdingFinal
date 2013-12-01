using UnityEngine;
using System.Collections;

/*
 * 11-30-13
 * In-game timer. Start at 100 seconds, end game at 0 seconds. 
 * Additional: Gain time for killing enemies, lose time for dying.
 */
public class countdown : MonoBehaviour {

    public GUIText countdownTimer; //attach relevant GUIText in inspector
    int endTime;

	// Use this for initialization
	void Start () {
        //"floor" Time.deltaTime in order to have a clean int value to pass onto GUIText
        endTime = (int)Time.time + 100;
        countdownTimer.text = "" + endTime;
	}
	
	// Update is called once per frame
	void Update () {

        //calculate and pass timeLeft to string for display
        int timeLeft = endTime - (int)Time.time;
        countdownTimer.text = "" + timeLeft;

	
	}
}
