using UnityEngine;
using System.Collections;

public class LocalPoseCopier : MonoBehaviour {

	public Transform poseBone;

	private Transform myTransform;
	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.localRotation = poseBone.localRotation;
	}
}
