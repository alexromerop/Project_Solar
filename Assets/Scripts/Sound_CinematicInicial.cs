using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_CinematicInicial : MonoBehaviour
{

    public AudioClip cancion;
    public AudioSource sourceMusica;
   

    void Start()
    {
       // StartCoroutine(Music());
        //sourceMusica.PlayOneShot(cancion);

    }

    IEnumerator Music(){
        yield return new WaitForSecondsRealtime (0.1f);
        sourceMusica.PlayOneShot(cancion);
    }
}
