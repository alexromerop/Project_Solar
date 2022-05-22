using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCerrar : MonoBehaviour
{
  
   public void OnTriggerExit(Collider other) {
       Debug.Log("CERRAR");
   }
}
