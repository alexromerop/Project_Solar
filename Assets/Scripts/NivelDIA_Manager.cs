using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelDIA_Manager : MonoBehaviour
{
    public MochilaController mochila;
    public bool glidingUnlock;
    public bool doubleJumpUnlock;
    public bool picoUnlock;
    public GameObject polaroidPlayer;
    public ThirdPersonMovement personaje;
    // Start is called before the first frame update
    void Start()
    {
        personaje.enabled=false;
       if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Nivel_DIA")) 
         {
             StartCoroutine(NoFuncionas(1f));
         }
         else{
             personaje.enabled=true;
         }
        mochila.energia = 0;
    }
     private void OnTriggerEnter(Collider other) {
        if(other.name == "Disco_Unlock_Gliding" && tag=="Player"){
            glidingUnlock=true;
            Destroy(other.gameObject);
            
            personaje.movment=false;
        }    
         if(other.name == "Disco_Unlock_DoubleJump" && tag=="Player"){
             doubleJumpUnlock=true;
             Destroy(other.gameObject);
            personaje.movment = false;

        }
        if (other.name == "Pico_Unlock" && tag=="Player"){
            picoUnlock=true;
            Destroy(other.gameObject);
            personaje.movment = false;

        }



    }


  



     public IEnumerator NoFuncionas(float time)
    {
        yield return new WaitForSeconds(2000f*Time.deltaTime);
        personaje.enabled=true;
    }
    
    
}
