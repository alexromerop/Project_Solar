using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Activator : MonoBehaviour
{
    public Animator anim;

    public GameObject particulaRayo;
    public bool electric;

    void OnTriggerStay(Collider other) {
       if (other.tag == "Rayo" || other.tag == "Fuente" || other.tag=="MochilaRayo"){
           electric=true;
           anim.Play("Door_1_AnimationOpen");
           anim.Play("Door_2_AnimationOpen");
       }
    }
     void OnTriggerExit(Collider other) {
       if (other.tag == "Rayo" || other.tag == "Fuente" || other.tag=="MochilaRayo"){
           electric=false;
           
       }
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
       if (electric){
            particulaRayo.SetActive(true);
        }
        else{
            particulaRayo.SetActive(false);
        }
    }
}