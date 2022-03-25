using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
public bool pickedBoxAnim;
public GameObject player;
public GameObject handpoint;
public GameObject BoxPoint;
public GameObject polaroidPlayer;
    public GameObject cam;



    public bool picked;

public GameObject pickedObject = null;
public GameObject pickedBox = null;
public GameObject UiPickUp;

    public bool take1;
    public bool take2;





    private void Start()
    {
        cam = GameObject.Find("Camera");
    }
    void Update()
    {
        if (take2 && take1)
        {
           
            cam.GetComponent<testcam>().canCam = true;
            player.GetComponent<ObstalePush_>().enabled = true;
        }
       
        if (pickedObject!=null || pickedBox!=null){
            if(Input.GetMouseButtonDown(0))
            {
                picked = false;
                if (pickedObject != null)
                {
                    StartCoroutine(TimerF(pickedObject));
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
                    pickedBoxAnim=false;
                }

            }
        }
        
    }


private void OnTriggerStay(Collider other)
{
    if(other.gameObject.CompareTag("Pickable"))
    {

            if (pickedObject == null && !picked){
        UiPickUp.SetActive(true);

      

        if (Input.GetMouseButton(0)){
                    if (other.name == "PolaroidMESH")
                    {
                        polaroidPlayer.SetActive(true);
                        Destroy(other.gameObject);
                        UiPickUp.SetActive(false);
                        take1 = true;
                        if (take2)
                        {
                            cam.GetComponent<testcam>().canCam = true;
                        }
                    }
                    else if (other.name == "Libreta")
                    {
                        Destroy(other.gameObject);
                        UiPickUp.SetActive(false);
                        take2 = true;
                        if (take1)
                        {
                            cam.GetComponent<testcam>().canCam = true;
                        }
                    }
                    else
                    {
                        UiPickUp.SetActive(false);
                        picked = true;

                        if (other.GetComponent<BoxCollider>())
                        {
                            other.GetComponent<BoxCollider>().enabled = false;
                        }
                        if (other.GetComponent<CapsuleCollider>())
                        {
                            other.GetComponent<CapsuleCollider>().enabled = false;
                        }

                        other.GetComponent<Rigidbody>().useGravity = false;

                        other.GetComponent<Rigidbody>().isKinematic = true;

                        other.transform.position = handpoint.transform.position;

                        other.gameObject.transform.SetParent(handpoint.gameObject.transform);

                        pickedObject = other.gameObject;

                        other.transform.rotation = new Quaternion(0, 0, 0, 0);

                    }
        }
    }
    }

  
    
            /* if (other.gameObject.CompareTag("Box")){
                 if (Input.GetMouseButton(0) && pickedBox == null && !picked  ){

                         player.SetCamCoxPos();
                         picked = true;
                         other.GetComponent<Rigidbody>().useGravity = false;
                         other.GetComponent<Rigidbody>().isKinematic = true;

                         other.transform.position = BoxPoint.transform.position;

                         other.gameObject.transform.SetParent(BoxPoint.gameObject.transform);

                         pickedBox = other.gameObject;

                         other.transform.rotation = new Quaternion(0, 0, 0, 0);

                         pickedBoxAnim=true;

                     }

             }
            */
}

     private void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Pickable") && pickedObject==null && !picked){


            UiPickUp.SetActive(false);

        }
    }

    
IEnumerator TimerF(GameObject A)
    {

       yield return new WaitForSeconds(2f);
        if (A.GetComponent<BoxCollider>())
        {
            A.GetComponent<BoxCollider>().enabled = true;
        }
        if (A.GetComponent<CapsuleCollider>())
        {
            A.GetComponent<CapsuleCollider>().enabled = true;
        }
        

    }

    private void FixedUpdate()
    {
        if (pickedBox != null) {

            pickedBox.transform.position = BoxPoint.transform.position;

        }
    }



}