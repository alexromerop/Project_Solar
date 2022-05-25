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
        yield return new WaitForSeconds(14f);
        Seeu.SetActive(true);
        yield return new WaitForSeconds(16f);
        Application.Quit();

    }
}
