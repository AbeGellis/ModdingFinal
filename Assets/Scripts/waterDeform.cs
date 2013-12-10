using UnityEngine;
using System.Collections;

public class waterDeform : MonoBehaviour {
	
	MeshFilter mf;
    Vector3[] baseVertices;
	Vector3[] workingCopy;
	float waveHeight = 0.01f;
	float waveSpeed = 3f;
	
	// Use this for initialization
	void Start () {
		mf = GetComponent<MeshFilter>();
		baseVertices = mf.mesh.vertices;
	}
	
	// Update is called once per frame
	void Update () {
		//every frame, start with a fresh copy of the untouched plane's vertices
		workingCopy = baseVertices;
		
		for(int i = 0; i < workingCopy.Length; i++)
		{
			//every vertex in the model will now be moved according to the sine wave
			workingCopy[i] = baseVertices[i] + Vector3.up * Mathf.Sin ((Time.time + i)* waveSpeed) * waveHeight;
		}
		
		//put data back into mesh filter
		mf.mesh.vertices = workingCopy;
		
		//recalculate normals
		mf.mesh.RecalculateNormals();
		
		//visualize normals
		//for (int i = 0; i < mf.mesh.vertices.Length; i++) 
		//{
		//	Debug.DrawRay(mf.mesh.vertices[i], mf.mesh.normals[i]);
		//}
	}
}
