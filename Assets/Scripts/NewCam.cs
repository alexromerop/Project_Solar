using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCam : MonoBehaviour
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
    private GameObject _target;                                  //camera pivot and follow
    [SerializeField]
    public Transform lookme;                                  //camera pivot and follow

    [SerializeField]
    private float _distanceFromTarget;
    private float distanceFromTarget = 0.0f;
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
    public float cameraCollisionRadius = 0.4f;


    public LayerMask collisionLayer;

    private bool CamMode = false;
    public bool canCam;


    [Header("Photo Fader Effect")]
    [SerializeField] private Animator ZoomIn;


    public Vector3 dir;
    public float hitDistance;
    public GameObject hitObjet;

    public Vector3 targetPosition;
    private GameObject pauseMenu;

     public GameObject tarjet;



    private void Awake()
    {
        player = GameObject.Find("Player");
    }


    private void LateUpdate()
    {

        transform.position = new Vector3(tarjet.transform.position.x, tarjet.transform.position.y, tarjet.transform.position.z);
        transform.LookAt(player.transform.position);
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
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;


        Vector3 heading = this.gameObject.transform.position - tarjet.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        Vector3 dir;
        direction.Normalize();
        dir = direction;
    }
    }
