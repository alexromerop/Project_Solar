using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    private LookAtFreeze Lookat;

    private void Awake()
    {
        Lookat = GameObject.Find("LookAtCamera").GetComponent<LookAtFreeze>();
    }
    // Update is called once per frame
  

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Lookat.cam_colliison = true;
    }


}
