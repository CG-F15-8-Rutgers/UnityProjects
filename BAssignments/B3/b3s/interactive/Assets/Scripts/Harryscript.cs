﻿using UnityEngine;
using System;
using System.Collections;
using TreeSharpPlus;

using RootMotion.FinalIK;

public class Harryscript : MonoBehaviour
{

	public GameObject Harry;

	private BehaviorAgent behaviorAgent;
	// Use this for initialization
	void Start ()
	{
		behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
		BehaviorManager.Instance.Register (behaviorAgent);
		behaviorAgent.StartBehavior ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	protected Node ST_Firebreath(){
		return new Sequence (Harry.GetComponent<BehaviorMecanim> ().Node_FaceAnimation ("FireBreath", true));
	}
	/*
	protected Node ST_ApproachAndWait1(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence( participant1.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	
	protected Node ST_ApproachAndWait2(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence(participant2.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	
	protected Node ST_ApproachAndWait3(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence(participant3.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	
	protected Node ST_PickUp(GameObject ball, InteractionObject obj)
	{
		FullBodyBipedEffector hand = FullBodyBipedEffector.RightHand;
		Val<Vector3> position = Val.V(() => ball.transform.position);
		return
			new SelectorShuffle(
				new Sequence(participant1.GetComponent<BehaviorMecanim>().Node_GoToUpToRadius(position, 1f),
			             participant1.GetComponent<BehaviorMecanim>().Node_StartInteraction(hand, obj),
			             new LeafWait(2000)),
				new Sequence(participant2.GetComponent<BehaviorMecanim>().Node_GoToUpToRadius(position, 1f),
			             participant2.GetComponent<BehaviorMecanim>().Node_StartInteraction(hand, obj),
			             new LeafWait(2000)),
				new Sequence(participant3.GetComponent<BehaviorMecanim>().Node_GoToUpToRadius(position, 1f),
			             participant3.GetComponent<BehaviorMecanim>().Node_StartInteraction(hand, obj),
			             new LeafWait(2000)));
	}
	
	protected Node ST_LookAtAndWave()
	{
		Vector3 p1 = participant1.transform.position;
		Vector3 p2 = participant2.transform.position;
		Vector3 p3 = participant3.transform.position;
		return
			new SelectorShuffle(
				new Sequence(participant1.GetComponent<BehaviorMecanim>().ST_TurnToFace(p2),
			             participant2.GetComponent<BehaviorMecanim>().ST_TurnToFace(p1),
			             new LeafWait(1000),
			             participant1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             participant2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             participant1.GetComponent<BehaviorMecanim>().ST_TurnToFace(p3),
			             participant3.GetComponent<BehaviorMecanim>().ST_TurnToFace(p1), 
			             new LeafWait(1000),
			             participant1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             participant3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             participant1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             participant3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             participant2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false)),
				new Sequence(participant2.GetComponent<BehaviorMecanim>().ST_TurnToFace(p1),
			             participant1.GetComponent<BehaviorMecanim>().ST_TurnToFace(p2),
			             new LeafWait(1000),
			             participant2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             participant1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             participant2.GetComponent<BehaviorMecanim>().ST_TurnToFace(p3),
			             participant3.GetComponent<BehaviorMecanim>().ST_TurnToFace(p2),
			             new LeafWait(1000),
			             participant2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             participant3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             participant1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             participant3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             participant2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false)),
				new Sequence(participant3.GetComponent<BehaviorMecanim>().ST_TurnToFace(p1),
			             participant1.GetComponent<BehaviorMecanim>().ST_TurnToFace(p3),
			             new LeafWait(1000),
			             participant3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             participant1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             participant3.GetComponent<BehaviorMecanim>().ST_TurnToFace(p2),
			             participant2.GetComponent<BehaviorMecanim>().ST_TurnToFace(p3),
			             new LeafWait(1000),
			             participant3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             participant2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true),
			             new LeafWait(3000),
			             participant1.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             participant3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false),
			             participant2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", false))
				);
	}
	
	protected Node ST_Wander(){
		return
			new SelectorShuffle(
				this.ST_ApproachAndWait1(this.wander1),
				this.ST_ApproachAndWait1(this.wander2),
				this.ST_ApproachAndWait1(this.wander3),
				this.ST_ApproachAndWait2(this.wander4),
				this.ST_ApproachAndWait2(this.wander5),
				this.ST_ApproachAndWait2(this.wander6),
				this.ST_ApproachAndWait3(this.wander7),
				this.ST_ApproachAndWait3(this.wander8),
				this.ST_ApproachAndWait3(this.wander9));
	}
	*/

	protected Node BuildTreeRoot()
	{
		return
				new DecoratorLoop(
					new SequenceShuffle(
						this.ST_Firebreath()
					)
				//,
				//this.ST_ThrowBall()
				);
	}
}
