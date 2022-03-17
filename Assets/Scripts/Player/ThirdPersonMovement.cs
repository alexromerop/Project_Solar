using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ThirdPersonMovement : MonoBehaviour
{
    bool boxpull = false;
    public Vector3 init_cam;
    public GameObject Hand;

    [SerializeField]
    private float coyoteTime= 0.15f;
    private float coyoteTimeCounter;



    public bool disable;
    public GameObject targetPlat;
    public CharacterController controller;
    public float speed;
    private float speed_;


    public float vida = 100;
    
    public float GiroSmoothTime = 0.1f;
    float GiroSmoothVelocity;
    public Transform cam;

    public float gravity;
    public Vector3 velocity;
    public int glidingGravity;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    public bool isFalling;

    public float antiSaltoSlope = -4.5f;

    public bool isOnSlope = false;

    public float slideVelocity; 
    
    private Vector3 hitNormal;

    public bool gliding;


    public bool canDoubleJump;
    public bool allowDoubleJump;
    public bool allowGliding;

    public bool buf;
    public bool danger;
    
    

    public MochilaController mochilaController;

    public bool isMoving;
    
    public bool isJumping;
    public Vector3 moveDir;

    public GameObject bufBajado;

    public GameObject bufSubido;

    public Transform ghostTransform;
    public GameObject sparkMochila;
    public GameObject planeoParticle;
    float startSpeed = 0;
    float endSpeed = 7;

    float desiredDuration = 5;
    float  elapsedTime;

    IEnumerator SpawnSparkle(float time){
        sparkMochila.SetActive(true);
        yield return new WaitForSeconds (0.5f);
        sparkMochila.SetActive(false);
    }

    public void IncreaseVelocidad(){
        if(!isMoving){
            speed=0;
        }
        else{
            if(speed<7){
            speed += 10*Time.deltaTime;
            }
        }
    }
    public void SlideDown(){
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= controller.slopeLimit;
        if(isOnSlope){
            
            velocity.x += hitNormal.x * slideVelocity;
            velocity.z += hitNormal.z * slideVelocity;
        }
         if(isOnSlope && gravity==-1f){
             velocity.y = -5f;
             velocity.x =0f;
             velocity.z = 0f;
         }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal=hit.normal;
    }

    void isnegative()
    {
        if(velocity.y > 0)
        {
            isFalling = false;
            
        }
    }

    public float AlturaSalto = 4f;

    public NivelDIA_Manager DIA_Manager;

    


    void Start()
    {
         elapsedTime+= Time.deltaTime;
          Cursor.visible = false;
        speed_ = speed;
    }
    void OnTriggerEnter(Collider other){
        if(other.tag==("DangerZone")){
           danger=true;
        }
    }
    public void doubleJump()
    {
        if (Input.GetButtonDown("Jump") && canDoubleJump && gravity < -1)
        {
           
            if (coyoteTimeCounter>0f)
            {
                
                velocity.y = Mathf.Sqrt(AlturaSalto * -2f * gravity);

                coyoteTimeCounter = 0f;
            }
            else 
            {   
                 StartCoroutine(SpawnSparkle(0.5f));
                velocity.y = Mathf.Sqrt(AlturaSalto * -2f * gravity);
                mochilaController.energia -= 1;
                canDoubleJump = false;
                
            }
        }
    }
    public void GLIDING()
        {
          if(DIA_Manager.glidingUnlock==true){
             if(mochilaController.energia>=1){
            
                 if (isFalling && allowGliding)
        {
                     if (Input.GetKey(KeyCode.LeftShift)){
                          planeoParticle.SetActive(true);
                         gravity = glidingGravity;
                     } 
                    else
                    {
                     gravity = -36f;
                     planeoParticle.SetActive(false);
                
                 }
             }
          }
     }
        if (isGrounded)

        {
            gravity = -36f;
            planeoParticle.SetActive(false);
        }
        if (Input.GetButtonDown("Jump") && isGrounded && !isOnSlope)
        {
           
            velocity.y = Mathf.Sqrt(AlturaSalto * -2f * gravity);
            
            
        }
        }
        

       public IEnumerator SubeBuf(float time)
    {
        yield return new WaitForSeconds(15f*Time.deltaTime);
         bufSubido.SetActive(true);
                bufBajado.SetActive(false);
                buf=true;
        
    }
       public IEnumerator BajaBuf(float time)
    {
        yield return new WaitForSeconds(15f*Time.deltaTime);
        bufSubido.SetActive(false);
        bufBajado.SetActive(true);
        buf=false;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
       
        IncreaseVelocidad();

        if(Input.GetKeyDown(KeyCode.V)){
            speed=speed+1;
        }
        if(!disable){
        if(isOnSlope){gravity=-36f;}
        
        if(isOnSlope && canDoubleJump==false){
            AlturaSalto=0f;
            
        }
        else{
            AlturaSalto=2f;
        }

        if (Input.GetKeyDown(KeyCode.Q)){
            if(buf==false){
                StartCoroutine(SubeBuf(1f*Time.deltaTime));
            }
            else{
                StartCoroutine(BajaBuf(1f*Time.deltaTime));
            }
        }

        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        isFalling = isGrounded == false;

            if (isGrounded)
            {
                coyoteTimeCounter = coyoteTime;
            }
            else
            {
                coyoteTimeCounter-=Time.deltaTime;
            }






        isnegative();
        
         //gravedad
         
        if (isGrounded && velocity.y < 0 && !isOnSlope)
        {
            
            velocity.y = -2f + antiSaltoSlope;
            velocity.x = 0f;
            velocity.z=0f;
                

        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical). normalized;
        Vector3 direction2 = new Vector3(0F, 0f, vertical).normalized;


            if (direction.magnitude >= 0.1f)
            {
                if ((Hand.GetComponent<CogerObjeto>().picked == false || Hand.GetComponent<CogerObjeto>().pickedObject != null)&& this.GetComponent<ObstalePush_>().oncollider_ == false)
                {
                    
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref GiroSmoothVelocity, GiroSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                    moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                    isMoving = true;
                }
                 if (this.GetComponent<ObstalePush_>().oncollider_)
                {
                    GameObject box = this.GetComponent<ObstalePush_>().box;
              
                    if (vertical > 0f)
                    {
                        speed_ = speed*0.2f;
                    }
                    else if (vertical < 0f)
                    {
                        speed_ = -speed*0.2f;
                        
                        // speed_ = -speed * 0.5f;
       
                        box.transform.SetParent(transform);
                    }
                   
                    //Debug.Log(speed_);
                    controller.Move(transform.forward.normalized * (speed_) * Time.deltaTime);
                    isMoving = true;


                   
                }

            }
            else
            {
                isMoving = false;
            }

            //  SALTO
            if (isOnSlope==false){
        if (allowDoubleJump==false){
            canDoubleJump=false;
        }

        if (allowDoubleJump)
        {
            if (coyoteTimeCounter>0f)
            {
                canDoubleJump = true;
            }
           
        }

        }
        //GLIDING
        GLIDING();
        //DOBLE SALTO
        if(DIA_Manager.doubleJumpUnlock){       
        doubleJump();
        }
            //GRAVEDAD
        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);
        SlideDown();
    }
    if(gravity==-1){
        gliding=true;
    }
    
    if (Input.GetKeyUp(KeyCode.LeftShift)){
             if(isGrounded==false){
                 if(mochilaController.energia>0){
                 mochilaController.energia -= 1;
               }
            }
        }
   
        
    }

    public IEnumerator CoyoteTime()
    {
        yield return new WaitForSeconds(5f * Time.deltaTime);
        isGrounded=false;

    }

    

    public void SetCamCoxPos() 
    {
        init_cam = cam.transform.eulerAngles;



    }



}
