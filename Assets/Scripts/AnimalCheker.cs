using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCheker : MonoBehaviour
{
    public GameObject animal;
    public PhotoCapture cam;
    private bool animalOnCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!animalOnCam)
        {
            cam.Animal = null;

        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            cam.Animal = other.gameObject;
            animalOnCam = true;


        }
        else
        {
            animalOnCam = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            animalOnCam = false;

        }
    }
}
