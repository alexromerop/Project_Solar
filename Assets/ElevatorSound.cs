using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSound : MonoBehaviour
{
    
     public AudioClip cancion;
    public AudioSource sourceMusica;
    public A_Activator Activator;
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
     yield return new WaitForSeconds(3f);
     Sube=false;
 }



}
