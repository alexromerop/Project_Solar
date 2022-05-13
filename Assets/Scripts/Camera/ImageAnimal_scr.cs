using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;


public class ImageAnimal_scr : MonoBehaviour
{
    [SerializeField]
    private string AnimalName;
    public string[] info;


    //funcion para mostar las imagens del libro, ahora esta con el on enable pero se deberia cambiar a cuando se abre el diario para ocultar la carga con la cinematica 
    private void OnEnable()
    {
        StartCoroutine(ShowAnimal());

    }

    IEnumerator ShowAnimal()
    {
        var appPathD = Application.dataPath + "/RenderOutput";


        Debug.Log(appPathD);
        //Images = Resources.LoadAll<Texture2D>(appPathD);
        info = Directory.GetFiles((appPathD), "*.jpg");


        foreach (string a in info)
        {


            string image = System.IO.Path.GetFileName((a));
            string file = image;
            string[] array = file.Split('_');
            Debug.Log(image);
            try
            {
                string[] array2 = array[1].Split(',');
                string name = array2[0];
                if (name == AnimalName)
                {
                    Texture2D texture = new Texture2D(2, 2);
                    WWW imagePath = new WWW(a);
                    imagePath.LoadImageIntoTexture(texture);
                    this.gameObject.transform.GetChild(0).GetComponent<Image>().enabled = true;
                    this.gameObject.GetComponent<Image>().enabled = true;
                    Debug.Log(name);

                    Sprite mySprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                    this.gameObject.GetComponent<Image>().sprite = mySprite;

                    break;
                }
                else
                {
                    this.gameObject.transform.GetChild(0).GetComponent<Image>().enabled = false;
                    this.gameObject.GetComponent<Image>().enabled = false;

                }
            }
            catch
            {
                break;
            }





        }
        yield return null;
    }
}
