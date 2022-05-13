using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Diario_AnimalSee : MonoBehaviour
{
    public GameObject[] Kraggi;
    public GameObject KraggiImage;

    private void OnEnable()
    {
        Debug.Log("show log2");

        activeAnimal(KraggiImage, Kraggi);
    }


    public void activeAnimal(GameObject image, GameObject[] items)
    {
        if (image != null)
        {

            if (image.gameObject.GetComponent<Image>().enabled == true && items[items.Length - 1].gameObject.GetComponent<Image>().enabled == false)
            {
                foreach (GameObject item in items)
                {
                    item.gameObject.GetComponent<Image>().enabled = true;
                    Debug.Log("show log");

                }
            }
        }
    }
}    

