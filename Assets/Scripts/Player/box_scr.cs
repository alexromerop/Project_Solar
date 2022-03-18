using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_scr : MonoBehaviour
{
    

    public bool Oncolider = false;
    public bool activado = false;
    private GameObject Player;
    private GameObject animator;

    public GameObject trigger;
    public bool boxAnim;


    bool boxpull;
    // Start is called before the first frame update

    private void Start()
    {
        animator = GameObject.Find("Hoop_GameReady");
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (trigger!=null)
            {
                if (activado)
                {
                    Debug.Log("desactivado");
                    activado = false;
                    Player.GetComponent<CharacterController>().radius = 0.4f;
                    
                }
                else
                {
                    if (Player != null)
                    {
                        if (trigger != null)
                            StartCoroutine(Pullbox(trigger));
                    }
                    Debug.Log("ACTIVADO");
                    activado = true;
                    
                }
                boxAnim = activado;

            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.GetComponent<AnimatorHoopCtrl>().boxScript = this;


            Player= other.gameObject;

            if (activado)
            {
                other.GetComponent<ObstalePush_>().oncollider_ = true;             
            }
            else
            {
                other.GetComponent<ObstalePush_>().oncollider_ = false;
                if (other.GetComponent<ObstalePush_>().box.transform.parent !=null)
                {
                    Debug.Log("parente null");
                    other.GetComponent<ObstalePush_>().box.transform.SetParent(null);
                }
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           other.GetComponent<ObstalePush_>().oncollider_ = false;
            activado = false;
            trigger = null;
            Player.GetComponent<CharacterController>().radius = 0.03f;

        }
    }

    public IEnumerator Pullbox(GameObject box)
    {
        Player.GetComponent<ObstalePush_>().oncollider_ = true;
        Player.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSeconds(0.5f * Time.deltaTime);
        Player.transform.position = trigger.transform.position;
        Player.transform.rotation = trigger.transform.rotation;

        yield return new WaitForSeconds(0.5f * Time.deltaTime);

        Player.GetComponent<CharacterController>().enabled = true;
        boxpull = true;
       



    }

}
