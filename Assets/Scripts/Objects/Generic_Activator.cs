using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_Activator : MonoBehaviour
{
   public Animator anim;
   public Animator anim2;

    public GameObject particulaRayo;
    public GameObject Cable;
    public bool power;

    public bool hanSalido;

    public float tiempoElectrificado;
    public IEnumerator Electrificame(float time)
    {
        power=true; 
        yield return new WaitForSeconds(tiempoElectrificado);
        power=false;
    }

    void OnTriggerStay(Collider other) {
       if(other.gameObject.TryGetComponent<MochilaController>(out MochilaController mochila)){
           if(mochila!=null){
           if(mochila.electrificado==true){
             StartCoroutine(Electrificame(1f));
            } 
         }
    }
      if(other.gameObject.TryGetComponent<Electrificado>(out Electrificado electrificado)){
          if(electrificado!=null){
              if(electrificado.energia==true){
                  power=true;
              }
              else{
                  power=false;
              }
             
          }
      }
      if(other.tag=="Pila"){
          power=true;
      }
    }
      void OnTriggerExit(Collider other) {
          if(other.tag=="Metal"){
              power=false;
          }
      if(other.tag=="Pila"){
          power=false;
      }
       
     }
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
       
       if (power){
            particulaRayo.SetActive(true);
            Cable.GetComponent<Renderer>().material.color=Color.cyan;
             Cable.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            if(anim!=null){
             anim.SetBool("Power", true);
            }
            if(anim2!=null){
             anim2.SetBool("Power",true );
            }
        }
        else{
            particulaRayo.SetActive(false);
            Cable.GetComponent<Renderer>().material.color=Color.black;
             Cable.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            if(anim!=null){
             anim.SetBool("Power", false);
            }
            if(anim2!=null){
             anim2.SetBool("Power",false );
            }
        }
    }
    
}
