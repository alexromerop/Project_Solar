using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator3Script : MonoBehaviour
{
    public AudioClip cancion;
    public AudioSource sourceMusica;
    public Generic_Activator Activator;


 void OnTriggerStay (Collider other){
        if (other.tag=="Player" && Activator.power==true){
          StartCoroutine(Reset());
          sourceMusica.volume = 0.5f;
       sourceMusica.PlayOneShot(cancion);
            Sube=true;



            
        }

 }

 IEnumerator Reset() {
     yield return new WaitForSeconds(7f);
     Sube=false;
 }

}
