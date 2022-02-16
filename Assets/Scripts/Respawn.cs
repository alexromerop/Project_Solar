using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
  public ThirdPersonMovement thirdPersonMovement;
  public GameObject Player;
  public Transform respawnPoint;

  void OnTriggerEnter(Collider other){
      if(other.tag=="Player"){
          StartCoroutine(Teleport(1f));
      }
  }
  public IEnumerator Teleport(float time)
    {
        Debug.Log("TELEPORT");
        thirdPersonMovement.disable = true;
        yield return new WaitForSeconds(.1f);
        Player.transform.position = respawnPoint.transform.position;
        yield return new WaitForSeconds(.1f);
        thirdPersonMovement.disable = false;
        
    }
    void Update(){
        if(thirdPersonMovement)
        if(thirdPersonMovement.vida<0){
            StartCoroutine(Teleport(1f));
        }
    }
}
