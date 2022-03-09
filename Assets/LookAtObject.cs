using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    Quaternion rotation;
    public GameObject gameObject;
    public float distance1;
    public float distance2;
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
            Debug.Log(distance1);
            if (gameObject != null) {
                distance2 = Vector3.Distance(this.transform.position,gameObject.transform.position);
                Debug.Log(distance2);
                if (distance1 < distance2)
                {
                    gameObject = other.gameObject;
                }

            }


            
           


            if(gameObject == null || other.gameObject == gameObject)
            {
                gameObject = other.gameObject;

                transform.LookAt(other.transform);





            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            gameObject = null;
           // this.gameObject.transform.rotation = rotation;
        }
    }
}
