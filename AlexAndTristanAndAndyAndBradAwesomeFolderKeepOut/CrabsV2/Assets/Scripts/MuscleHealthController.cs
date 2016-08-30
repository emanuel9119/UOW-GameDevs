using UnityEngine;
using System.Collections;

public class MuscleHealthController : MonoBehaviour {

    // fill muscle array automagically from children
    public bool imALazyShit;
    public PhysicsAnimation.MuscleGroupController[] muscleGroups;

    public float damageHeathMultiplier = 1f;

	// Use this for initialization
	void Start () {
	    if (imALazyShit)
        {
            muscleGroups = gameObject.GetComponentsInChildren<PhysicsAnimation.MuscleGroupController>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Hit(float damage)
    {
        Debug.Log("HIT");
        foreach (PhysicsAnimation.MuscleGroupController mgc in muscleGroups)
        {
            mgc.muscleStrength *= damage * damageHeathMultiplier;
            mgc.muscleXStrength *= damage * damageHeathMultiplier;
        }
    }
}
