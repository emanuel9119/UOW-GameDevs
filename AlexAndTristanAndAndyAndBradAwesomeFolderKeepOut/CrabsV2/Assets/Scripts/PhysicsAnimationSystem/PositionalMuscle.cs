using UnityEngine;
using System.Collections;

public class PositionalMuscle : MonoBehaviour {

	public Rigidbody myRigidbody;
	public Transform target;

	public float movementSpeed = 0.3f;
	public float maxMovementSpeed = 0.2f;
	public float maxmovementAcceleration = 1f;

    public bool useSpringInstead = false;

	// Use this for initialization
	void Start () {
	    if (useSpringInstead)
        {
            //Rigidbody target = target.
        }
	}
	
	// Update is called once per frame


	void FixedUpdate () {
        if (useSpringInstead) return;

		Vector3 towards = (target.position - myRigidbody.position) * movementSpeed;

		if (towards.magnitude > maxMovementSpeed)
		{
			towards = towards.normalized * maxMovementSpeed;
		}

		myRigidbody.MovePosition(myRigidbody.position + towards);
	}
}
