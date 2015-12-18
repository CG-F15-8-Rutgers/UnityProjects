using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class firemenzone : MonoBehaviour {
	public Text spacetext;
	public Text talktext;
	public bool radius;
	public bool firsttalk;
	public static bool fireout;
	public GameObject message;
	// Use this for initialization
	void Start () {
		radius = false;
		firsttalk = true;
		fireout = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) & clerkscript.fire_ext == false & firsttalk == true & radius == true) {
			talktext.text = "We dance so fast and hard, we created a fire!";
			firsttalk = false;
			StartCoroutine (spacetimer ());
		} 
		else if (Input.GetKeyDown (KeyCode.Space) & clerkscript.fire_ext == false & firsttalk == false & radius == true) {
			talktext.text = "This puny fire pales in comparison to the fire in our heart!";
			StartCoroutine (spacetimer ());
		} 
		else if (Input.GetKeyDown (KeyCode.Space) & clerkscript.fire_ext == true  & radius == true) {
			talktext.text = "You saved us, now LETS DANCE!";
			StartCoroutine (spacetimer ());
			fireout = true;

		}
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Unitychan") {
			radius = true;
		}
	}
	
	void OnTriggerStay(Collider other){
		if (other.tag == "Unitychan" & firsttalk == true & fireout == false) {
			spacetext.text = "What is going on?";
		}
		if (other.tag == "Unitychan" & firsttalk == false & fireout == false) {
			spacetext.text = "The fire is going to kill you!";
		}
		if (other.tag == "Unitychan" & clerkscript.fire_ext == true & fireout == false) {
			spacetext.text = "Put out the fire!";
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Unitychan") {
			radius = false;
			spacetext.text = "";
			talktext.text = "";
		}
	}
	
	IEnumerator spacetimer(){
		Debug.Log ("timer");
		yield return new WaitForSeconds (2);
		talktext.text = "";
		
	}
}