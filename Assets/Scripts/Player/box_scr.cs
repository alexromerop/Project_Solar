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

    public AudioSource audio;
    public AudioClip boxMoveClip;
    private Rigidbody rb;

    bool boxpull;
    // Start is called before the first frame update

    private void Start()
    {
        animator = GameObject.Find("Hoop_GameReady");
        rb= gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;          
        gameObject.isStatic=true;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Player != null) {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Player.GetComponent<ObstalePush_>().enabled)
            {
                if (trigger != null)
                {
                    if (activado)
                    {
                        activado = false;
                        Player.GetComponent<CharacterController>().radius = 0.4f;

                    }
                    else
                    {
                        if (Player != null)
                        {
                            if (trigger != null)
                            {
                                Player.GetComponent<ThirdPersonMovement>().enabled = false;

                                StartCoroutine(Pullbox(trigger));
                            }
                        }

                        activado = true;

                    }

                    //Audio Play de arrastrar la caja
                    Debug.Log("sonido move box");
                    audio.clip = boxMoveClip;
                    audio.Play();
                    //Audio stop de arrastrar la caja
                    if (boxpull == true) {
                        Debug.Log("sin audiobox");
                        boxpull = false;
                        audio.clip = boxMoveClip;
                        audio.Stop();
                    }
                   
                    
                    boxAnim = activado;

                }
                else{
                    boxAnim=false;
                }

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
               
                    gameObject.isStatic = false;
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation;



            }
            else
            {
                other.GetComponent<ObstalePush_>().oncollider_ = false;
                if (other.GetComponent<ObstalePush_>().box.transform.parent !=null)
                {
                    Debug.Log("parente null");
                    other.GetComponent<ObstalePush_>().box.transform.SetParent(null);
                    gameObject.isStatic = true;
                    rb.constraints = RigidbodyConstraints.FreezeAll;

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
            Player.GetComponent<CharacterController>().radius = 0.1f;
            gameObject.isStatic = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;



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
                        Player.GetComponent<ThirdPersonMovement>().enabled = true;




    }

}
