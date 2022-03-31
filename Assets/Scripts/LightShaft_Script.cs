using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShaft_Script : MonoBehaviour
{

    public GameObject lightShaft;

    public bool destroyed;

    bool noEjecutes = false;
    bool unlockPick;
    public NivelDIA_Manager diaManager;

    public GameObject destroyedVersion;
    public GameObject ClickDestroy;

    public MochilaController mochila;
     public IEnumerator EsperaAlPico(float time)
    {
        yield return new WaitForSeconds(40f*Time.deltaTime);
        mochila.destroyed=false;
        destroyed=true;
        
    }

    void BreakObject(){
        
        Destroy(this.gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "ParedRompible";
        mochila.destroyed=false;
        
    }
     void OnTriggerStay(Collider other){
      
      if(noEjecutes==false){

          if(diaManager.picoUnlock==true){
              
              ClickDestroy.SetActive(true);
      if (other.tag == "Player" && Input.GetMouseButtonDown(0)){
          mochila.destroyed=true;
          StartCoroutine(EsperaAlPico(40f*Time.deltaTime));
          noEjecutes=true;
      }
      }
      }
  }

     
    // Update is called once per frame
    void Update()
    {
         if(destroyed==true){
           BreakObject();
           ClickDestroy.SetActive(false);
       }
    }
    
}
