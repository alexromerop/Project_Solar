using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    
public GameObject handpoint;

public bool picked;

private GameObject pickedObject = null;

    void Update()
    {
        
        if (pickedObject!=null){
            if(Input.GetMouseButtonDown(1))
            {
                picked = false;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.GetComponent<Rigidbody>().useGravity = true;               
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
            }
        }
        
    }


private void OnTriggerStay(Collider other)
{
    if(other.gameObject.CompareTag("Pickable"))
    {
        if (Input.GetMouseButton(0) && pickedObject == null){
            picked = true;

            other.GetComponent<Rigidbody>().useGravity = false;

            other.GetComponent<Rigidbody>().isKinematic = true;

            other.transform.position = handpoint.transform.position;

            other.gameObject.transform.SetParent(handpoint.gameObject.transform);

            pickedObject=other.gameObject;

            other.transform.rotation = new Quaternion(0, 0, 0, 0);

        }
    }
}






}
