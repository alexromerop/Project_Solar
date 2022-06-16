using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class MagnetismLR : MonoBehaviour

{
    public bool pilaEnMano;
    public CogerObjeto mano;
    UnityEvent m_MyEvent;
    private GameObject pila;


    private void Awake()
    {
     mano =FindObjectOfType<CogerObjeto>();
        if (m_MyEvent == null)
            m_MyEvent = new UnityEvent();

        m_MyEvent.AddListener(Ping);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mano.picked == true)
            {
                pilaEnMano = true;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(mano.picked == true)
            {
                pilaEnMano= true;
            }


            if (pilaEnMano)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && mano.taked)
                {
                    pilaEnMano=false;
                   mano.coger_();
                    m_MyEvent.Invoke();

                }
            }

        }

        if (other.CompareTag("Pila"))
        {
            pila = other.transform.parent.gameObject;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        pilaEnMano = false;
        pila =null;

    }



    void Ping()
    {
        pila.transform.position = gameObject.transform.position+ new Vector3(0,1,0);
        pila.transform.position = gameObject.transform.position + new Vector3(0, 1, 0);
        pila.transform.eulerAngles =  new Vector3(-90,0,0);
        
    }



}
