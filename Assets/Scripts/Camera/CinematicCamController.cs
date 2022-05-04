using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCamController : MonoBehaviour
{

        private GameObject player;
    private GameObject cam;



    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera");
         player = GameObject.Find("Player");
        if(name=="CameraCinematic"){
        StartCoroutine(DesactivaCinematica1());
    }
    }
   
     public IEnumerator DesactivaCinematica1()
    {
        player.GetComponent<ThirdPersonMovement>().enabled = false;

        cam.GetComponent<AudioListener>().enabled = false;
        yield return new WaitForSeconds(22);
        cam.GetComponent<AudioListener>().enabled = true;

        gameObject.SetActive(false);
        player.GetComponent<ThirdPersonMovement>().enabled = true;
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
