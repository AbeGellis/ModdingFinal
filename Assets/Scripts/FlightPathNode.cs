using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FlightPathNode : MonoBehaviour {
	static FlightPathControl controller;
	public List<FlightPathNode> neighbors = new List<FlightPathNode>();		//Nodes this node can see
	//List<int> neighborsDistances = new List<int>();		//Distance to each node

	public int dist = int.MaxValue;			//Distance to player
	bool setup = false;


	void Start () {
		//Create a controller if none exists
		if (controller == null) 
			controller = gameObject.AddComponent("FlightPathControl") as FlightPathControl;

		//Add to the overall list of nodes
		FlightPathControl.nodes.Add(this);
	}

	void Update () {
		//Populate the list of visible nodes by checking all previously created nodes for a line of sight
		//Done here instead of Start() to allow for colliders to intialize properly
		if (!setup) {
			foreach (FlightPathNode n in FlightPathControl.nodes) {
				if (n != this && !neighbors.Contains(n) && !Physics.Raycast(transform.position, n.transform.position - transform.position)) {
					n.neighbors.Add(this);
					neighbors.Add(n);
				}
			}
			setup = true;
		}
	}
}
