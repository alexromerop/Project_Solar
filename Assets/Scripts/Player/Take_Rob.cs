using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_Rob : MonoBehaviour
{
    [SerializeField]
    private GameObject Rob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
           
                if (Input.GetMouseButton(0))
                {
                Rob.SetActive(true);  

                //poner la animacion o el cutscrene con el timer bla bla bla

                Destroy(this.gameObject);

                }
            
        }
    }


}
