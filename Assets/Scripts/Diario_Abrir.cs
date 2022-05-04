using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diario_Abrir : MonoBehaviour
{
    public GameObject Diario;
    public bool Abierto;
    public bool open;
    private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = FindObjectOfType<MainMenu>().transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && !menu.activeSelf){
            if(Abierto==false){
                menu.GetComponentInParent<MainMenu>().can = false;
                Abierto=true;
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            Diario.SetActive(true);
            }else{
                if(Abierto==true){
                    menu.GetComponentInParent<MainMenu>().can = true;

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
