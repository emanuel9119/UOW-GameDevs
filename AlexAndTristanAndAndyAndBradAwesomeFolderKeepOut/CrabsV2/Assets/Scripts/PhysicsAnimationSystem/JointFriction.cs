using UnityEngine;
using System.Collections;

namespace PhysicsAnimation
{
	public class JointFriction : MonoBehaviour {
		
		// can be null (defaults to this gameobjects config joint)
		//public ConfigurableJoint configurableJoint;

		// 0.15
		public float linearStiffness;
		//public float 
		
		
		private Rigidbody myRigidbody;
		// parent joint
		private Rigidbody parentRigidbody;
		// Use this for initialization
		void Awake () {
			myRigidbody = gameObject.GetComponent<Rigidbody>();
			parentRigidbody = gameObject.GetComponent<ConfigurableJoint>().connectedBody;
		}
		
		
		
		void FixedUpdate()
		{
			Vector3 angularVelocity = myRigidbody.angularVelocity - parentRigidbody.angularVelocity;
			
			// linear stiffness looks better
			//float dragStiffness = Mathf.Pow(angularVelocity.magnitude, 2f) * linearStiffness * 0.2f;
			float dragStiffness = linearStiffness;
			Vector3 angularDrag = angularVelocity * -dragStiffness;
			
			myRigidbody.AddTorque(angularDrag, ForceMode.VelocityChange);
			parentRigidbody.AddTorque(-angularDrag, ForceMode.VelocityChange);
		}
	}
}