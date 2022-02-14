using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player)
        {
            other.transform.parent = gameObject.transform;
            // other.gameObject.transform.localScale = new Vector3(other.gameObject.transform.localScale.x/gameObject.transform.localScale.x,
            // other.gameObject.transform.localScale.y/gameObject.transform.localScale.y,
            // other.gameObject.transform.localScale.z/gameObject.transform.localScale.z);
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
        Player.transform.parent = null;
        Player.transform.localScale = new Vector3(1, 1, 1);
        
    }
}
