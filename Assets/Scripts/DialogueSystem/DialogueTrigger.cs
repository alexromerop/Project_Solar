using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
    public NivelDIA_Manager DiaManager;
    public DialogueManager dialogueManager;
    public bool estoyEnDialogo;
    public void TriggerDialogue (){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

   

    void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            dialogueManager.dialogueTrigger=GetComponent<DialogueTrigger>();
            GetComponent<Collider>().enabled=false;
            estoyEnDialogo=true;
            TriggerDialogue(); 
            if(gameObject.name=="DialogueTrigger2"){
                DiaManager.doubleJumpUnlock=true;
            }

             if(gameObject.name=="DialogueTrigger5"){
                DiaManager.glidingUnlock=true;
            }
        }
         
    }
    void Update (){
        if(estoyEnDialogo==true){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            dialogueManager.DisplayNextSentence();
        }
        }
    }
}
