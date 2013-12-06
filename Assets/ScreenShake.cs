using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	public static float shakeTimer = 0f;
	public float shakeAmplitude = 1f;
	public float shakeSlowTime = 1f;
	public float shakeSpeed = 5f;

	void Start () {
	
	}

	void Update () {
		if (shakeTimer > 0f) {
			shakeTimer -= Time.deltaTime;
			transform.localPosition = new Vector3(Mathf.Sin(shakeTimer * shakeSpeed) * 
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
