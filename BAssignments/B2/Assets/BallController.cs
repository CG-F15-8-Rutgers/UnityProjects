using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	public GameObject ball;
	public GameObject earthPillar;
	public GameObject Daniel1Hand;
	public GameObject Daniel2Hand;
	public GameObject Daniel3Hand;
	private GameObject attached;
	
	// Use this for initialization
	void Start () {
		this.attached = earthPillar;
	}
	
	// Update is called once per frame
	void Update () {
		Transform attachedLocation = this.attached.transform;
		if(this.attached == earthPillar)
		{
			Vector3 temp = new Vector3(0,0.65f,0);
			ball.transform.position = attachedLocation.position + temp;
		}
		else if(this.attached == Daniel1Hand | this.attached == Daniel2Hand | this.attached == Daniel3Hand){
			ball.transform.position = attachedLocation.position;
		}
	}
}
