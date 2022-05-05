using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutscenesManager : MonoBehaviour
{
     public GameObject CameraCinematica2;
     public GameObject CameraCinematica3;
     public GameObject Timeline2;
     public GameObject Timeline3;
     public ThirdPersonMovement player;
    public GameObject MainCamera;
    public Transform playerTransform;
    public GameObject mochila;
    public GameObject fakeMochila;
    public GameObject BandasN;


    public GameObject endCanvas;
     public Generic_Activator Activator;
     
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if(other.tag=="Player" && name=="TriggerCinematica2"){
            StartCoroutine(Cinematica2(5.3f));
        }
        if(other.tag=="Player" && name=="CutsceneTriggerNoche"){
            player.speed=13;
            StartCoroutine(CinematicaNoche(2.85f));
        }
        if(other.tag=="Player" && gameObject.name=="TriggerCinematica1"){
            other.transform.position = playerTransform.transform.position;
            other.transform.rotation = playerTransform.transform.rotation;
            StartCoroutine(CinematicaCogerRob(580f*Time.deltaTime));
        }
        if(other.tag=="Player" && gameObject.name=="TriggerCinematicaCarreta"){
            
            
            other.transform.parent = playerTransform;
             other.transform.localPosition = new Vector3(0, 0, 0);
            other.transform.localEulerAngles = new Vector3(0, 0, 0);
            StartCoroutine(CinematicaCarretillaFinal(580f*Time.deltaTime));
        }
    }

     
    public IEnumerator CinematicaCarretillaFinal(float time)
    {
        
        Debug.Log("Animacion Carretilla");
        player.enabled=false;
        player.GetComponent<ThirdPersonMovement>().enabled=false;
        MainCamera.SetActive(false);
        CameraCinematica2.SetActive(true);
        Timeline2.SetActive(true);
        yield return new WaitForSeconds(50*Time.deltaTime);
        player.GetComponent<ThirdPersonMovement>().enabled = true;

    }

    public IEnumerator CinematicaCogerRob(float time)
    {
        player.GetComponent<ThirdPersonMovement>().enabled = false;

        Debug.Log("COGER ROB CINEMATICA");
        player.enabled=false;
        MainCamera.SetActive(false);
        CameraCinematica2.SetActive(true);
        Timeline2.SetActive(true);
        yield return new WaitForSeconds(470f*Time.deltaTime);
        mochila.SetActive(true);
        Destroy(fakeMochila);
        yield return new WaitForSeconds(50*Time.deltaTime);
        CameraCinematica2.SetActive(false);
        MainCamera.SetActive(true);
        Timeline2.SetActive(false); 
        Destroy(this.gameObject);
        player.enabled=true;
        player.GetComponent<ThirdPersonMovement>().enabled = true;



    }
    public IEnumerator Cinematica2(float time)
    {
        player.GetComponent<ThirdPersonMovement>().enabled = false;

        MainCamera.SetActive(false);
        CameraCinematica2.SetActive(true);
        Timeline2.SetActive(true);
        player.disable=true;
        
        yield return new WaitForSeconds(5.3f);
        
         CameraCinematica2.SetActive(false);
        MainCamera.SetActive(true);
        Timeline2.SetActive(false);
        player.disable=false;
        player.GetComponent<ThirdPersonMovement>().enabled=true;

        Destroy(this.gameObject);
    }
   
        public IEnumerator CinematicaNoche(float time)
    {
        player.GetComponent<ThirdPersonMovement>().enabled = false;

        MainCamera.SetActive(false);
        CameraCinematica2.SetActive(true);
        Timeline2.SetActive(true);
        player.disable=true;
        yield return new WaitForSeconds(2.85f);
         CameraCinematica2.SetActive(false);
        MainCamera.SetActive(true);
        Timeline2.SetActive(false);
        player.disable=false;
        Destroy(this.gameObject);
        player.GetComponent<ThirdPersonMovement>().enabled = true;

    }
    public IEnumerator CinematicaFinal(float time)
    {
        player.GetComponent<ThirdPersonMovement>().enabled = false;

        MainCamera.SetActive(false);
        CameraCinematica3.SetActive(true);
        Timeline3.SetActive(true);
        player.disable=true;
        yield return new WaitForSeconds(23f);
        endCanvas.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
        player.GetComponent<ThirdPersonMovement>().enabled = true;

    }
    public IEnumerator CinematicaPozo(float time)
    {
        player.GetComponent<ThirdPersonMovement>().enabled = false;

        MainCamera.SetActive(false);
        CameraCinematica2.SetActive(true);
        Timeline2.SetActive(true);
        player.disable=true;
        yield return new WaitForSeconds(2f);
         CameraCinematica2.SetActive(false);
        MainCamera.SetActive(true);
        Timeline2.SetActive(false);
        player.disable=false;
        player.GetComponent<ThirdPersonMovement>().enabled = true;

        Destroy(this.gameObject);
    }
    void Update(){
         if (Activator)
         {
             if (Activator.power == true)
             {
                 StartCoroutine(CinematicaPozo(2f));
             }
             if (Activator.power == true)
             {
                 //Debug.Log("GOOOOOOOLA");
                 StartCoroutine(CinematicaFinal(2f));
             }
         }
    }
}
