using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{

    public GameObject destroyedVersion;
    public GameObject UiPick;
    public AnimatorHoopCtrl HoopAnim;
    public GameObject Pico;
    public NivelDIA_Manager Player;

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
       if(Player.picoUnlock==true){
        UiPick.SetActive(true);
       }
    }

     private void OnTriggerExit(Collider other){
        UiPick.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {   if(Player.picoUnlock==true){
        if (other.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Breack());
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

     IEnumerator Breack (){

        yield return new WaitForSeconds(1f);
         BreakObject();
         Pico.GetComponent<MeshRenderer>().enabled = false;

    }

}