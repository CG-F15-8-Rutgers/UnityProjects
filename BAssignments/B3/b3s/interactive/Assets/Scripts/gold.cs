using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gold : MonoBehaviour {
	public GameObject gold_coins;
	public Text goldtext;
	public Transform goldtransform;
	public static bool havegold;
	// Use this for initialization
	void Start () {
		goldtext.text = "";
		havegold = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		goldtransform.position = new Vector3(100,100,100);
		goldtext.text = "+25 Gold Shillings";
		havegold = true;
		StartCoroutine (goldtimer ());

		}

	IEnumerator goldtimer(){
		Debug.Log ("timer");
		yield return new WaitForSeconds (3);
		goldtext.text = "";
	}
}
