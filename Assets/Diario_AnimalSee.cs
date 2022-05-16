using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Diario_AnimalSee : MonoBehaviour
{
    public GameObject[] Kraggi;
    public GameObject[] KraggiBlack;
    public GameObject KraggiImage;

    public GameObject[] Pelican;
    public GameObject[] PelicanBlack;
    public GameObject PelicanImage;

    [SerializeField] private GameObject dontsee;

    private void OnEnable()
    {
        activeAnimal(KraggiImage, Kraggi, KraggiBlack);
        activeAnimal(PelicanImage, Pelican, PelicanBlack);

    }


    public void activeAnimal(GameObject image, GameObject[] items, GameObject[] itemsBlack)
    {
        if (image != null)
        {

            if (image.gameObject.GetComponent<Image>().enabled == true && items[0].gameObject.GetComponent<Image>().enabled == false)
            {

                dontsee.SetActive(false);
                foreach (GameObject item in items)
                {

                
                
                    if (item.gameObject.TryGetComponent(out Image a ))
                    {
                        a.enabled = true;
                    }
                    else 
                    {
                        item.gameObject.SetActive(true);
                    }
                    

                }
                foreach (GameObject item in itemsBlack)
                {
                    item.gameObject.SetActive(false);


            }
            }
        }
    }
}    

