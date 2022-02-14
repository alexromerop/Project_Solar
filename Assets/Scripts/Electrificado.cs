using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrificado : MonoBehaviour
{
    public bool energia;
    public GameObject particulaRayo;

   void OnTriggerStay(Collider other){
       if(other.tag=="Pila"){
         energia=true;
      }
       if(other.gameObject.TryGetComponent<MochilaController>(out MochilaController mochila)){
           if(mochila!=null){
           if(mochila.electrificado==true){
             StartCoroutine(Electrificame(1f));
            } 
         }
    } 
      
      // if(other.gameObject.GetComponent<MochilaController>().electrificado==true){
      //    energia=true;
      // }
      // else{
      //    if(energia==false){
      //    energia=false;
      // }
      // else{
      //    energia=false;
      // }
      // }
  }
       
 public IEnumerator ArdeMadera(float time)
    {
       
        particulaRayo.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        
        
    }
  
   
    

    void OnTriggerExit(Collider other){
        if(other.tag=="Pila"){
         energia=false;
      }
      if(other.gameObject.TryGetComponent<Generic_Activator>(out Generic_Activator genericAct)){
         if (genericAct.power==true){
            genericAct.power=false;
         }
      }
    }
 
    
    
     public IEnumerator Electrificame(float time)
    {
        yield return new WaitForSeconds(0.0001f);
        
        energia = true;
        
        
        yield return new WaitForSeconds(2.5f);
        
        
        energia=false;
    }
  
    // Update is called once per frame
    void Update()
    {
      
      if(tag=="Madera" && energia){
         StartCoroutine(ArdeMadera(2f));
      }
       
       if (energia){
          particulaRayo.SetActive(true);
          }
       if (!energia){
          particulaRayo.SetActive(false);       

      
         
          
         
         
          
      
    }
    
  
  
    // Update is called once per frame
  
      
        
     
     }
}
