using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annihilation : MonoBehaviour
{
   
    public int lifeTime = 2;
    public void Start()
    {
        
        StartCoroutine(WaitThenDie());
    }
    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(lifeTime);
        
        Destroy(gameObject);
    }

}


