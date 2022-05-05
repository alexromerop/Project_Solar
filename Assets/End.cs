using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{

    public GameObject Seeu;

    
      void Start(){
        
        StartCoroutine(Endo());
    }

     public IEnumerator Endo()
    {
        yield return new WaitForSeconds(15f);
        Seeu.SetActive(true);
        yield return new WaitForSeconds(19f);
        Application.Quit();

    }
}
