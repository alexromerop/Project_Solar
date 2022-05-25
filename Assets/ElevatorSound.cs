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
          
       sourceMusica.PlayOneShot(cancion);
            Sube=true;



            
        }

 }


}
