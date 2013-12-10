using UnityEngine;
using System.Collections;

/*
 * 11-30-13
 * In-game timer. Start at x seconds, end game at 0 seconds. 
 * Additional: Gain time for killing enemies, lose time for dying.
 */
public class countdown : MonoBehaviour {

	//Abe Rewrite:
	public GUIText countdownTimer;
	public float startTime;
	public static float time = 0;

	public static bool gameOver;
	public float endTimer = 2f;

	//float scoreBonusCounter = 0f;

	void Start() {
		time = startTime;
		gameOver = false;
	}

	void Update() {
		/*scoreBonusCounter += Time.deltaTime;
		if (scoreBonusCounter > scoreBonusRate) {
			scoreBonusCounter -= scoreBonusRate;
			ScoreControl.score += 1;
		}*/

		if (!gameOver)
			time -= Time.deltaTime;
		else
			endTimer -= Time.deltaTime;

		countdownTimer.text = ((int) time).ToString();

		if (time <= 0f || endTimer <= 0f)
			Application.LoadLevel("GameOver");
	}

    /*public GUIText countdownTimer; //attach relevant GUIText in inspector
    int endTime;
    public int timerSet;

	// Use this for initialization
	void Start () {
        //"floor" Time.deltaTime in order to have a clean int value to pass onto GUIText
        timerSet = 40;
        endTime = (int)Time.time + timerSet;
        countdownTimer.text = "" + endTime;
	}
	
	// Update is called once per frame
	void Update () {

        //calculate and pass timeLeft to string for display
        int timeLeft = endTime - (int)Time.time;
        countdownTimer.text = "" + timeLeft;

        if (timeLeft <= 0)
            Application.LoadLevel("GameOver");
	
	}*/
}
