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
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log (hit.point);
				agent.SetDestination(hit.point);
			}
		}
	}
}
