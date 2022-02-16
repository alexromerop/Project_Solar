using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigosPetroleo : MonoBehaviour
{
    public NavMeshAgent enemigo; 

    public Transform player;

    public Transform lagoPetroleo;

    public float lookRadius = 20f;

    public ThirdPersonMovement Hoop;

    public bool electrificado;



     public IEnumerator Electrificame(float time)
    {
        yield return new WaitForSeconds(0.01f);
        gameObject.tag = "Rayo";
        electrificado = true;
        yield return new WaitForSeconds(1f);
        gameObject.tag = "Enemigo";
        electrificado=false;
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

     void OnTriggerStay(Collider other) {
           if (other.tag == "Fuente") {
        StartCoroutine(Electrificame(1f)) ; 
          Destroy(this.gameObject); 
         }
     }
     void OnTriggerEnter(Collider other){
          if(other.tag=="Water"){
             Destroy(this.gameObject);
         }
     }

    
   
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookRadius){
            enemigo.SetDestination(player.position);
        }
        else{
            enemigo.SetDestination(lagoPetroleo.position);
        }
        if (distance<= enemigo.stoppingDistance){
            Hoop.vida -=0.3f;
            
        }
    }
}
    