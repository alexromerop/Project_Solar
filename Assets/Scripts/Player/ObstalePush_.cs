using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstalePush_ : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;

    public GameObject box;
    public bool oncollider_;
    public bool onhit;




    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Box")&& oncollider_)
        {
            dir = hit.point - transform.position;
            box = hit.gameObject;

            Rigidbody rigidbody = hit.collider.attachedRigidbody;


            if (rigidbody != null)
            {
                
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();
                if (forceDirection.z > 0.75f || forceDirection.z < -0.75f)
                {
                    rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
                    rigidbody.freezeRotation = true;
                    forceDirection.x = 0;
                }
                else { forceDirection.z = 0; }
                if (forceDirection.x > 0.75 || forceDirection.x < -0.75f)
                {
                    rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
                    rigidbody.freezeRotation = true;
                    forceDirection.z = 0;
                }
                else
                {
                    forceDirection.x = 0;
                }

                rigidbody.AddForceAtPosition(forceDirection*forceMagnitude, transform.position, ForceMode.Impulse);
            }
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            box = other.gameObject;
        }
    }
}
