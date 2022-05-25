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
          
       sourceMusica.PlayOneShot(cancion);
            Sube=true;



            
        }

 }


}
