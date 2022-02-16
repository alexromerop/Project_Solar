using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip cancion1;
    public AudioSource source;
    public AudioClip cancion2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnTriggerEnter (Collider other){
        if (other.tag=="Player"){
            source.PlayOneShot(cancion1);
        }
       
        if(other.tag=="Player" && name=="EndCancion"){
             source.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
