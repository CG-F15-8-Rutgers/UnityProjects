using UnityEngine;
using System.Collections;

public class doorenterscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTriggerEnter(Collider other){
		other.transform.position = (-136,0,10);
	}
}
