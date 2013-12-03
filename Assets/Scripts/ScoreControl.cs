using UnityEngine;
using System.Collections;

public class ScoreControl : MonoBehaviour {

	static public int score = 0;	//Means what it says - change ScoreControl.score to edit this

	void Start () {
	
	}

	void Update () {
		guiText.text = score.ToString();
	}
}
