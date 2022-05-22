using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootDECALS : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public ParticleSystem PLeft;
    public ParticleSystem PRight;
    public ParticleSystem PJump;


 private void Start() {
   
}
public void OnTriggerExit(Collider other) {
    
    if(other.tag == "Sand"){
       PLeft.Stop();
       PRight.Stop();
        Debug.Log("tocando tierra");
        PJump.Stop();
    }
}

    public void OnTriggerEnter(Collider other) {
    
    if(other.tag == "Sand"){
        PLeft.Play();
       PRight.Play();
        Debug.Log("tocando tierra");
        PJump.Play();
       StartCoroutine(Jump());
        
    }
}
    IEnumerator Jump(){
        yield return new WaitForSeconds (0.7f);
        PJump.Stop();
    }

}