using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomperPared : MonoBehaviour
{
    public GameObject destroyedVersion;

    public MochilaController mochila;

    // Start is called before the first frame update
    void BreakObject(){
        Instantiate(destroyedVersion, transform.position,transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       if(mochila.destroyed==true){
           Destroy(this.gameObject);
       }
    }
}
