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

        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("PlayerNear");
            this.gameObject.layer = 13;


        }
}

    
}
