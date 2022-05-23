using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
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
