using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash_Manager : MonoBehaviour
{
    
    void Start(){
        
        StartCoroutine(Estart());
    }

     public IEnumerator Estart()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(1);

    }
}
