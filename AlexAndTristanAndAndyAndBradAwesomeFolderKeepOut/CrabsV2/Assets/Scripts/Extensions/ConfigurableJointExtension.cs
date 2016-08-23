using UnityEngine;

public class ConfigurableJointExtensions {

	private ConfigurableJoint joint;
	Quaternion resultRotation;
	Quaternion worldToJointSpace;

	public ConfigurableJointExtensions(ConfigurableJoint joint)
	{
		this.joint = joint;

		var right = joint.axis;
		var forward = Vector3.Cross (joint.axis, joint.secondaryAxis).normalized;
		var up = Vector3.Cross (forward, right).normalized;
		worldToJointSpace = Quaternion.LookRotation (forward, up);
		// Transform into world space
		resultRotation = Quaternion.Inverse (worldToJointSpace);
	}


	/// <summary>
	/// Sets a joint's targetRotation to match a given local rotation.
	/// The joint transform's local rotation must be cached on Start and passed into this method.
	/// </summary>
	public void SetTargetRotationLocal (/*this ConfigurableJoint joint, */Quaternion targetRotation, Quaternion startRotation)
	{
		if (joint.configuredInWorldSpace) {
			Debug.LogError ("SetTargetRotationLocal should not be used with joints that are configured in world space. For world space joints, use SetTargetRotation.", joint);
		}
		Quaternion resultRotation2 = resultRotation * Quaternion.Inverse (targetRotation) * startRotation;
		resultRotation2 *= worldToJointSpace;
		// Set target rotation to our newly calculated rotation
		joint.targetRotation = resultRotation2;
		//SetTargetRotationInternal (joint, targetLocalRotation, startLocalRotation, Space.Self);
	}
	/// <summary>
	/// Sets a joint's targetRotation to match a given world rotation.
	/// The joint transform's world rotation must be cached on Start and passed into this method.
	/// </summary>
	public void SetTargetRotation (/*this ConfigurableJoint joint, */Quaternion targetRotation, Quaternion startRotation)
	{
		if (!joint.configuredInWorldSpace) {
			Debug.LogError ("SetTargetRotation must be used with joints that are configured in world space. For local space joints, use SetTargetRotationLocal.", joint);
		}
		Quaternion resultRotation2 = resultRotation * startRotation * Quaternion.Inverse (targetRotation);
		resultRotation2 *= worldToJointSpace;
		// Set target rotation to our newly calculated rotation
		joint.targetRotation = resultRotation2;
		//SetTargetRotationInternal (joint, targetWorldRotation, startWorldRotation, Space.World);
	}
	void SetTargetRotationInternal (ConfigurableJoint joint, Quaternion targetRotation, Quaternion startRotation, Space space)
	{
		// Calculate the rotation expressed by the joint's axis and secondary axis

		// Counter-rotate and apply the new local rotation.
		// Joint space is the inverse of world space, so we need to invert our value
		if (space == Space.World) {
		} else {
		}
		// Transform back into joint space
		resultRotation *= worldToJointSpace;
		// Set target rotation to our newly calculated rotation
		joint.targetRotation = resultRotation;
	}
}