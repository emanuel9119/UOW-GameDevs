using UnityEngine;
using System.Collections;

namespace PhysicsAnimation
{
	public class MuscleGroupController : MonoBehaviour {

		public MuscleGroupMember[] muscles;

		public float muscleXStrength = 100f;
		private float previousMuscleXStrength = -1f;

		public float muscleStrength = 100f;
		private float previousMuscleStrength = -1f;
		
		// dampening due to velocity
		public float muscleVelocityDampening = 10;
		private float previousVelocityDampening = -1f;

		public float muscleDrag = 0f;
		private float previousMuscleDrag = -1f;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {

			muscleStrength = Mathf.Clamp(muscleStrength, 0f, float.PositiveInfinity);
			muscleVelocityDampening = Mathf.Clamp(muscleVelocityDampening, 0f, float.PositiveInfinity);


			if (muscleVelocityDampening != previousVelocityDampening ||
			    muscleStrength != previousMuscleStrength || 
			    muscleXStrength != previousMuscleXStrength ||
			    muscleDrag != previousMuscleDrag)
			{
				previousVelocityDampening = muscleVelocityDampening;
				previousMuscleStrength = muscleStrength;
				previousMuscleXStrength = muscleXStrength;
				previousMuscleDrag = muscleDrag;



				foreach (MuscleGroupMember m in muscles)
				{
					m.muscle.muscleXStrength = m.relativeStrength * muscleXStrength;

					m.muscle.muscleStrength = m.relativeStrength * muscleStrength;
					m.muscle.muscleVelocityDampening = m.relativeVelocityDampening * muscleVelocityDampening;

					m.muscle.myRigidbody.drag = m.rigidbodyDrag * muscleDrag;
				}
			}
		}


		[System.Serializable]
		public class MuscleGroupMember
		{
			public Muscle muscle;

			public float relativeStrength = 1f;
			public float relativeVelocityDampening = 1f;

			public float rigidbodyDrag = 0f;
		}
	}
}