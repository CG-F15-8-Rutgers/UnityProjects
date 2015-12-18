using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fireblockade : MonoBehaviour {
	public GameObject firebox;
	public Transform firet;
	public Text fire;
	// Use this for initialization
	void Start () {
		fire.text = "";
	
	}
	
	// Update is called once per frame
	void Update () {
		if (firemenzone.fireout == true) {
			firebox.GetComponent<BoxCollider> ().enabled = false;
		
			firet.GetComponent<ParticleSystem>().enableEmission= false;
		}
	}
	void deactive(){

	}
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Unitychan") {
			fire.text = "The fire is too hot to get near!";
			StartCoroutine (spacetimer ());
		}
	}
	IEnumerator spacetimer(){
		Debug.Log ("timer");
		yield return new WaitForSeconds (3);
		fire.text = "";
		
	}
}
