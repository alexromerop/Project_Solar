using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Activator : MonoBehaviour
{
    public Animator anim;
    public B_Activator b_Activator;

    public C_Activator c_Activator;

    public bool A_amIActivated;

    public bool power;
    public bool power2;
    public bool electric;
    public GameObject particulaRayo;
    public GameObject Cable;
    public float waitSeconds;

    public IEnumerator Electrificame(float time)
    {
        yield return new WaitForSeconds(0.001f);
        A_amIActivated=true;
         
        yield return new WaitForSeconds(waitSeconds); 
        A_amIActivated=false;
        
    }

    
    void OnTriggerStay(Collider other) {
       if(other.gameObject.TryGetComponent<MochilaController>(out MochilaController mochila)){
           if(mochila!=null){
           if(mochila.electrificado==true){
             StartCoroutine(Electrificame(1f));
            } 
         }
    }
      if(other.gameObject.TryGetComponent<Electrificado>(out Electrificado electrificado)){
          if(electrificado!=null){
              if(electrificado.energia==true){
                  A_amIActivated=true;
              }
              else{
                  A_amIActivated=false;
              }
             
          }
      }
      if(other.tag=="Pila"){
          A_amIActivated=true;
      }
    }
      void OnTriggerExit(Collider other) {
          if(other.tag=="Metal"){
              A_amIActivated=false;
          }
      if(other.tag=="Pila"){
          A_amIActivated=false;
      }
       
     }    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(A_amIActivated){
            particulaRayo.SetActive(true);
             Cable.GetComponent<Renderer>().material.color=Color.cyan;
             Cable.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
        else{
            particulaRayo.SetActive(false);
            Cable.GetComponent<Renderer>().material.color=Color.black;
             Cable.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
        if(A_amIActivated && b_Activator.B_amIActivated){
               power=true;
           }
           if(power==true){
             anim.SetBool("Power", true);
        }
        if(!A_amIActivated || !b_Activator.B_amIActivated){
            power=false;
        }
           if(power==false){
            anim.SetBool("Power", false);
       }
          
        if(A_amIActivated && b_Activator.B_amIActivated && c_Activator.C_amIActivated){
               power2=true;
           }
        else{
            power2=false;
        }
       
        if(power2){
            anim.SetBool("Power2", true);
        }
         if(!power2){
            anim.SetBool("Power2", false);
        }
          
    }
}
