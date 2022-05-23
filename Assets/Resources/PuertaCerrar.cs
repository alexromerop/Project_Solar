using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCerrar : MonoBehaviour
{
public Animator Puerta;



    
  
   public void OnTriggerExit(Collider other) {
       if(other.tag == "Player"){
        Puerta.SetTrigger("PuertaDown");
       Debug.Log("CERRAR");
       }
   }
}
