using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annihilation : MonoBehaviour
{
    public GameObject Wind;
    public int lifeTime = 2;
    public void Start()
    {
        Wind = GameObject.Find("WINDCont");
        StartCoroutine(WaitThenDie());
    }
    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Wind.SetActive(false);
        Destroy(gameObject);
    }

}


