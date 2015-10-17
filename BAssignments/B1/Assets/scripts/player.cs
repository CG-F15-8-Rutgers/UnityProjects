﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public Animator anim;
	public Rigidbody rbody;
	public Transform unitychan;

	private float inputH;
	private float inputV;
	private bool run;

	private Vector3 curLoc;
	private Vector3 prevLoc;
	private Vector3 newpos;

	private NavMeshAgent agent;
	private Vector3 curpos;
	private Vector3 lastpos;

	private bool isWalking;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody> ();
		unitychan = GetComponent<Transform> ();
		agent = GetComponent<NavMeshAgent> ();
		run = false;

		agent.SetDestination (new Vector3(0, 0, 0));
		isWalking = true;


	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown ("1")) {
			anim.Play("WAIT01",-1,0f);
		}
		if (Input.GetKeyDown ("2")) {
			anim.Play("WAIT02",-1,0f);
		}
		if (Input.GetKeyDown ("3")) {
			anim.Play("WAIT03",-1,0f);
		}
		if (Input.GetKeyDown ("4")) {
			anim.Play("WAIT04",-1,0f);
		}
		/*
		if (Input.GetMouseButtonDown (0)) {
			int n = Random.Range (0,2);
			if(n==0){
			anim.Play ("DAMAGED00",-1,0f);
			}
			else{
				anim.Play ("DAMAGED01",-1,0f);
			}
		}*/

		if (Input.GetKey (KeyCode.Space)) {
			anim.SetBool ("jump", true);
		} 
		else {
			anim.SetBool ("jump",false);
		}

		inputV = Input.GetAxis ("Vertical");
		inputH = Input.GetAxis ("Horizontal");


		anim.SetFloat ("inputH", inputH);
		anim.SetFloat ("inputV", inputV);
		anim.SetBool ("run", run);

		float moveX = inputH * 20f * Time.deltaTime;

		float moveZ = inputV * 80f * Time.deltaTime;
		unitychan.Rotate (0, inputH * 100 * Time.deltaTime, 0);

		if (moveZ <= 0f) {
			moveX = 0f;
		} 
		else if (run) {
			moveX*=3f;
			moveZ*=3f;
		}
		if (Input.GetKey (KeyCode.LeftShift)&&moveZ != 0f) {
			run = true;
		}
		else {
			run = false;
		}      
	
		rbody.velocity = transform.forward*moveZ;
		if (moveZ == 0f) {
			anim.SetBool ("stop", true);
		}
		else {
			anim.SetBool("stop",false);
		}

		if (!agent.pathPending) {
			if (agent.remainingDistance <= agent.stoppingDistance) {
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
					isWalking = false;
					anim.SetBool ("isWalking", false);
				}
			}
		} 

		
		if (isWalking) {
			//anim.Play ("WALK00_F", -1, 0f);
			Debug.Log ("is walking");
			anim.SetBool ("isWalking", true);
			if (Input.GetKey (KeyCode.LeftShift) && isWalking == true) {
				anim.SetBool ("run",true);
			}
			else{
				anim.SetBool ("run",false);
			}
			if (Input.GetKey (KeyCode.Space)) {
				anim.SetBool ("jump", true);
			} 
			else {
				anim.SetBool ("jump",false);
			}
		}



	


	}
}
