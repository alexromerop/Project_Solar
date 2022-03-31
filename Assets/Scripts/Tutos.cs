using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutos : MonoBehaviour
{


    public GameObject Tuto1;
    public GameObject Tuto2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TutoEnter());
         StartCoroutine(TutoEnd());
    }

     IEnumerator TutoEnter()
    {

        yield return new WaitForSeconds(22f);
        Tuto1.SetActive(true);


    }
    IEnumerator TutoEnd()
    {

        yield return new WaitForSeconds(26f);
        Tuto1.SetActive(false);
        Tuto2.SetActive(true);
        StartCoroutine(JumpEnter());


    }

     IEnumerator JumpEnter()
    {

        yield return new WaitForSeconds(1f);
        
        Tuto2.SetActive(true);
        StartCoroutine(JumpEnd());


    }



      IEnumerator JumpEnd()
    {

        yield return new WaitForSeconds(4f);
        
        Tuto2.SetActive(false);


    }
}
