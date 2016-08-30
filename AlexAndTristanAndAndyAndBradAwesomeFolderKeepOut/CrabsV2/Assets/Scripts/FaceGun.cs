using UnityEngine;
using System.Collections;

public class FaceGun : MonoBehaviour {
    public GameObject shot;
    public Collider ignoreCollider;
    public Transform forward;
    public float force = 10f;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            GameObject shotInstance = Instantiate<GameObject>(shot);
            shotInstance.transform.position = forward.position;
            if (ignoreCollider != null)
            {
                Physics.IgnoreCollision(shotInstance.GetComponent<Collider>(), ignoreCollider);
            }
            shotInstance.GetComponent<Rigidbody>().velocity = forward.forward * force;

        }
    }
}
