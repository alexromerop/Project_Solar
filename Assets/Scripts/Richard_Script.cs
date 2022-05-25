using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Richard_Script : MonoBehaviour
{
    GameObject panel;

    private void Awake()
    {
        panel = GameObject.Find("Plane");
        panel.SetActive(false);
    }

   

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")         
        {
            if (Input.GetKeyDown("e"))
            {
                panel.SetActive(true);
            }
        }
    }
}
