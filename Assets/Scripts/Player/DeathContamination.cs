using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathContamination : MonoBehaviour
{
  private ThirdPersonMovement thirdPersonMovement;
  private GameObject Player;
  public Transform respawnPoint;
    private Transform OriginRespawn;
    public Animator anim;


    private void Start()
    {


        Player = GameObject.Find("Player");
        thirdPersonMovement = Player.GetComponent<ThirdPersonMovement>();
        OriginRespawn = GameObject.Find("OriginalChekPoint").transform;
         anim = GameObject.Find("Panel").GetComponent<Animator>();

    }

  
  
  public IEnumerator Teleport(float time)
    {
        Debug.Log("TELEPORT");
        thirdPersonMovement.disable = true;
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(.3f);
        
        Player.transform.position = respawnPoint.position;
        yield return new WaitForSeconds(.3f);
        thirdPersonMovement.disable = false;
        
    }
    void Update(){
        if(thirdPersonMovement)
        if(thirdPersonMovement.vida<0){
            StartCoroutine(TeleportDeath(1f));
        }
    }

   
    public IEnumerator TeleportDeath(float time)
    {
        Debug.Log("TELEPORT");
        thirdPersonMovement.disable = true;
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(.3f);
         
        Player.transform.position = OriginRespawn.position;
        yield return new WaitForSeconds(.3f);
        thirdPersonMovement.disable = false;

    }

}
