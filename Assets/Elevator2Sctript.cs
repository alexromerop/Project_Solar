using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator2Sctript : MonoBehaviour
{
    
     public AudioClip cancion;
    public AudioSource sourceMusica;
    public Generic_Activator Activator;
    public bool Sube;

 void OnTriggerStay (Collider other){
        if (other.tag=="Player" && Activator.power==true && Sube==false){
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
