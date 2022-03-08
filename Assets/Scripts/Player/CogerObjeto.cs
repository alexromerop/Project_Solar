using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public ThirdPersonMovement player;
public GameObject handpoint;
public GameObject BoxPoint;


    public bool picked;

private GameObject pickedObject = null;
private GameObject pickedBox = null;


    void Update()
    {
        
        if (pickedObject!=null || pickedBox!=null){
            if(Input.GetMouseButtonDown(1))
            {
                picked = false;
                if (pickedObject != null)
                {
                    pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                    pickedObject.GetComponent<Rigidbody>().useGravity = true;
                    pickedObject.gameObject.transform.SetParent(null);
                    pickedObject = null;
                }

                if (pickedBox != null)
                {
                    pickedBox.GetComponent<Rigidbody>().isKinematic = false;
                    pickedBox.GetComponent<Rigidbody>().useGravity = true;
                    pickedBox.gameObject.transform.SetParent(null);
                    pickedBox = null;
                }

            }
        }
        
    }


private void OnTriggerStay(Collider other)
{
    if(other.gameObject.CompareTag("Pickable"))
    {
        if (Input.GetMouseButton(0) && pickedObject == null && !picked){
            picked = true;

            other.GetComponent<Rigidbody>().useGravity = false;

            other.GetComponent<Rigidbody>().isKinematic = true;

            other.transform.position = handpoint.transform.position;

            other.gameObject.transform.SetParent(handpoint.gameObject.transform);

            pickedObject=other.gameObject;

            other.transform.rotation = new Quaternion(0, 0, 0, 0);

        }
    }

    if (other.gameObject.CompareTag("Box")){
        if (Input.GetMouseButton(0) && pickedObject == null && !picked  ){

                player.SetCamCoxPos();
                Debug.Log("aaa");
                picked = true;
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = BoxPoint.transform.position;

                other.gameObject.transform.SetParent(BoxPoint.gameObject.transform);

                pickedBox = other.gameObject;

                other.transform.rotation = new Quaternion(0, 0, 0, 0);


            }
               
    }
    }






}
