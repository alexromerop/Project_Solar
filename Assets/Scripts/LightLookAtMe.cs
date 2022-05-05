using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLookAtMe : MonoBehaviour
{
    
    public Transform Raycast1;
    public Transform Raycast2;
    public Transform RayCastBegin;
    public Transform RayCastEnd;
    public MochilaController mochila;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirRayo;
        RaycastHit hit;

       
        dirRayo=RayCastEnd.transform.position-RayCastBegin.transform.position;
        Debug.DrawRay(RayCastBegin.transform.position, dirRayo,Color.red, mask);
        
        if(Physics.Raycast(RayCastBegin.transform.position,dirRayo, out hit, 7000, mask)){
                

            if (hit.transform.gameObject.tag=="LightReciever"){
                Debug.Log("puta");
                mochila.reciboLuz=true;
            }
            else{
                mochila.reciboLuz=false;
            }
        }
    }
}
