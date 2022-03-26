using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Activator : MonoBehaviour
{
    
    
    public bool B_amIActivated;
    public GameObject particulaRayo;
    public GameObject Cable;
    public float waitSeconds;

   public IEnumerator Electrificame(float time)
    {
        yield return new WaitForSeconds(0.001f);
        B_amIActivated=true; 
        yield return new WaitForSeconds(waitSeconds); 
        B_amIActivated=false;
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
                  B_amIActivated=true;
              }
              else{
                 B_amIActivated=false;
              }
             
          }
      }
      if(other.tag=="Pila"){
          B_amIActivated=true;
      }
    }
      void OnTriggerExit(Collider other) {
          if(other.tag=="Metal"){
              B_amIActivated=false;
          }
      if(other.tag=="Pila"){
         B_amIActivated=false;
      }
       
     }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(B_amIActivated){
           particulaRayo.SetActive(true);
           Cable.GetComponent<Renderer>().material.color=Color.cyan;
             Cable.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
       }
       else{
           particulaRayo.SetActive(false);
           Cable.GetComponent<Renderer>().material.color=Color.black;
             Cable.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
       }
    }
}
