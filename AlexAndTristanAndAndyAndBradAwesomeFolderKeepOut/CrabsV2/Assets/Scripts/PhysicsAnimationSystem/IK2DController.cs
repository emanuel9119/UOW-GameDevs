using UnityEngine;
using System.Collections;
/*using IK;

public class IK2DController : MonoBehaviour {

	public Vector3 axis;
	// what is used to derive the IK result from;
	public Transform[] basePose;

	// what the computed IK solution is applied to
	public Transform[] targetPose;

	[System.NonSerialized]
	// in what way do we want to move our target?
	public Vector3 deltaTarget;

	public bool ignoreZeroDelta = false;

	[System.NonSerialized]
	// in what way do we want our target to face
	public Vector3 targetLookDir; // x and y, relative to final bone
	public IK2D.AngleMeasurementMode angleMeasurementMode = IK2D.AngleMeasurementMode.None;

	private IK2D ik;


	// Use this for initialization
	void Start () {
		//Time.timeScale = 0.2f;
		ik = new IK2D(basePose, axis);
	}
	
	// Update is called once per frame
	void Update () {



		if (deltaTarget != Vector3.zero || !ignoreZeroDelta)
		{
			ik.DampenDeltas(deltaTarget.magnitude * 0.1f);
			ik.SolveToDelta(deltaTarget, targetLookDir, 3f, 10, 1f, angleMeasurementMode);
		}
		ik.ApplyPoseToTransforms(targetPose);
	}
}
*/