using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diario_Abrir : MonoBehaviour
{
    public GameObject Diario;
    public bool Abierto;
    public bool open;
    private GameObject menu;
    public Canvas[] canvas;

    // Start is called before the first frame update
    void Start()
    {
        //menu = FindObjectOfType<MainMenu>().transform.GetChild(0).gameObject;
        canvas = FindObjectsOfType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            if(Abierto==false){
                foreach (Canvas c in canvas)
                {
                    if (c.gameObject.name != this.gameObject.name)
                    {
                        //c.gameObject.SetActive(false);

                    }
                }
                    //menu.GetComponentInParent<MainMenu>().can = false;
                    Abierto = true;
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    Diario.SetActive(true);
                
            }else{
                if(Abierto==true){
                    //menu.GetComponentInParent<MainMenu>().can = true;
                    foreach (Canvas c in canvas)
                    {
                        if (c.gameObject.name != this.gameObject.name)
                        {
                           // c.gameObject.SetActive(true);

                        }
                    }
                    Abierto = false;
                    Time.timeScale = 1;
                    Cursor.visible = false;
                    Diario.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
            
            }
        }
    }   
}    
