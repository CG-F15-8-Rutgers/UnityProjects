using UnityEngine;
using System;
using System.Collections;
using TreeSharpPlus;

using RootMotion.FinalIK;

public class crowd : MonoBehaviour
{
	public Transform wander1;
	public Transform wander2;
	public Transform wander3;
	public Transform wander4;
	public Transform wander5;
	public Transform wander6;
	public Transform wander7;
	public Transform wander8;
	public Transform wander9;
	public GameObject participant1;
	public GameObject participant2;
	public GameObject participant3;
	public GameObject participant4;
	public GameObject participant5;
	public GameObject participant6;
	public GameObject participant7;
	public GameObject participant8;
	public GameObject participant9;

	public FullBodyBipedEffector root;
	
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
	protected Node ST_ApproachAndWait4(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence(participant4.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	protected Node ST_ApproachAndWait5(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence(participant5.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	protected Node ST_ApproachAndWait6(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence(participant6.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	protected Node ST_ApproachAndWait7(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence(participant7.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	protected Node ST_ApproachAndWait8(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence(participant8.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	protected Node ST_ApproachAndWait9(Transform target)
	{
		Val<Vector3> position = Val.V(() => target.position);
		return new Sequence(participant9.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000));
	}
	
	protected Node BuildTreeRoot()
	{
		return
			new DecoratorLoop (
				new SequenceShuffle (
						this.ST_ApproachAndWait1 (this.wander1),
						this.ST_ApproachAndWait1 (this.wander2),
						this.ST_ApproachAndWait1 (this.wander3),
						this.ST_ApproachAndWait1 (this.wander4),
						this.ST_ApproachAndWait1 (this.wander5),
						this.ST_ApproachAndWait1 (this.wander6),
						this.ST_ApproachAndWait1 (this.wander7),
						this.ST_ApproachAndWait1 (this.wander8),
						this.ST_ApproachAndWait1 (this.wander9),
					this.ST_ApproachAndWait2 (this.wander1),
					this.ST_ApproachAndWait2 (this.wander2),
					this.ST_ApproachAndWait2 (this.wander3),
					this.ST_ApproachAndWait2 (this.wander4),
					this.ST_ApproachAndWait2 (this.wander5),
					this.ST_ApproachAndWait2 (this.wander6),
					this.ST_ApproachAndWait2 (this.wander7),
					this.ST_ApproachAndWait2 (this.wander8),
					this.ST_ApproachAndWait2 (this.wander9),
						this.ST_ApproachAndWait3 (this.wander1),
						this.ST_ApproachAndWait3 (this.wander2),
						this.ST_ApproachAndWait3 (this.wander3),
	                     this.ST_ApproachAndWait3 (this.wander4),
	                     this.ST_ApproachAndWait3 (this.wander5),
	                     this.ST_ApproachAndWait3 (this.wander6),
						this.ST_ApproachAndWait3 (this.wander7),
						this.ST_ApproachAndWait3 (this.wander8),
						this.ST_ApproachAndWait3 (this.wander9)
		)
			
		);
	}
}
