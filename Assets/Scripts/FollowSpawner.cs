using UnityEngine;
using System.Collections;

public class FollowSpawner : MonoBehaviour {

	public float spawnCounter = 5f;
	public float spawnCycle = 10f;
	public float spawnSpread = 5f;	//radius of spawning area
	public GameObject spawnObject;
	public ColorArea.CharColor spawnColor = ColorArea.CharColor.None;	//None default, produces random 

	void Start () {
		
	}

	void Update () {
		spawnCounter -= Time.deltaTime;
		if (spawnCounter < 0f) {
			spawnCounter += spawnCycle;
			CharacterControl spawn = (Instantiate(spawnObject, transform.position + 
			                                     Vector3.Scale(Random.insideUnitSphere, new Vector3(1f, 0f, 1f)),
			                                     Quaternion.identity) as GameObject).GetComponent<CharacterControl>();

			if (spawnColor != ColorArea.CharColor.None)
				spawn.setColor = spawnColor;
			else
				spawn.setColor = ColorArea.RandomColor();
		}
	}
}
