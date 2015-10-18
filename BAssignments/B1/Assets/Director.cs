using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Director : MonoBehaviour {
	Camera camera;
	List<NavMeshAgent> agents;
	List<NavMeshObstacle> obstacles;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();
		agents = new List<NavMeshAgent> ();
		obstacles = new List<NavMeshObstacle> ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		foreach (NavMeshObstacle o in obstacles) {
			o.gameObject.transform.Translate(moveHorizontal, 0, moveVertical);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);

			if(Physics.Raycast(ray, out hit)){
				Transform objectHit = hit.transform;
				NavMeshAgent agent = null;
				NavMeshObstacle obstacle = null;
				if(objectHit.GetComponent<NavMeshAgent>()) {
					agent = objectHit.GetComponent<NavMeshAgent> ();
					int index = agents.FindIndex(a => {
						return agent == a;
					});
					Debug.Log (index);
					if(index != -1) {
						Debug.Log ("Unselecting agent");
						agents[index].BroadcastMessage("toggleSpeed");
					} 
					else {
						Debug.Log ("Selecting agent");
					}
				} else {
					foreach (NavMeshAgent a in agents) {
						a.BroadcastMessage("goToDestination", hit.point);
					}
				}
				
			}
		} else if (Input.GetMouseButtonDown (1)) {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				Transform objectHit = hit.transform;
				NavMeshAgent agent = null;
				NavMeshObstacle obstacle = null;

				Debug.Log (objectHit.GetComponent<NavMeshAgent>());
				if(objectHit.GetComponent<NavMeshAgent>()) {
					agent = objectHit.GetComponent<NavMeshAgent> ();
					int index = agents.FindIndex(a => {
						return agent == a;
					});
					Debug.Log (index);
					if(index != -1) {
						Debug.Log ("Unselecting agent");
						agents.RemoveAt (index);
					} else {
						Debug.Log ("Selecting agent");
						agents.Add(agent);
					}
				} else if (objectHit.GetComponent<NavMeshObstacle>()) {
					obstacle = objectHit.GetComponent<NavMeshObstacle>();
					int index = obstacles.FindIndex(o => {
						return obstacle == o;
					});
					if(index != -1) {
						Debug.Log ("Unselecting obstacle");
						obstacles.RemoveAt (index);
					} else {
						Debug.Log ("Selecting agent");
						obstacles.Add(obstacle);
					}
					
				}
			}
		}
	}
}
