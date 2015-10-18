using UnityEngine;
using System.Collections;

public class SampleAgentScript : MonoBehaviour {
	public Camera camera;
	public Transform target;
	NavMeshAgent agent;
		
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}

	void goToDestination (Vector3 v) {
		agent.SetDestination (v);
	}
}
