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
public GameObject Explorar;



    public bool picked;

public GameObject pickedObject = null;
public GameObject pickedBox = null;
public GameObject UiPickUp;
    public GameObject UiPickUpCam;


    public bool take1;
    public bool take2;
    private bool take3;

    public bool taked = false;






    private void Start()
    {
        cam = GameObject.Find("Camera");
        if (take1 == true || take2 == true)
        {

            UiPickUpCam.SetActive(true);
        }
    }
    void Update()
    {
        if (UiPickUp)
        if((take1 == true || take2 == true)&& !take3)
        {
            
            UiPickUpCam.SetActive(true);
               
        }
        if ((take2 && take1 )&& !take3)
        {
           
            cam.GetComponent<testcam>().canCam = true;
            player.GetComponent<ObstalePush_>().enabled = true;
            take3 = true;
        }

        if (pickedObject!=null || pickedBox!=null){
            if(Input.GetMouseButtonDown(0)&& taked)
            {
                picked = false;
                if (pickedObject != null)
                {
                    StartCoroutine(TimerF(pickedObject));
                    pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                    pickedObject.GetComponent<Rigidbody>().useGravity = true;
                    pickedObject.gameObject.transform.SetParent(null);
                    pickedObject = null;
                    taked = false;
                }

                if (pickedBox != null)
                {
                    pickedBox.GetComponent<Rigidbody>().isKinematic = false;
                    pickedBox.GetComponent<Rigidbody>().useGravity = true;
                    pickedBox.gameObject.transform.SetParent(null);
                    pickedBox = null;
                    pickedBoxAnim=false;
                    taked = false;

                }

            }
        }
        
    }


 void OnTriggerEnter(Collider other)
{   if(other.gameObject.CompareTag("Box") && !take2 && !take1)
    {
    Explorar.SetActive(true);
     StartCoroutine(ExploOut());
    }
}

private void OnTriggerStay(Collider other)
{




    if(other.gameObject.CompareTag("Box") && take2 && take1)
    {

            if (pickedObject == null && !picked){
        UiPickUp.SetActive(true);

            }
    }
    if(other.gameObject.CompareTag("Pickable"))
    {
        

            if (pickedObject == null && !picked){
        UiPickUp.SetActive(true);

      

        if (Input.GetMouseButton(0) && taked == false){
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
                        Debug.Log("saludos");
                        UiPickUp.SetActive(false);
                        picked = true;
                        StartCoroutine(TimeTake());
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

           if(other.gameObject.CompareTag("Box") && pickedObject==null && !picked){
              
           

            UiPickUp.SetActive(false);

        }
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
    IEnumerator TimeTake()
    {

        yield return new WaitForSeconds(1f);
        taked = true;


    }
     IEnumerator ExploOut()
    {

        yield return new WaitForSeconds(3f);
         Explorar.SetActive(false);


    }

    private void FixedUpdate()
    {
        if (pickedBox != null) {

            pickedBox.transform.position = BoxPoint.transform.position;

        }
    }



}