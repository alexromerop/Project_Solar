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
    
    Scene current_Scene;

   
    public ThirdPersonMovement personaje;
    // Start is called before the first frame update
    void Start()
    {
        mochila.energia = 0;
        StartCoroutine(NoFuncionas(9f));
    }
     private void OnTriggerEnter(Collider other) {
        if(other.name == "Disco_Unlock_Gliding" && tag=="Player"){
            glidingUnlock=true;
            Destroy(other.gameObject);
        }    
         if(other.name == "Disco_Unlock_DoubleJump" && tag=="Player"){
             doubleJumpUnlock=true;
             Destroy(other.gameObject);
         }
        if(other.name == "Pico_Unlock" && tag=="Player"){
            picoUnlock=true;
            Destroy(other.gameObject);
        }
       
       
    }
     public IEnumerator NoFuncionas(float time)
    {
        if (personaje)
        {
            yield return new WaitForSeconds(9f);
        
            personaje.disable = false;
        }
    }
    // Update is called once per frame
    
}
