using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farola : MonoBehaviour
{
    public bool estoyEncendida;
    public FarolaPilaTrig pilaTrig;
    public Light farolaLight;
    // Start is called before the first frame update
   void OnTriggerStay (Collider other){
       if(estoyEncendida){
       if(other.gameObject.TryGetComponent<MochilaController>(out MochilaController mochila)){
           mochila.reciboLuz=true;
       }
       }
     
   }
   void OnTriggerExit (Collider other){
       if(other.gameObject.TryGetComponent<MochilaController>(out MochilaController mochila)){
           mochila.reciboLuz=false;
       }
      
   }
   void Start(){
       farolaLight.intensity=0;
   }
   void Update(){
       if(pilaTrig.activaFarola==true){
           estoyEncendida=true;
           farolaLight.intensity=35f;

       }
       else{
           estoyEncendida=false;
           farolaLight.intensity=0f;
       }
   }
}
