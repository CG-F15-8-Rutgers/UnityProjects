using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clerkscript : MonoBehaviour {

	public Text spacetext;
	public Text talktext;
	private bool shot;
	public bool radius2;
	public static bool fire_ext;
	// Use this for initialization
	void Start () {
		talktext.text = "";
		spacetext.text = "";
		shot = false;
		radius2 = false;
		fire_ext = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) & shot == false & gold.havegold == false & gunsalesmen.gunbought == false & radius2 == true) {
			talktext.text = "THAT IS STEALING GET AWAY!";
		
			StartCoroutine (spacetimer ());
		} 
		if (Input.GetKeyDown (KeyCode.Space) & shot == false & gold.havegold == true & gunsalesmen.gunbought == false & radius2 == true) {
			talktext.text = "That is not enough money pleb.";
			StartCoroutine (spacetimer ());
		} 
		if (Input.GetKeyDown (KeyCode.Space) & shot == false & gold.havegold == true & gunsalesmen.gunbought == true & radius2 == true) {
			spacetext.text = "You shot the poor old Clerk.... Heartless";
			shot = true;
			fire_ext = true;
			StartCoroutine (spacetimer ());
		} 
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Unitychan") {
			radius2 = true;
		}

	}
	void OnTriggerStay(Collider other){

		if (other.tag == "Unitychan" & shot == false & gold.havegold == false & gunsalesmen.gunbought == false) {
			spacetext.text = "Take the Fire Extinguisher";

		}

		if (other.tag == "Unitychan" & shot == false & gold.havegold == true & gunsalesmen.gunbought == false) {
			spacetext.text = "Buy the Fire Extinguisher";

		}
		if (other.tag == "Unitychan" & shot == false & gold.havegold == true & gunsalesmen.gunbought == true) {
			spacetext.text = "Shoot the Store Clerk";
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Unitychan") {
			radius2 = false;
			spacetext.text = "";
			talktext.text ="";
		}
	
	}

	IEnumerator buffer(){
		Debug.Log ("timer");
		yield return new WaitForSeconds (3);
		radius2 = true;
		spacetext.text = "";
	}	

	
	IEnumerator spacetimer(){
		Debug.Log ("timer");
		yield return new WaitForSeconds (2);
		talktext.text = "";

	}
}
