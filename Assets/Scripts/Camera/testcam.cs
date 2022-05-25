using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcam : MonoBehaviour
{
    private Vector3 pos;
    private bool oncam;
    private bool oncam_;


    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject CameraManager;
    [SerializeField]
    private GameObject CameraUi;



    [SerializeField]
    public float _mouseSensitivity = 3.0f;

    private float _rotationY;
    private float _rotationX;

    [SerializeField]
    private GameObject _target;                                  //camera pivot and follow
    [SerializeField]
    public Transform lookme;                                  //camera pivot and follow

    [SerializeField]
    private float _distanceFromTarget;
    private float  distanceFromTarget = 0.0f;
    private float distanceFromTarget_;



    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime = 0.1f;
    private float smoothTime = 0.0f;
    private float smoothTime_;

    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-40, 40);

    public Transform cameraTransform;                           //transform actual camera
    public float cameraCollisionRadius= 0.4f;


    public LayerMask collisionLayer;

    private bool CamMode = false;
    public bool canCam;


    [Header("Photo Fader Effect")]
    [SerializeField] private Animator ZoomIn;


    
    public float hitDistance;
    public GameObject hitObjet;

    public Vector3 targetPosition;
    private GameObject pauseMenu;


    RaycastHit hit;


    public BoxCollider Cheker;


    private Vector3 nextRotation;
    float mouseX;
    float mouseY;
    Vector3 heading;
    float distance;
    Vector3 direction;
    public Canvas[] canvas;
    GameObject menu;

    private void Awake()
    {
        pauseMenu = GameObject.Find("PauseMenu");
 
        distanceFromTarget_ = _distanceFromTarget;
        smoothTime_ = _smoothTime;
        menu = FindObjectOfType<MainMenu>().transform.GetChild(0).gameObject;

    }

    private void LateUpdate()
    {
        Camera();

    }

    private void Update()
    {




        if (Input.GetKeyDown(KeyCode.F) && canCam == true )
        {
            canCam = false;
            pauseMenu.SetActive(false);
            Debug.Log("adasd");
            StartCoroutine( ChangeCamera());
        }

        if (Input.GetKeyUp(KeyCode.Escape) && oncam && canCam == true)
        {
            canCam = false;

            StartCoroutine(ChangeCamera());
            
        }


        


    }
    void Camera()
    {
        mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * -1;

        _rotationY += mouseX;
        _rotationX += mouseY;

        // Apply clamping for x rotation 
        _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        nextRotation = new Vector3(_rotationX, _rotationY);

        // Apply damping between rotation changes
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;


        heading = this.gameObject.transform.position - _target.transform.position;
        distance = heading.magnitude;
        direction = heading / distance;
        direction.Normalize();
        
       





        if (oncam == false)
        {
            //cameraCollisionRadius = _distanceFromTarget * 0.23f;


           

            



            if (Physics.SphereCast(new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z), cameraCollisionRadius/2, direction, out hit, _distanceFromTarget, collisionLayer, QueryTriggerInteraction.UseGlobal))
            {
                
                    _distanceFromTarget = hit.distance;
                if (_distanceFromTarget < 0)
                {
                    _distanceFromTarget = 0;
                }
                
               

            }
           
        }
            transform.position = _target.transform.position - transform.forward * (_distanceFromTarget);
      
        
    }
   
    #region Polaroid
    IEnumerator ChangeCamera()
    {
        if (player.GetComponent<ThirdPersonMovement>().isGrounded)
        {
            if (!CamMode)
            {
               foreach (Canvas c in canvas)
                {
                    c.gameObject.SetActive(false);
                }
                 
                pauseMenu.SetActive(false);
                Cheker.enabled = true;
                oncam = true;
                ZoomIn.Play("zoomin");
                yield return new WaitForSeconds(1);
                Debug.Log("Cambiar camera");
                _distanceFromTarget = distanceFromTarget;
                player.gameObject.SetActive(false);
                //desactivar todos los objetos con canvas
               
                CameraManager.SetActive(true);
                CameraUi.SetActive(true);

                
                CamMode = true;
                canCam = true;

            }
            else
            {
               canCam = false;
                Cheker.enabled = false;

                ZoomIn.Play("zoomout");
                oncam = false;

                Debug.Log("Volver camera");
                _distanceFromTarget = distanceFromTarget_;
                player.gameObject.SetActive(true);

                CamMode = false;
                CameraManager.SetActive(false);
                CameraUi.SetActive(false);
                
                pauseMenu.SetActive(true);
                //activar todos los objetos con canvas
                yield return new WaitForSeconds(1f);

                foreach (Canvas c in canvas)
                {
                    c.gameObject.SetActive(true);
                }
                CamMode = false;
               canCam = true;


              

            }
        }



    }

    #endregion


}