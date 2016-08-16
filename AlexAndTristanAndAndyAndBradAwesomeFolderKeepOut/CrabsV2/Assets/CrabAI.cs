using UnityEngine;
using System.Collections;

public class CrabAI : MonoBehaviour {
    public Transform steer;

    public float randomSpeed = 0.1f;
    public float randomStrength = 3f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        float randomValue = (Mathf.PerlinNoise(0f, Time.timeSinceLevelLoad * randomSpeed) - 0.5f) * randomStrength;
        steer.Rotate(new Vector3(0f, randomValue, 0f));
    }
}
