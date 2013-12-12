using UnityEngine;
using System.Collections;

public class ParticleClean : MonoBehaviour {
	void Update () {
		if (!particleSystem.isPlaying)
			Destroy(gameObject);
	}
}
