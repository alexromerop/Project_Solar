using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcam : MonoBehaviour
{
    private Vector3 pos;
    private bool oncam;
    private bool oncam_;

    public Renderer[] RendPlayer;
    private Renderer[] player_;

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
    private Transform _target;                                  //camera pivot and follow
    [SerializeField]
    public Transform lookme;                                  //camera pivot and follow

    [SerializeField]
    private float _distanceFromTarget;
    private float  distanceFromTarget = 0.0f;
    private float distanceFromTarget_;



    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime = 0.2f;
    private float smoothTime = 0.0f;
    private float smoothTime_;

    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-40, 40);

    public Transform cameraTransform;                           //transform actual camera
    public float cameraCollisionRadius= 0.25f;


    public LayerMask collisionLayer;

    private bool CamMode = false;
    public bool canCam;


    [Header("Photo Fader Effect")]
    [SerializeField] private Animator ZoomIn;


    public Vector3 dir;
    public float hitDistance;
    public GameObject hitObjet;

    public Vector3 targetPosition;


    RaycastHit hit;

    private void Awake()
    {
        player_ = RendPlayer;
        distanceFromTarget_ = _distanceFromTarget;
        smoothTime_ = _smoothTime;
    }

    void Update()
    {

        Camera();


        if (Input.GetKeyDown(KeyCode.E) && canCam == true )
        {
            StartCoroutine( ChangeCamera());
        }

        if (Input.GetKeyUp(KeyCode.Escape) && oncam == true)
        {
            StartCoroutine(ChangeCamera());
            
        }


        


    }
    void Camera()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * -1;

        _rotationY += mouseX;
        _rotationX += mouseY;

        // Apply clamping for x rotation 
        _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

        // Apply damping between rotation changes
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, 0.1f);
        transform.localEulerAngles = _currentRotation;


        Vector3 heading = this.gameObject.transform.position - _target.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        direction.Normalize();
        dir = direction;
       


        Ray forwardRay = new Ray(_target.position, direction);




        if (oncam == false)
        {

            if (Physics.SphereCast(new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z), 0.39f, direction, out hit, 6, collisionLayer, QueryTriggerInteraction.UseGlobal))
            {

                _distanceFromTarget = hit.distance;

            }
        }
            transform.position = _target.position - transform.forward * (_distanceFromTarget-0.01f);
      
        
    }
    #region Polaroid
    IEnumerator ChangeCamera()
    {
        if (player.GetComponent<ThirdPersonMovement>().isGrounded)
        {
            if (!CamMode)
            {
                oncam = true;
                ZoomIn.Play("zoomin");
                yield return new WaitForSeconds(1);
                Debug.Log("Cambiar camera");
                _distanceFromTarget = distanceFromTarget;
                player.gameObject.SetActive(false);
                CamMode = true;
                CameraManager.SetActive(true);
                CameraUi.SetActive(true);
                
                

            }
            else
            {
                ZoomIn.Play("zoomout");
                oncam = false;

                Debug.Log("Volver camera");
                _distanceFromTarget = distanceFromTarget_;
                player.gameObject.SetActive(true);

                CamMode = false;
                CameraManager.SetActive(false);
                CameraUi.SetActive(false);
                
                

            }
        }



    }

    #endregion


    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position, cameraCollisionRadius);
        Gizmos.DrawWireSphere(transform.position, 0.25f);

    }
}