using UnityEngine;
using System.Collections;

public class Angryguy : MonoBehaviour {


	public Transform unitychan;
	private bool angry_talk;
	// Use this for initialization
	void Start () {
		angry_talk = false;
	}
	
	// Update is called once per frame
	void Update () {	
		Debug.Log (angry_talk);
		if (Input.GetKey (KeyCode.Space)) {
			if(angry_talk == true){
				//unitychan.BroadcastMessage("unitychanpos",unitychan.position);
				//Debug.Log ("talking");
			}
		} 

	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Unitychan") {
			Debug.Log ("In Angry Man Zone");
			angry_talk = true;
		}
		else {
		}

	}

	void OnTriggerExit(Collider other){

			Debug.Log ("Left Angry Man Zone");
			angry_talk = false;

	}

}
