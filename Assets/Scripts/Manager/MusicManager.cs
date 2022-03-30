using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip cancionAphex;
    public AudioSource sourceMusica;
    public AudioSource sourcePlaya;
    public AudioSource sourceWind;
    public AudioSource sourceForest;
    public AudioClip cancionWind;
    public AudioClip cancionPlaya;
    public AudioClip cancionForest;
    // Start is called before the first frame update
    void Start()
    {
        sourcePlaya.PlayOneShot(cancionPlaya);
    }
    
    void OnTriggerEnter (Collider other){
        if (other.tag=="Player"){
            sourceMusica.PlayOneShot(cancionAphex);
        }

        if(other.tag=="Player" && name=="EndCancion"){
             sourceMusica.Stop();
        }
        if(other.tag=="Player" && name=="WindSoundTrigger"){
            sourceWind.PlayOneShot(cancionWind);
        }
        if(other.tag=="Player" && name=="ForestSoundTrigger"){
            sourceForest.PlayOneShot(cancionForest);
            sourcePlaya.Stop();
        }
        if(other.tag=="Player" && name == "ForestOutTrigger"){
            sourceForest.Stop();
            sourcePlaya.PlayOneShot(cancionPlaya);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
