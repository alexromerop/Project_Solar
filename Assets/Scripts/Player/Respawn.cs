using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public ThirdPersonMovement thirdPersonMovement;
    public GameObject Player;
    public Transform respawnPoint;
    public Animator animator;
  

    void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            StartCoroutine(Teleport(1f));
        }
    }
    public IEnumerator Teleport(float time)
    {
        Debug.Log("TELEPORT");
        thirdPersonMovement.disable = true;
        Fadeout();
        yield return new WaitForSeconds(.1f);
        Player.transform.position = respawnPoint.transform.position;
        yield return new WaitForSeconds(.1f);
        Fadein();
        thirdPersonMovement.disable = false;
        
    }
    void Update(){
        if(thirdPersonMovement)
        if(thirdPersonMovement.vida<0){
            StartCoroutine(Teleport(1f));
        }
    }
    public void Fadeout()
    {
        animator.Play("FadeOUT");
    }
    public void Fadein()
    {
        animator.Play("FadeIN");
    }
}
