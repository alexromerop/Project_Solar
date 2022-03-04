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


    public GameObject endCanvas;
     public Generic_Activator Activator;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            StartCoroutine(Cinematica2(5.3f));
        }
        if(other.tag=="Player" && name=="CutsceneTriggerNoche"){
            player.speed=13;
            StartCoroutine(CinematicaNoche(2.85f));
        }
    }

     
      public IEnumerator Cinematica2(float time)
    {
        MainCamera.SetActive(false);
        CameraCinematica2.SetActive(true);
        Timeline2.SetActive(true);
        player.disable=true;
        
        yield return new WaitForSeconds(5.3f);
         CameraCinematica2.SetActive(false);
        MainCamera.SetActive(true);
        Timeline2.SetActive(false);
        player.disable=false;
        Destroy(this.gameObject);
    }
   
        public IEnumerator CinematicaNoche(float time)
    {
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
    }
     public IEnumerator CinematicaFinal(float time)
    {
        MainCamera.SetActive(false);
        CameraCinematica3.SetActive(true);
        Timeline3.SetActive(true);
        player.disable=true;
        yield return new WaitForSeconds(23f);
        endCanvas.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }
     public IEnumerator CinematicaPozo(float time)
    {
        MainCamera.SetActive(false);
        CameraCinematica2.SetActive(true);
        Timeline2.SetActive(true);
        player.disable=true;
        yield return new WaitForSeconds(2f);
         CameraCinematica2.SetActive(false);
        MainCamera.SetActive(true);
        Timeline2.SetActive(false);
        player.disable=false;
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
