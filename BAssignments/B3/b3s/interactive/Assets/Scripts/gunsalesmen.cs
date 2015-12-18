using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gunsalesmen : MonoBehaviour {

	public Text spacetext;
	public Text Talktext;
	public static bool gunbought;
	private bool radius = false;

	
	// Use this for initialization
	void Start () {
		Talktext.text = "";
		spacetext.text = "";
		gunbought = false;
		radius = false;
	}

	// Update is called once per frame
	void Update () {
		if (gold.havegold == true && radius == true && gunbought == false) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Talktext.text = "A cute pretty isnt it? Just dont shoot me with it.";
				gunbought = true;
			
				radius = false;
				StartCoroutine (buffer ());
			} 
		}
		if(gold.havegold == false && radius == true && gunbought == false){
			Debug.Log("nnonono");
			if (Input.GetKeyDown (KeyCode.Space)) {
				Talktext.text = "Dont make me shoot you. I DONT NEGOTIATE!";

				radius = false;
				StartCoroutine (buffer ());
			} 
		}


	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Unitychan" & gunbought == false) {
			radius = true;
		}

		if (other.tag == "Unitychan" & gunbought == false & radius == true) {
			Talktext.text = "Guns for Sale, only 25 Gold Coins. A BARGAIN.";
		}
	}
	void OnTriggerStay(Collider other){
		if (other.tag == "Unitychan" & gunbought == false & radius == true) {
			Talktext.text = "Guns for Sale, only 25 Gold Coins. A BARGAIN.";

		}
		if (other.tag == "Unitychan" & gunbought == false) {
			spacetext.text = "Buy Gun";
		}
	
	}
	void OnTriggerExit(Collider other){
	
		if (other.tag == "Unitychan") {
			spacetext.text = "";
			radius = false;
			Talktext.text = "";
		}
		
	}
	IEnumerator buffer(){
		Debug.Log ("timer");
		yield return new WaitForSeconds (4);
		radius = true;
		spacetext.text = "";
	}	

	
	IEnumerator spacetimer(){
		Debug.Log ("timer");
		yield return new WaitForSeconds (2);
		spacetext.text = "";
	}
}
