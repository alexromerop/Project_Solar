using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarolaPilaTrig : MonoBehaviour
{
    public bool activaFarola;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if(other.tag=="Pila"){
            activaFarola=true;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.tag=="Pila"){
            activaFarola=false;
        }
    }
}
