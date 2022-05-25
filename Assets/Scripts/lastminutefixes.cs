using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastminutefixes : MonoBehaviour
{
    public GameObject aEliminar;
    public Generic_Activator Activator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            Destroy(aEliminar);
        }
    }
    public IEnumerator Wait(float time)
    {
        
        yield return new WaitForSeconds(170*Time.deltaTime);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Activator.power==true){
            StartCoroutine(Wait(1f));
        }
    }
}
