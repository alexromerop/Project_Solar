using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCamController : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        if(name=="CameraCinematic"){
        StartCoroutine(DesactivaCinematica1(7.5f));
    }
    }
     public IEnumerator DesactivaCinematica1(float time)
    {
        
        yield return new WaitForSeconds(7.5f);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
