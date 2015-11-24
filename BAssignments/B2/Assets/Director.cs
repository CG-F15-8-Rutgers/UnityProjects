using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Director : MonoBehaviour {
	Camera cam;
	List<NavMeshObstacle> obstacles;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		obstacles = new List<NavMeshObstacle> ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		foreach (NavMeshObstacle o in obstacles) {
			o.gameObject.transform.Translate(moveHorizontal/25, 0, moveVertical/25);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				Transform objectHit = hit.transform;
				NavMeshObstacle obstacle = null;
				if (objectHit.GetComponent<NavMeshObstacle>()) {
					obstacle = objectHit.GetComponent<NavMeshObstacle>();
					int index = obstacles.FindIndex(o => {
						return obstacle == o;
					});
					if(index != -1) {
						Debug.Log ("Unselecting obstacle");
						obstacles.RemoveAt (index);
					} else {
						Debug.Log ("Selecting obstacle");
						obstacles.Add(obstacle);
					}
					
				}
			}
		}
	}
}
