using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica_Casa : MonoBehaviour
{

    public AudioSource Play;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(Wave());
    }

    IEnumerator Wave(){
        yield return new WaitForSeconds(1f);
        Play.Play();
    }
   
}
