using UnityEngine;
using System.Collections;

public class agentscript : MonoBehaviour {
	public Transform target;
	public Transform target2;
	public Transform target3;
	public Transform target4;

	private bool secondspot;
	private bool thirdspot;
	private bool fourthspot;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent < NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (target4.position);

	}

}
