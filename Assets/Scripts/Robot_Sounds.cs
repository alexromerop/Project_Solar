using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Robot_Sounds : MonoBehaviour
{

    [Header("Acciones")]
    public AudioClip[] runClip;
    public AudioClip[] jumpClip;
   

    public void PlayRunSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSource.volume;
        audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);
        audioSource.PlayOneShot(runClip[runClip.Length - 1]);

    }

    //Salto y salto doble
    public void PlayJumpSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSource.volume;
        audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);
        audioSource.PlayOneShot(jumpClip[jumpClip.Length - 1]);

    }

   


}
