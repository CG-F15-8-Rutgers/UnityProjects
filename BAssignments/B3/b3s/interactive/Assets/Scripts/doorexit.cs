using UnityEngine;
using System.Collections;

public class doorexit : MonoBehaviour {
	public Transform Storeexit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

			
			Debug.Log ("Left Store");
			other.transform.position = Storeexit.position;

	}
}
