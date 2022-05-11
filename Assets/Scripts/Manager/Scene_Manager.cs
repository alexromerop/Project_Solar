using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
            if(name=="EndLevel2"){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        
    }
}
