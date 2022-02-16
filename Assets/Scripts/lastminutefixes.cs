using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastminutefixes : MonoBehaviour
{
    public GameObject aEliminar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            Destroy(aEliminar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
