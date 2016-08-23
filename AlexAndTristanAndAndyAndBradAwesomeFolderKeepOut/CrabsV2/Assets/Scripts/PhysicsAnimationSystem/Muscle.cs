using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PhysicsAnimation
{
	public class Muscle : MonoBehaviour {

		public Rigidbody myRigidbody;
		public ConfigurableJoint myConfigurableJoint;

		// bone to pose target
		public Transform animationBone;



		//public bool useRelativeStrengths

		// seperate strength for axises
		public float muscleXStrength = 100f;
		private float previousMuscleXStrength = -1f;

		// how rotationally strong?
		public float muscleStrength = 100f;
		private float previousMuscleStrength = -1f;

		// dampening due to velocity
		public float muscleVelocityDampening = 10;
		private float previousVelocityDampening = -1f;



		public float muscleTranslationStrength = 0f;
		private float previousMuscleTranslationStrength = -1f;
		
		// dampening due to velocity
		public float muscleTranslationVelocityDampening = 0f;
		private float previousTranslationVelocityDampening = -1f;


		/*public float relativeMuscleStrength = 1f;
		private float previousRelativeMuscleStrength = 1f;

		public float relativeMuscleVelocityDampening = 10;
		private float previousRelativeVelocityDampening = -1f;*/




		public bool includeJointFriction = true;
		public float jointStiffness = 0.15f;
		private JointFriction jointFriction;



		private Quaternion startRotation;
		private Quaternion startRotationGlobal;

		private Quaternion parentStartRotation;
		private Quaternion parentStartRotationGlobal;


		//public bool performSearch = false;


		private ConfigurableJointExtensions cje;
		
		// Use this for initialization
		void Awake () {

		}

		void Start()
		{

			myRigidbody.maxAngularVelocity = float.PositiveInfinity;

			cje = new ConfigurableJointExtensions(myConfigurableJoint);

			startRotation = transform.localRotation;
			startRotationGlobal = transform.rotation;

			//parentStartRotation = myConfigurableJoint.connectedBody.transform.localRotation;
			//parentStartRotationGlobal = myConfigurableJoint.connectedBody.transform.rotation;
			
			if (includeJointFriction)
			{
				jointFriction = gameObject.AddComponent<JointFriction>();
				jointFriction.linearStiffness = jointStiffness;
			}

			/*if (performSearch)
			{
				StartCoroutine(DoSearch());
			}*/
		}

		void Update()
		{

			if (jointFriction != null)
			{
				jointFriction.linearStiffness = jointStiffness;
			}

			// values changed, update
			if (muscleVelocityDampening != previousVelocityDampening ||
			    muscleStrength != previousMuscleStrength || 
			    muscleXStrength != previousMuscleXStrength)
			{
				previousVelocityDampening = muscleVelocityDampening;
				previousMuscleStrength = muscleStrength;
				previousMuscleXStrength = muscleXStrength;




				JointDrive angularXDrive = myConfigurableJoint.angularXDrive;
				JointDrive angularYZDrive = myConfigurableJoint.angularYZDrive;



				angularXDrive.positionSpring = muscleXStrength;
				angularXDrive.positionDamper = muscleVelocityDampening;

				angularYZDrive.positionSpring = muscleStrength;
				angularYZDrive.positionDamper = muscleVelocityDampening;




				myConfigurableJoint.angularXDrive = angularXDrive;
				myConfigurableJoint.angularYZDrive = angularYZDrive;
			}

			if (muscleTranslationVelocityDampening != previousTranslationVelocityDampening ||
			    muscleTranslationStrength != previousMuscleTranslationStrength)
			{
				previousTranslationVelocityDampening = muscleTranslationVelocityDampening;
				previousMuscleTranslationStrength = muscleTranslationStrength;



				JointDrive xDrive = myConfigurableJoint.xDrive;
				JointDrive yDrive = myConfigurableJoint.yDrive;
				JointDrive zDrive = myConfigurableJoint.zDrive;



				xDrive.positionSpring = muscleTranslationStrength;
				xDrive.positionDamper = muscleTranslationVelocityDampening;

				yDrive.positionSpring = muscleTranslationStrength;
				yDrive.positionDamper = muscleTranslationVelocityDampening;

				zDrive.positionSpring = muscleTranslationStrength;
				zDrive.positionDamper = muscleTranslationVelocityDampening;



				myConfigurableJoint.xDrive = xDrive;
				myConfigurableJoint.yDrive = yDrive;
				myConfigurableJoint.zDrive = zDrive;

			}
				
				
		}
		//public Vector3 eulerTest;
		// Update is called once per frame
		void FixedUpdate () {

			//if (performSearch)
			//	return;

			if (animationBone != null)
			{
				if (myConfigurableJoint.configuredInWorldSpace)
				//if (false)
				{
					//Quaternion.Inverse
					//Debug.Log("AA: " + myConfigurableJoint.axis);



					/*var right = myConfigurableJoint.axis;
					var forward = Vector3.Cross (myConfigurableJoint.axis, myConfigurableJoint.secondaryAxis).normalized;
					var up = Vector3.Cross (forward, right).normalized;
					Quaternion worldToJointSpace = Quaternion.LookRotation (forward, up);
					// Transform into world space
					Quaternion resultRotation = Quaternion.Inverse (worldToJointSpace);



					var right2 = myConfigurableJoint.connectedBody.gameObject.GetComponent<ConfigurableJoint>().axis;
					var forward2 = Vector3.Cross (myConfigurableJoint.connectedBody.gameObject.GetComponent<ConfigurableJoint>().axis, myConfigurableJoint.connectedBody.gameObject.GetComponent<ConfigurableJoint>().secondaryAxis).normalized;
					var up2 = Vector3.Cross (forward2, right2).normalized;
					Quaternion worldToJointSpace2 = Quaternion.LookRotation (forward2, up2);
					// Transform into world space
					Quaternion resultRotation2 = Quaternion.Inverse (worldToJointSpace2);


					
					Quaternion other = (transform.rotation);
					Quaternion target = startRotationGlobal;//Quaternion.Inverse(startRotation) * transform.rotation;
					Quaternion animation = resultRotation2 * (myConfigurableJoint.connectedBody.transform.rotation);// * animationBone.rotation;// * (transform.rotation);
*/

					//myConfigurableJoint.SetTargetRotation(myConfigurableJoint.connectedBody.transform.rotation * startRotationGlobal,
					//                                      Quaternion.Inverse(animationBone.rotation) * Quaternion.Inverse(startRotationGlobal));


					//var t = worldToJointSpace * (startRotation) *(transform.rotation);
					//var t = (startRotation) * worldToJointSpace *(transform.rotation);
					//var t =  (startRotation) * (transform.rotation) * worldToJointSpace;

					//var t = worldToJointSpace * (transform.rotation) * (startRotation);

					//Quaternion rotInWorld = worldToJointSpace * (myRigidbody.rotation);
					//myConfigurableJoint.targetRotation = rotInWorld * Quaternion.Euler(eulerTest);

					//Debug.Log("QQ: " + animationBone.rotation);




					// FUCK YOU UNITY
					myRigidbody.WakeUp();
					cje.SetTargetRotation(animationBone.rotation, startRotationGlobal);
				}
				else
				{
					cje.SetTargetRotationLocal(animationBone.localRotation, startRotation);
				}
			}
		}



		IEnumerator DoSearch()
		{


			Time.timeScale = 6f;

			List<int> leftInstructions = new List<int>(){10, 0};
			List<int> rightInstructions = new List<int>(){0,0};

			int[] bestLeftSoFar = null;
			int[] bestRightSoFar = null;
			float bestSoFar = float.PositiveInfinity;

			// long initial cooldown
			Debug.Log("== Initial cooldown");
			float lc = 0f;
			while (lc < 120f)
			{
				lc += Time.deltaTime;
				yield return new WaitForFixedUpdate();
			}
			
			
			while (leftInstructions.Count < 4)
			{
				// evaluate



				
				yield return new WaitForFixedUpdate();

				// cooldown period, let things stabilise a bit before measuring its fit
				Debug.Log("== Cooldown");
				float t = 0f;
				while (t < 3f)
				{
					Quaternion leftInstruction = EvaluateInstruction(leftInstructions);
					Quaternion rightInstruction = EvaluateInstruction(rightInstructions);

					
					//myConfigurableJoint.SetTargetRotation(leftInstruction, rightInstruction);
					
					t += Time.deltaTime;
					yield return new WaitForFixedUpdate();
				}

				Debug.Log("== Measurement");
				// lower the better
				float fitness = 0f;
				while (t < 6f)
				{
					Quaternion leftInstruction = EvaluateInstruction(leftInstructions);
					Quaternion rightInstruction = EvaluateInstruction(rightInstructions);

					//myConfigurableJoint.SetTargetRotation(leftInstruction, rightInstruction);

					fitness += Quaternion.Angle(transform.rotation, animationBone.rotation) * Time.deltaTime;
					t += Time.deltaTime;
					yield return new WaitForFixedUpdate();
				}


				if (fitness < bestSoFar)
				{
					bestLeftSoFar = leftInstructions.ToArray();
					bestRightSoFar = rightInstructions.ToArray();

					bestSoFar = fitness;
				}








				// advance
				AdvanceInstruction(rightInstructions);
				if (rightInstructions.Count >= 3)
				{
					AdvanceInstruction(leftInstructions);
					rightInstructions = new List<int>(){0};
				}

				Debug.Log("Completed iter with best: " + bestSoFar + " progress L:"+leftInstructions.Count+" R:"+rightInstructions.Count);
				foreach(int i in leftInstructions)
				{
					Debug.Log("L:    " + i);
				}
				Debug.Log("==========");
				foreach(int i in rightInstructions)
				{
					Debug.Log("R:    " + i);
				}

				yield return new WaitForFixedUpdate();
			}


			Debug.Log("Search fininshed with best: " + bestSoFar);
			foreach(int i in bestLeftSoFar)
			{
				Debug.Log("L:    " + i);
			}
			Debug.Log("==========");
			foreach(int i in bestRightSoFar)
			{
				Debug.Log("R:    " + i);
			}
		}



		private void AdvanceInstruction(List<int> instructionSet)
		{
			bool resetAndAddNew = false;
			instructionSet[0]++;

			int upTo = 0;
			while (instructionSet[upTo] > 11)
			{
				instructionSet[upTo] = 0;
				if (upTo == instructionSet.Count-1)
				{
					instructionSet.Add(0);
				}
				else
				{
					instructionSet[upTo+1]++;
				}

				upTo++;
			}
		}

		private Quaternion EvaluateInstruction(List<int> instructionSet)
		{
			Quaternion previouos = Quaternion.identity;

			foreach(Quaternion instruction in instructionSet.Select(x => GetInstruction(x)))
			{
				previouos = previouos * instruction;
			}

			return previouos;
		}

		private Quaternion GetInstruction(int instruction)
		{
			switch(instruction)
			{
			//case 0:
			//	return Quaternion.identity;



			case 0:
				return transform.rotation;
			case 1:
				return Quaternion.Inverse(transform.rotation);



			case 2:
				return startRotation;
			case 3:
				return Quaternion.Inverse(startRotation);
			case 4:
				return startRotationGlobal;
			case 5:
				return Quaternion.Inverse(startRotationGlobal);


			case 6:
				return myConfigurableJoint.connectedBody.transform.rotation;
			case 7:
				return Quaternion.Inverse(myConfigurableJoint.connectedBody.transform.rotation);

			case 8:
				return animationBone.rotation;
			case 9:
				return Quaternion.Inverse(animationBone.rotation);
			case 10:
				return animationBone.localRotation;
			case 11:
				return Quaternion.Inverse(animationBone.localRotation);

			default:
				throw new System.Exception("Cant");
				break;
			}

		}
	}
}