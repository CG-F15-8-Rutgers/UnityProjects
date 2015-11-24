using UnityEngine;
using System;
using System.Collections;
using TreeSharpPlus;

using RootMotion.FinalIK;

public class MyBehaviorTree : MonoBehaviour
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
    public GameObject ball;

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

    /*protected Node ST_PickUp(GameObject obj)
    {
        Val obj
    }*/

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
                participant3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true)),
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
                participant3.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true)),
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
                participant2.GetComponent<BehaviorMecanim>().Node_HandAnimation("WAVE", true))
         );
    }

    protected Node BuildTreeRoot()
	{
		return
            new Sequence(
            //this.ST_PickUp(this.ball),
            //new LeafWait(1000),
            this.ST_LookAtAndWave(),
            new LeafWait(3000),
            new DecoratorLoop(
                new SequenceShuffle(
					this.ST_ApproachAndWait1(this.wander1),
					this.ST_ApproachAndWait1(this.wander2),
					this.ST_ApproachAndWait1(this.wander3),
                    this.ST_ApproachAndWait2(this.wander4),
                    this.ST_ApproachAndWait2(this.wander5),
                    this.ST_ApproachAndWait2(this.wander6),
                    this.ST_ApproachAndWait3(this.wander7),
                    this.ST_ApproachAndWait3(this.wander8),
                    this.ST_ApproachAndWait3(this.wander9))
                    ));
	}
}
