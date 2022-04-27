using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class ImageAnimal_scr : MonoBehaviour
{
    [SerializeField]
    private string AnimalName;
   
    private Texture2D[] Images;
  
    struct photoSlot
    {
        public bool IsFree;
        public string Name;
        public string Date;

    }

 
    //funcion para mostar las imagens del libro, ahora esta con el on enable pero se deberia cambiar a cuando se abre el diario para ocultar la carga con la cinematica 
    private void OnEnable()
    {
        
        Images =Resources.LoadAll<Texture2D>("RenderOutput");
       
        foreach (Texture2D image in Images)
        {
            string file = image.name;
            string[] array = file.Split('_');
            try{
                string[] array2 = array[1].Split(',');
                string name = array2[0];
                if (name == AnimalName)
                {
                    Debug.Log(name);
                    Texture2D t = image;
                    Sprite mySprite = Sprite.Create(t, new Rect(0.0f, 0.0f, t.width, t.height), new Vector2(0.5f, 0.5f), 100.0f);
                    this.gameObject.GetComponent<Image>().sprite = mySprite;
                    return;
                }
            }
            catch
            {
                return;
            }
           

           

        }

    }

 
}
