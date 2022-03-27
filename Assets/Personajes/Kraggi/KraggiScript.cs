using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KraggiScript : MonoBehaviour
{
  private Animator anim;

   void Start()
   {
       anim = GetComponent<Animator>();
   }
void OnTriggerEnter(Collider other) {
  
    anim.SetTrigger("PlayerNear");
}

    
}
