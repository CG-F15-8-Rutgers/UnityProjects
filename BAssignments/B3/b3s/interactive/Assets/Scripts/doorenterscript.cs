using UnityEngine;
using System.Collections;

public class doorenterscript : MonoBehaviour {
	public Transform Storeenter;
	void Update(){

	}

	void OnTriggerEnter(Collider other){

		other.transform.position = Storeenter.position;
		Debug.Log ("Entered Store");
		//other.transform.position = new Vector3(-136,0,10);
	}

}
