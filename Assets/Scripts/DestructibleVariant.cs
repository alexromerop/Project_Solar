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
    public GameObject Wind;
    public NivelDIA_Manager Player;
    public AnimatorHoopCtrl HoopAnim;


    public IEnumerator EsperaAlPico(float time)
    {
        yield return new WaitForSeconds(40f * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "ParedRompible";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Player.picoUnlock == true)
        {
            UiPick.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        UiPick.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Player.picoUnlock == true)
        {
            if (other.tag == "Player" && Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Breack());
                
                ZonaContaminada.SetActive(false);
                Movimiento.vida = 100;
                
                UiPick.SetActive(false);
                Pico.GetComponent<MeshRenderer>().enabled = true;
                HoopAnim.StarPick();
            }
        }
    }

    void BreakObject()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    IEnumerator Breack()
    {

        yield return new WaitForSeconds(1f);
        BreakObject();
        
        Pico.GetComponent<MeshRenderer>().enabled = false;
         UiCont.SetActive(false);
         Wind.SetActive(true);
    }
     IEnumerator WindOf()
    {

        yield return new WaitForSeconds(5f);
        
         Wind.SetActive(false);
    }
}