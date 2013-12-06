using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	static float shakeTimer;
	public float shakeAmplitude = 1f;
	public float shakeSlowTime = 1f;

	void Start () {
	
	}

	void Update () {
		if (shakeTimer > 0f) {
			shakeTimer -= Time.deltaTime;
			transform.localPosition = new Vector3(Mathf.Sin(shakeTimer) * 
                      shakeAmplitude * Mathf.Min(1f, shakeTimer/shakeSlowTime),
		              transform.localPosition.y, transform.localPosition.z);
		}
		else {
			shakeTimer = 0f;
			transform.localPosition = new Vector3(0f,
                      transform.localPosition.y, transform.localPosition.z);
		}
	}
}
