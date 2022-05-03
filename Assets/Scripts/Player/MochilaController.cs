using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochilaController : MonoBehaviour
{
    public int energia = 0;
    
    public LightLookAtMe lightLookAtMe;
    public Material electricityMat;
    public ThirdPersonMovement Movimiento;
    public bool rayo;
    
    public bool reciboLuz;

    public bool electrificado;

    public GameObject particulaRayo;

    public GameObject pico;
    public GameObject UiCont;
    public Transform rayoSpawner;
    
    public bool destroyed;
    
    
    public Material[] energySlot;
    public SkinnedMeshRenderer robotin;
    public Material energyOff;
    public Material energyOn;
    public GameObject sparkMochila;
    public AudioClip rayoClip;
    bool cargando = false;
    int lastCharged = 2;

    IEnumerator SpawnSparkle(float time){
        sparkMochila.SetActive(true);
        yield return new WaitForSeconds (0.5f);
        sparkMochila.SetActive(false);
    }


   void OnTriggerEnter(Collider other){  
     if(other.name== "CambioSegundoRay"){
         lightLookAtMe.RayCastBegin=lightLookAtMe.Raycast2;
     }
      if(other.name== "CambioPrimerRay"){
         lightLookAtMe.RayCastBegin=lightLookAtMe.Raycast1;
     }
         if(other.tag=="RecargaLuz"){
             energia = 5;
         }
         if(other.tag == "ZonaContaminada")
        UiCont.SetActive(true);
        }
   
   
    

  void OnTriggerStay(Collider other){  
     if(other.tag == "ZonaContaminada")
         
          if(Movimiento.buf==false){
          Movimiento.vida -= 6f*Time.deltaTime;
          }else{
              Movimiento.vida-=1.6f*Time.deltaTime;
          }
            
  
      
  }

 
         
    void OnTriggerExit(Collider other) {
        if (other.tag == "ZonaContaminada"){
             Movimiento.vida=100;
             UiCont.SetActive(false);
        }
    }

    
    
    public IEnumerator ElectrificameMochila(float time)
    {
        yield return new WaitForSeconds(0.01f);
        gameObject.tag = "Fuente";
        electrificado = true;
        Instantiate(particulaRayo, rayoSpawner.transform.position, rayoSpawner.transform.rotation);
        
        yield return new WaitForSeconds(.01f);
        
        gameObject.tag = "Mochila";
        electrificado=false;
    }
    
    private void Awake()
    {
        Movimiento = GameObject.Find("Player").GetComponent<ThirdPersonMovement>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
         
        //int index=0;
        pico.SetActive(false);
        //for (int i=2;i<robotin.materials.Length;i++){
            energySlot=robotin.materials;
        //    index++;
        //}

        for(int i=2;i<energySlot.Length;i++){
             energySlot[i]=energyOff;
         }
    }
    void CargaMochila(){
        if(lastCharged<energySlot.Length){
        energySlot[lastCharged]=energyOn;
        lastCharged++;
        energia++;
        }
    }
    
// Update is called once per frame
    void Update()
    {   
        
        for(int i=2;i<energySlot.Length;i++){
            energySlot[i]=energyOff;
        }

        for (int i=0;i<energia;i++){
            energySlot[i+2]=energyOn;
        }

        //for (int i=2;i<robotin.materials.Length;i++){
            robotin.materials=energySlot;
        //}

        if(destroyed==true){
            pico.SetActive(true);
        }
        else{
            pico.SetActive(false);
        }

        if (reciboLuz==true){
            Movimiento.vida=100;
        }
        

        if (Movimiento)
        {
             if (Movimiento.isGrounded && reciboLuz)
             {
                 energia = 5;
             }

            if (energia <= 0)
            {
                Movimiento.allowDoubleJump = false;
            }
            else
            {
                Movimiento.allowDoubleJump = true;
            }

            if (energia <= -1)
            {
                Movimiento.allowGliding = false;
            }
            else
            {
                Movimiento.allowGliding = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && energia > 0)

            {

                GetComponent<Renderer>().material = electricityMat;
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                audio.clip = rayoClip;
                audio.Play();
                StartCoroutine(ElectrificameMochila(1f));
                energia -= 1;
            }
            else
            {
                rayo = false;
            }
        }
    }
}
