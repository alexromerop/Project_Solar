using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitScript : MonoBehaviour
{
    private Animator anim;
    public Vector3[] Path;
    private Vector3 currentTarget;
    public float speed;
    public int actualPath = 0;
    public float tolerancia = 1;
    private bool Apath;
    public int ajuste =90;

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
    Apath=true;
    Debug.Log("ENTRANDO");
    
    anim.SetTrigger("PlayerNear");
           
            
        }
}
    IEnumerator StartMove(){
        yield return new WaitForSeconds (4.3f);
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
                actualPath=0;
                anim.SetTrigger("Idle");
                Apath=false;
            }

            currentTarget= Path[actualPath];

        }
    }
    
}
