using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public DialogueTrigger dialogueTrigger;
    private Queue<string> sentences;
    public testcam cam;
    // Start is called before the first frame update

     IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return null;
        }
    }
    void Start()
    {
        
        sentences = new Queue<string>();
        
    }
    

    public void StartDialogue (Dialogue dialogue){
        
        cam.canCam = false;
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();
        
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        } 
        DisplayNextSentence();
    }
    
    public void DisplayNextSentence (){
        
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
   
    void EndDialogue(){
        animator.SetBool("IsOpen", false);
        dialogueTrigger.estoyEnDialogo=false;
        cam.canCam = true;

    }
    void Update(){
       
    }
    
}
