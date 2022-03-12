using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_scr : MonoBehaviour
{
    public bool Oncolider = false;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        

    }

    private void Start()
    {
        Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //set in aimaticion de empañar
            if (Input.GetKey("f"))
            {
                other.GetComponent<ObstalePush_>().oncollider_ = true;

            }

           
            


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            other.GetComponent<ObstalePush_>().oncollider_ = false;
        }
    }
}
