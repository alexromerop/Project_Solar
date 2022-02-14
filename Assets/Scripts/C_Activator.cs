using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Activator : MonoBehaviour
{
    public bool C_amIActivated;
    public  GameObject particulaRayo;
     public IEnumerator Electrificame(float time)
    {
        yield return new WaitForSeconds(0.001f);
        C_amIActivated=true; 
        yield return new WaitForSeconds(1f); 
        C_amIActivated=false;
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
                  C_amIActivated=true;
              }
              else{
                 C_amIActivated=false;
              }
             
          }
      }
      if(other.tag=="Pila"){
         C_amIActivated=true;
      }
    }
      void OnTriggerExit(Collider other) {
          if(other.tag=="Metal"){
             C_amIActivated=false;
          }
      if(other.tag=="Pila"){
          C_amIActivated=false;
      }
       
     }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if(C_amIActivated){
           particulaRayo.SetActive(true);
       }
       else{
           particulaRayo.SetActive(false);
       }
    }
}
