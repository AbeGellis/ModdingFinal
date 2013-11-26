using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlightPathControl : MonoBehaviour {
	public static List<FlightPathNode> nodes = new List<FlightPathNode>();	//All nodes in the scene

	// Update is called once per frame
	void Update () {
		Queue<FlightPathNode> toUpdate = new Queue<FlightPathNode>();

		//Initial loop - reset distances, check 
		foreach (FlightPathNode n in nodes) {
			n.dist = int.MaxValue;

			RaycastHit sightLine = new RaycastHit();
			Physics.Raycast(n.transform.position, CharacterControl.player.transform.position - n.transform.position, out sightLine);
			if (sightLine.collider.transform == CharacterControl.player.collider.transform) {
				n.dist = 1;
				toUpdate.Enqueue(n);
			}
		}

		//Simple breadth-first search
		while (toUpdate.Count > 0) {
			FlightPathNode current = toUpdate.Dequeue();
			foreach (FlightPathNode n in current.neighbors) {
				if (n.dist > current.dist + 1) {
					n.dist = current.dist + 1;
					toUpdate.Enqueue(n);
				}
			}
		}

	}
}
