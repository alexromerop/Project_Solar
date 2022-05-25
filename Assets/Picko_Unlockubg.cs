using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picko_Unlockubg : MonoBehaviour
{
    public  NivelDIA_Manager Manager;
    public GameObject UiPick;
    public GameObject Dialog;
    
 
    // Start is called before the first frame update
   void Start() {
       Dialog = GameObject.Find("DialogueTrigger (4)");
        
      
  }

     void OnTriggerStay(Collider other){
         
       if(other.tag == "Player"){
          
        UiPick.SetActive(true);
        
        
        if (Input.GetMouseButton(0)){
            StartCoroutine(ExitPick());
           Manager.picoUnlock = true;

            
       }


       }

       
    }

    IEnumerator ExitPick(){
        
        yield return new WaitForSeconds(0.2f);
        UiPick.SetActive(false);
        Dialog.GetComponent<BoxCollider>().enabled = true;
        Destroy(gameObject);
    }
    
    
}
