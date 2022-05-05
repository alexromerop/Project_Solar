using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleVariant : MonoBehaviour
{

    public GameObject destroyedVersion;
    public GameObject ZonaContaminada;
    public ThirdPersonMovement Movimiento;
    public GameObject UiCont;
    public GameObject UiPick;
    public GameObject Pico;
    
    public IEnumerator EsperaAlPico(float time)
    {
        yield return new WaitForSeconds(40f * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "ParedRompible";
    }

    private void OnTriggerEnter(Collider other){
        UiPick.SetActive(true);
    }

      private void OnTriggerExit(Collider other){
        UiPick.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Breack());
            ZonaContaminada.SetActive(false);
            Movimiento.vida=100;
            UiCont.SetActive(false);
            UiPick.SetActive(false);
            Pico.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void BreakObject()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

      IEnumerator Breack (){
        
        yield return new WaitForSeconds(1f);
         BreakObject();
         Pico.GetComponent<MeshRenderer>().enabled = false;
        
    }

}