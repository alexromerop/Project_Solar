using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Diario_Abrir : MonoBehaviour
{
    public GameObject Diario;
    public GameObject DiarioAnimal;

    public bool Abierto;
    public bool open;
    private GameObject pause;
    public Canvas[] canvas;
    public GameObject[] Paginas;

    private testcam cam;
    public CogerObjeto CogerItem;
    public PhotoCapture imageAnimal;

    private int pag = 0;
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        pause = GameObject.Find("PauseMenu");
        pause = pause.transform.GetChild(0).gameObject;
        cam = FindObjectOfType<testcam>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CogerItem.take2 == true)
        {
            if ((Input.GetKeyDown(KeyCode.I) || (Input.GetKeyDown(KeyCode.Escape) && Abierto)) && !pause.activeSelf)
            {
                if (Abierto == false)
                {
                   
                        if (imageAnimal.bNewImage)
                        {
                            pag = 2;
                        imageAnimal.bNewImage = false;
                        }
                        else
                        {
                            pag = 0;
                        }
                    


                    Debug.Log("a");
                        foreach (Canvas c in canvas)
                        {
                            if (c.gameObject.name != this.gameObject.name)
                            {
                                c.gameObject.SetActive(false);

                            }
                        }
                        //menu.GetComponentInParent<MainMenu>().can = false;
                        cam.enabled = false;
                        Abierto = true;
                        Time.timeScale = 0;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.Confined;
                        Diario.SetActive(true);
                        Paginas[pag].SetActive(true);
                        
                    
                }


                else
                {
                    if (Abierto == true)
                    {
                        //menu.GetComponentInParent<MainMenu>().can = true;
                        foreach (Canvas c in canvas)
                        {
                            if (c.gameObject.name != this.gameObject.name)
                            {
                                c.gameObject.SetActive(true);

                            }
                        }
                        cam.enabled = true;


                        Abierto = false;
                        Time.timeScale = 1;
                        Cursor.visible = false;
                        Diario.SetActive(false);
                        foreach (GameObject i in Paginas)
                        {
                            i.SetActive(false);
                        }
                        Cursor.lockState = CursorLockMode.Locked;
                    }

                }
            }
        }
    }


}
