using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    Quaternion rotation;
    public GameObject ObjectNear;
    private float distance1;
    private float distance2;
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Box")){
            distance1 = Vector3.Distance(this.transform.position, other.transform.position);
            if (ObjectNear != null) {
                distance2 = Vector3.Distance(this.transform.position,ObjectNear.transform.position);
                if (distance1 < distance2)
                {
                    ObjectNear = other.gameObject;
                }

            }


            
           


            if(ObjectNear == null || other.gameObject == ObjectNear)
            {
                ObjectNear = other.gameObject;

                transform.LookAt(other.transform);





            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            ObjectNear = null;
            this.gameObject.transform.localRotation = rotation;
        }
    }
}
