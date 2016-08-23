using UnityEngine;
using System.Collections;

public class GlobalConfigTest : MonoBehaviour {

	public Transform target;

	private Quaternion initial;

	public Vector3 offset;
	// Use this for initialization
	void Start () {
		initial = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		//cj.SetTargetRotation(Quaternion.identity, initial);
	}
}
