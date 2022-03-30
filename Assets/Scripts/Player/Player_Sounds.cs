using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player_Sounds : MonoBehaviour
{
    [Header("Pasos")]
    [SerializeField]
    AudioClip[] footStepGrassClip;
    [SerializeField]
    AudioClip[] footStepConcreteClip;
    [SerializeField]
    AudioClip[] footStepSandClip;
    [SerializeField]
    AudioClip[] footStepWaterClip;
    [SerializeField]
    AudioClip[] footStepWoodClip;
    [SerializeField]
    AudioClip[] footStepMetalicClip;
    [SerializeField]
    AudioClip[] footStepGroundClip;
    
    [Header("Acciones")]
    public AudioClip[] jumpClip;
    public AudioClip[] pushClip;
    public AudioClip[] painClip;
    public AudioClip[] punchClip;

    public string floorMaterial;

    
    
    //Correr y caminar
    public void PlayFootStepSound()
    {

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSource.volume;
        audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);

        AudioClip[] footstepClip = footStepGroundClip;

        switch (floorMaterial)
        {

            case "Grass": //Hierba
                footstepClip = footStepGrassClip;
                break;
            case "Ground": //Tierra
                footstepClip = footStepGroundClip;
                break;
            case "Metal": //Metal
                footstepClip = footStepMetalicClip;
                break;
            case "Madera": //Madera
                footstepClip = footStepWoodClip;
                break;
            case "Concrete": //Cemento
                footstepClip = footStepConcreteClip;
                break;
            case "Sand": //Arena
                footstepClip = footStepSandClip;
                break;
            case "Water": //Agua
                footstepClip = footStepWaterClip;
                break;

            default: break;

        }

        if (footstepClip.Length > 0)
            audioSource.PlayOneShot(footstepClip[footstepClip.Length - 1]);

    }

    //Salto y salto doble
    public void PlayJumpSound() 
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSource.volume;
        audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);
        audioSource.PlayOneShot(jumpClip[jumpClip.Length - 1]);

    }

    //Empujar y estirar
    public void PlayPushSound() 
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSource.volume;
        audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);
        audioSource.PlayOneShot(pushClip[pushClip.Length - 1]);

    }

    //Sufrir daño por los enemigos o algo contaminado
    public void PlayPainSound() 
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSource.volume;
        audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);
        audioSource.PlayOneShot(painClip[painClip.Length - 1]);

    }

    //Golpear con el PICO
    public void PlayPunchSound() 
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSource.volume;
        audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);
        audioSource.PlayOneShot(punchClip[punchClip.Length - 1]);
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        
        switch (collision.collider.tag)
        {

            case "Grass":
                floorMaterial = collision.gameObject.tag;
                break;
            case "Ground":
                floorMaterial = collision.gameObject.tag;
                break;
            case "Metal":
                floorMaterial = collision.gameObject.tag;
                break;
            case "Madera":
                floorMaterial = collision.gameObject.tag;
                break;
            case "Concrete":
                floorMaterial = collision.gameObject.tag;
                break;
            case "Sand":
                floorMaterial = collision.gameObject.tag;
                break;
            case "Water":
                floorMaterial = collision.gameObject.tag;
                break;

            default: break;

        }
    }
   

}
