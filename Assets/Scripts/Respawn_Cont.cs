using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Cont : MonoBehaviour
{
   
   private void OnTriggerEnter(Collider other) {
       if(other.tag=="Box"){
           Debug.Log("Entrando Caja");
           Destroy(gameObject);
       }
   }
}
