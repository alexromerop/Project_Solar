using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierrraExcabar : MonoBehaviour
{
      public ParticleSystem Tierra;
    
     
    void Start()
    {
        Tierra.Stop();
    }

   void OnTriggerEnter(Collider other) {
       if(other.tag == "Bunny"){
           Tierra.Play();
           StartCoroutine(Cavar());
       }
   }



   IEnumerator Cavar(){
       yield return new WaitForSeconds (3f);
       Tierra.Stop();
   }
}
