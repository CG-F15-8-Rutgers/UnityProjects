using UnityEngine;
using System.Collections;
using TreeSharpPlus;

public class behaviortree : MonoBehaviour {

	public Transform wanderpoint1;
	public Transform wanderpoint2;
	public Transform wanderpoint3;
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


	protected Node ST_ApproachAndWait1(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence( daniel1.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	
	protected Node ST_ApproachAndWait2(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence(daniel2.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	
	protected Node ST_ApproachAndWait3(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence(daniel3.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
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
	protected ST_breakdance(){
		return new Sequence( daniel1.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	protected Node ST_Wander(){
		return
			new SelectorShuffle(
				this.ST_ApproachAndWait1 (this.wanderpoint1),
				this.ST_ApproachAndWait2 (this.wanderpoint2),
				this.ST_ApproachAndWait3 (this.wanderpoint3),
				this.ST_ApproachAndWait1 (this.wanderpoint2),
				this.ST_ApproachAndWait2 (this.wanderpoint1),
				this.ST_ApproachAndWait3 (this.wanderpoint1),
				this.ST_ApproachAndWait1 (this.wanderpoint3),
				this.ST_ApproachAndWait2 (this.wanderpoint3),
				this.ST_ApproachAndWait3 (this.wanderpoint2));
	}


	protected Node BuildTreeRoot(){
		return
			new Sequence (
				this.ST_LookAtAndWave (),
				new LeafWait (2000),
				//this.ST_PickUp(this.sphere, this.ball),
				new DecoratorLoop (
					this.ST_Wander ()//,
				//this.ST_ThrowBall()
				)
			);
	}
}
