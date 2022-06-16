using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitScript2 : MonoBehaviour
{
   
    private Animator anim;
    public Vector3[] Path;
    private Vector3 currentTarget;
    public float speed = 5;
    public int actualPath = 0;
    public float tolerancia = 1;
    private bool Apath;
    public int ajuste =90;
    public bool finished;

   void Start()
   {
       anim = GetComponent<Animator>();
       currentTarget = Path[0];
   }


    void Update() {
        if(Apath){
       StartCoroutine (StartMove());
    }   
       
   }
void OnTriggerEnter(Collider other) {
    
    if(other.tag=="Player"){
        if(!finished){
        Apath=true;
        anim.SetTrigger("PlayerNear");
        }else if(finished){
           
    
       
        anim.SetTrigger("PlayerNear");
        } 
       
       
           
            
        }
}
    IEnumerator StartMove(){
       
       if(finished==false){
        yield return new WaitForSeconds (1.2f);
         if(transform.position != currentTarget){
             anim.SetTrigger("Run");
            Vector3 heading = currentTarget - transform.position;       
            transform.position += (Vector3)(heading / heading.magnitude) * speed * Time.deltaTime;
            transform.LookAt(currentTarget);
            transform.Rotate (0,0,0);
            if(heading.magnitude < tolerancia){
                transform.position = currentTarget;
            }
        }else{


            actualPath++;
            if(actualPath >= Path.Length){

                finished = true;
                
                anim.SetTrigger("Idle");
                Apath=false;
                speed=0;
                 
            }

            currentTarget= Path[actualPath];

        }

       }
    }
    
}
