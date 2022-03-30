using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionInvisible : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

#if Unity_STANDALONE

        if (Application.isPlaying)
        {
           gameObject.GetComponent<Renderer>().enabled = false;

        }
#endif
    }


    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<ObstalePush_>().oncollider_){
            gameObject.GetComponent<BoxCollider>().enabled=true;
           
        }
        else{
            gameObject.GetComponent<BoxCollider>().enabled=false;
        }
    }
}
