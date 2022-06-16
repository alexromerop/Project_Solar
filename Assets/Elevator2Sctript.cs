using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator2Sctript : MonoBehaviour
{
    
     public AudioClip cancion;
    public AudioSource sourceMusica;
    public Generic_Activator Activator;
    public bool Sube;
    public bool Yata = true;

 void OnTriggerEnter (Collider other){
        if (other.tag=="Player" && Activator.power==true && !Sube && Yata){
          
            sourceMusica.volume = 0.5f;
            sourceMusica.PlayOneShot(cancion);
            Sube=true;
            Yata=false;
            StartCoroutine(Reset());


            
        }

 }

 IEnumerator Reset() {
       
        yield return new WaitForSeconds(10f);
        Sube=false;
        Yata=true;

 }


}
