using UnityEngine;
using System.Collections;
using System;
using TreeSharpPlus;

using RootMotion.FinalIK;
public class Breakdancers : MonoBehaviour {
	

	public GameObject daniel1;
	public GameObject daniel2;
	public GameObject daniel3;
	public BehaviorAgent behavioragent;
	// Use this for initialization
	void Start () {
		behavioragent = new BehaviorAgent (this.BuildTreeRoot ());
		BehaviorManager.Instance.Register (behavioragent);
		behavioragent.StartBehavior ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	

	protected Node ST_LookAtAndWave()
	{
		Vector3 p1 = daniel1.transform.position;
		Vector3 p2 = daniel2.transform.position;
		Vector3 p3 = daniel3.transform.position;
		return
			new SelectorShuffle(
				new Sequence(daniel1.GetComponent<BehaviorMecanim>().ST_TurnToFace(p2),
			             daniel2.GetComponent<BehaviorMecanim>().ST_TurnToFace(p1),
			             new LeafWait(1000),
			             daniel1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             daniel2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             daniel1.GetComponent<BehaviorMecanim>().ST_TurnToFace(p3),
			             daniel3.GetComponent<BehaviorMecanim>().ST_TurnToFace(p1), 
			             new LeafWait(1000),
			             daniel1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             daniel3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             daniel1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             daniel3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             daniel2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false)),
				new Sequence(daniel2.GetComponent<BehaviorMecanim>().ST_TurnToFace(p1),
			             daniel1.GetComponent<BehaviorMecanim>().ST_TurnToFace(p2),
			             new LeafWait(1000),
			             daniel2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             daniel1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             daniel2.GetComponent<BehaviorMecanim>().ST_TurnToFace(p3),
			             daniel3.GetComponent<BehaviorMecanim>().ST_TurnToFace(p2),
			             new LeafWait(1000),
			             daniel2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             daniel3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             daniel1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             daniel3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             daniel2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false)),
				new Sequence(daniel3.GetComponent<BehaviorMecanim>().ST_TurnToFace(p1),
			             daniel1.GetComponent<BehaviorMecanim>().ST_TurnToFace(p3),
			             new LeafWait(1000),
			             daniel3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             daniel1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             daniel3.GetComponent<BehaviorMecanim>().ST_TurnToFace(p2),
			             daniel2.GetComponent<BehaviorMecanim>().ST_TurnToFace(p3),
			             new LeafWait(1000),
			             daniel3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             daniel2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             daniel1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             daniel3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             daniel2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false))
				);
	}
	protected Node ST_breakdance(){
		return new Sequence(daniel1.GetComponent<BehaviorMecanim>().Node_BodyAnimation("BreakDance",true),
		                    daniel2.GetComponent<BehaviorMecanim>().Node_BodyAnimation("BreakDance",true),
		                    daniel3.GetComponent<BehaviorMecanim>().Node_BodyAnimation("BreakDance",true));
	}

	
	
	protected Node BuildTreeRoot(){
		return
			new Sequence (
				this.ST_LookAtAndWave (),
				new LeafWait (2000),
				//this.ST_PickUp(this.sphere, this.ball),
				new DecoratorLoop (
				this.ST_breakdance()//,
				//this.ST_ThrowBall()
				)
				);
	}
}
