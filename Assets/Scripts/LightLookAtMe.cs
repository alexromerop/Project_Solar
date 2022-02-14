using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLookAtMe : MonoBehaviour
{
    public Transform target;
    
    public GameObject RayCastBegin;
    public GameObject RayCastEnd;
    public MochilaController mochila;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirRayo;
        RaycastHit hit;

        transform.LookAt(target, Vector3.left);
        dirRayo=RayCastEnd.transform.position-RayCastBegin.transform.position;
        Debug.DrawRay(RayCastBegin.transform.position, dirRayo,Color.red);
        
        if(Physics.Raycast(RayCastBegin.transform.position,dirRayo, out hit)){
            Debug.Log(hit.collider.name);
           
            if(hit.collider.tag=="LightReciever"){
        
                mochila.reciboLuz=true;
            }
            else{
                mochila.reciboLuz=false;
            }
        }
    }
}
