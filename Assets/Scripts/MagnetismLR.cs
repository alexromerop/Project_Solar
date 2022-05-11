using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetismLR : MonoBehaviour

{
    public float magnetForce = 100;

    List<Rigidbody> caughtRigidbodies = new List<Rigidbody>();

    void FixedUpdate()
    {
        for (int i = 0; i < caughtRigidbodies.Count; i++)
        {
            caughtRigidbodies[i].velocity = (transform.position - (caughtRigidbodies[i].transform.position + caughtRigidbodies[i].centerOfMass)) * magnetForce * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Pila")
        {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody r = other.GetComponent<Rigidbody>();
            
            if(!caughtRigidbodies.Contains(r))
            {
                //Add Rigidbody
                caughtRigidbodies.Add(r);
                  
            }
            
        }
        StartCoroutine(Soltar(other));
        }
    }

   
         public IEnumerator Soltar(Collider other){
              yield return new WaitForSeconds(1f);
             if (other.GetComponent<Rigidbody>())
        {
            Rigidbody r = other.GetComponent<Rigidbody>();

            if (caughtRigidbodies.Contains(r))
            {
                //Remove Rigidbody
                caughtRigidbodies.Remove(r);
            }
        }

         }


}