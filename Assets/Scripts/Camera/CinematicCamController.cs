using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCamController : MonoBehaviour
{

        private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.Find("Player");
        if(name=="CameraCinematic"){
        StartCoroutine(DesactivaCinematica1());
    }
    }
   
     public IEnumerator DesactivaCinematica1()
    {
        
        yield return new WaitForSeconds(22);
        gameObject.SetActive(false);
        player.GetComponent<ThirdPersonMovement>().enabled = true;
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
