using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelicanoMovement : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public float desiredDuration = 3f;
    public float elapsedTime;
    public bool playerIsNear;
    public float percentatgeComplete;
    public Transform Pelicano;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        A.position=Pelicano.position;
    }

    void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            playerIsNear=true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
        if(playerIsNear==true){
            anim.SetBool("CharacterIsNear", true);
        }
        if(playerIsNear==false){
            anim.SetBool("CharacterIsNear", false);
        }
        if(playerIsNear){
            elapsedTime += Time.deltaTime;
             percentatgeComplete = elapsedTime / desiredDuration;

           Pelicano.position = Vector3.Lerp(A.position, B.position, percentatgeComplete);
        }
        if(percentatgeComplete>1){
            playerIsNear=false;
            Pelicano.transform.eulerAngles=new Vector3(0,-45,0);
        }
    }
}
