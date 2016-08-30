using UnityEngine;
using System.Collections;

public class PhysicsAnimationDamager : MonoBehaviour {
    public float damageInverse = 0.85f;
    void OnCollisionEnter(Collision collision)
    {
        //collision.collider.gameObject.transform.root.SendMessage("Hit", 0.9f);

        Transform hitTransform = collision.transform;
        Transform t = hitTransform;
        do
        {
            PhysicsAnimation.MuscleGroupController mgc = t.GetComponent<PhysicsAnimation.MuscleGroupController>();
            if (mgc != null)
            {
                mgc.muscleStrength *= damageInverse;
                mgc.muscleXStrength *= damageInverse;
                break;
            }
            else
            {
                t = t.parent;
            }
        } while (t != null);
    }
}
