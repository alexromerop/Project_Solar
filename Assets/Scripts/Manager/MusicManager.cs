using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip cancion;
    public AudioSource sourceMusica;
    /*public AudioSource sourcePlaya;
    public AudioSource sourceWind;
    public AudioSource sourceForest;
    public AudioClip cancionWind;
    public AudioClip cancionPlaya;
    public AudioClip cancionForest;
    */
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible=false;
        //sourcePlaya.PlayOneShot(cancionPlaya);
    }
    
    void OnTriggerEnter (Collider other){
        if (other.tag=="Player" && cancion !=null){
            sourceMusica.PlayOneShot(cancion);
            cancion=null;
            if (gameObject.layer != 13)
            {
                try
                {

                    GetComponent<BoxCollider>().enabled = false;
                }
                catch
                {
                    GetComponent<SphereCollider>().enabled = false;
                }
            }

        }

        if(other.tag=="Player" && name=="EndCancion"){
             sourceMusica.Stop();
        }
       /* if(other.tag=="Player" && name=="WindSoundTrigger"){
            sourceWind.PlayOneShot(cancionWind);
        }
        if(other.tag=="Player" && name=="ForestSoundTrigger"){
            sourceForest.PlayOneShot(cancionForest);
            sourcePlaya.Stop();
        }
        if(other.tag=="Player" && name == "ForestOutTrigger"){
            sourceForest.Stop();
            sourcePlaya.PlayOneShot(cancionPlaya);
        }*/
        

    }

 
}
