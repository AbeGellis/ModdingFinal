using UnityEngine;
using System.Collections;

public class HoverControl : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		RaycastHit sightLine = new RaycastHit();

		float dist = float.MaxValue;
		Vector3 closest = Vector3.zero;
		foreach (FlightPathNode n in FlightPathControl.nodes) { 
			float distToNode = Vector3.Distance(n.transform.position, transform.position);
			if(distToNode > .1f && n.dist != int.MaxValue) {
				if (!Physics.Raycast(transform.position, n.transform.position - transform.position)) {
					float fullpath = distToNode + n.dist;
					if (fullpath < dist) {
						dist = fullpath;
						closest = n.transform.position;
					}
				}
			}

			Debug.DrawLine(transform.position, n.transform.position, Color.red);
		}

		Vector3 toPlayer = CharacterControl.player.transform.position - transform.position;

		Physics.Raycast(transform.position, toPlayer, out sightLine);
		if (sightLine.collider.transform.position == CharacterControl.player.transform.position)
			closest = CharacterControl.player.transform.position;

		if (closest != Vector3.zero) {
			Vector3 toClosest = closest - transform.position;
			if (toClosest.magnitude > Time.deltaTime)
				transform.Translate(toClosest.normalized*Time.deltaTime);
			else
				transform.Translate(toClosest);
		}
	}
}
