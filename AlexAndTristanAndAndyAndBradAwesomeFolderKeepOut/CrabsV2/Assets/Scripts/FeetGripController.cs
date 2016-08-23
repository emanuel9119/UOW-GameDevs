using UnityEngine;
using System.Collections;

namespace Feet
{

	public class FeetGripController : MonoBehaviour {

		public Collider leftFoot;
		public Collider rightFoot;
		
		public Collider[] feet;
        public Transform[] feetTip;

		public Transform space;

		// movementAxis
		public Vector3 axis;

		private Vector3 lastLeftFootPos;
		private Vector3 lastRightFootPos;
		
		private Vector3[] lastColliderPos;

		public PhysicMaterial gripMaterial;
		public PhysicMaterial slideMaterial;

		public float cutoff = 0.01f;


		// Use this for initialization
		void Start () {
			//lastLeftFootPos = GetLocalPos(leftFoot.transform);
			//lastRightFootPos = GetLocalPos(rightFoot.transform);
			
			lastColliderPos = new Vector3[feet.Length];
            feetTip = new Transform[feet.Length];
            //
            for (int i = 0; i < feet.Length; i++)
			{
                Transform f = null;
                foreach(Transform t in feet[i].transform)
                {
                    f = t;
                    break;
                }
                if (f != null)
                    feetTip[i] = f;


                lastColliderPos[i] = GetLocalPos(feetTip[i].transform);
			}


		}
		
		/*			Vector3 leftPos = GetLocalPos(leftFoot.transform);
			Vector3 deltaLeft = leftPos - lastLeftFootPos;
			lastLeftFootPos = leftPos;
			deltaLeft.Scale(axis);
			float leftMovement = deltaLeft.x + deltaLeft.y + deltaLeft.z;
			leftMovement *= Time.deltaTime;*/
		
		// Update is called once per frame
		void Update () {
			
			for (int i = 0; i < feet.Length; i++)
			{
				Vector3 leftPos = GetLocalPos(feetTip[i].transform);
				Vector3 deltaLeft = leftPos - lastColliderPos[i];
				lastColliderPos[i] = lastLeftFootPos = leftPos;
				deltaLeft.Scale(axis);
				float leftMovement = deltaLeft.x + deltaLeft.y + deltaLeft.z;
				leftMovement *= Time.deltaTime;
				
				if (leftMovement >= -cutoff && feet[i].sharedMaterial == gripMaterial)
					feet[i].sharedMaterial = slideMaterial;
				else if (leftMovement < -cutoff && feet[i].sharedMaterial == slideMaterial)
					feet[i].sharedMaterial = gripMaterial;
			}
			
			// check foot pos, get change in position, swap appropriate material;
			/*Vector3 leftPos = GetLocalPos(leftFoot.transform);
			Vector3 deltaLeft = leftPos - lastLeftFootPos;
			lastLeftFootPos = leftPos;
			deltaLeft.Scale(axis);
			float leftMovement = deltaLeft.x + deltaLeft.y + deltaLeft.z;
			leftMovement *= Time.deltaTime;

			Vector3 rightPos = GetLocalPos(rightFoot.transform);
			Vector3 deltaRight = rightPos - lastRightFootPos;
			lastRightFootPos = rightPos;
			deltaRight.Scale(axis);
			float rightMovement = deltaRight.x + deltaRight.y + deltaRight.z;
			rightMovement *= Time.deltaTime;

			//Debug.Log(leftMovement);
			if (leftMovement >= -cutoff && leftFoot.sharedMaterial == gripMaterial)
				leftFoot.sharedMaterial = slideMaterial;
			else if (leftMovement < -cutoff && leftFoot.sharedMaterial == slideMaterial)
				leftFoot.sharedMaterial = gripMaterial;

			if (rightMovement >= -cutoff && rightFoot.sharedMaterial == gripMaterial)
				rightFoot.sharedMaterial = slideMaterial;
			else if (rightMovement < -cutoff && rightFoot.sharedMaterial == slideMaterial)
				rightFoot.sharedMaterial = gripMaterial;*/
		}

		private Vector3 GetLocalPos(Transform t)
		{
			Vector3 pos = space.worldToLocalMatrix.MultiplyPoint(t.position);
			return pos;
		}
	}
}