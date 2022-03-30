using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCamController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        if(name=="CameraCinematic"){
        StartCoroutine(DesactivaCinematica1(7.5f*Time.deltaTime));
    }
    }
   
     public IEnumerator DesactivaCinematica1(float time)
    {
        
        yield return new WaitForSeconds(970.5f*Time.deltaTime);
        gameObject.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
