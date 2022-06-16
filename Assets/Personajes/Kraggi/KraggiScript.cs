using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KraggiScript : MonoBehaviour
{
    private Animator anim;
    public Vector3[] Path;
    private Vector3 currentTarget;
    public float speed;
    public int actualPath = 0;
    public float tolerancia = 1;
    private bool Apath;
    public int ajuste = 90;
    public ParticleSystem Tierra;
    
   void Start()
   {
       anim = GetComponent<Animator>();
       currentTarget = Path[0];
       Tierra.Stop();
   }


    void Update() {
        if(Apath){
       StartCoroutine (StartMove());
    }   
       
   }
void OnTriggerEnter(Collider other) {
    if(other.tag=="Player"){
       
        
        Tierra.Play();
        StartCoroutine(TierraParticula());
        

        
        
    Apath=true;
    anim.SetTrigger("PlayerNear");
            gameObject.layer = 13;  
            
        }
}
    IEnumerator StartMove(){
        yield return new WaitForSeconds (1);
         if(transform.position != currentTarget){
             Tierra.Stop();
            Vector3 heading = currentTarget - transform.position;       
            transform.position += (Vector3)(heading / heading.magnitude) * speed * Time.deltaTime;
            transform.LookAt(currentTarget);
            transform.Rotate (0,90,0);
            if(heading.magnitude < tolerancia){
                transform.position = currentTarget;
            }
        }else{
            actualPath++;
            if(actualPath >= Path.Length){
                actualPath=0;
                anim.SetTrigger("Eating");
                Apath=false;
            }

            currentTarget= Path[actualPath];

        }
    }

     IEnumerator TierraParticula(){
        yield return new WaitForSeconds (3);
       Tierra.gameObject.SetActive(false);
     }

}
