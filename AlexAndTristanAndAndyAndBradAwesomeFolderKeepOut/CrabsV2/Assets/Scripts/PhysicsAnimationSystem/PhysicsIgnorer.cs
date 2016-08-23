using UnityEngine;
using System.Collections;

namespace PhysicsAnimation
{
	public class PhysicsIgnorer : MonoBehaviour {

		public Collider myCollider;

		public Collider[] toIgnore;

		// Use this for initialization
		void Awake () {
            if (myCollider == null)
                myCollider = GetComponent<Collider>();
			foreach(Collider c in toIgnore)
			{
				Physics.IgnoreCollision(myCollider, c);
			}
		}
	}
}