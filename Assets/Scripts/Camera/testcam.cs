using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcam : MonoBehaviour
{
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


    [Header("Photo Fader Effect")]
    [SerializeField] private Animator ZoomIn;


    private void Awake()
    {
        player_ = RendPlayer;
        distanceFromTarget_ = _distanceFromTarget;
        smoothTime_ = _smoothTime;
    }

    void Update()
    {

        Camera();


        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine( ChangeCamera());
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
            _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
            transform.localEulerAngles = _currentRotation;


            Vector3 heading = this.gameObject.transform.position - _target.position;
            float distance = heading.magnitude;
            Vector3 direction = heading / distance;
            direction.Normalize();
            Debug.DrawRay(_target.position, direction, Color.red, 0.5f);

            RaycastHit hit;
            Ray forwardRay = new Ray(_target.position, direction);
            if (Physics.Raycast(_target.position, direction, out hit, _distanceFromTarget, collisionLayer))
            {
                float dis = hit.distance;
                if (dis < 1)
                {

                    //Change color if distrance camenra whit wall is small

                    for (int i = 0; i < RendPlayer.Length; i++)
                    {
                        //player[i].material.color = Color.clear;
                    }
                }
                else
                {

                    for (int i = 0; i < RendPlayer.Length; i++)
                    {
                        //player[i].material.color = player_[i].material.color;
                    }
                }

                transform.position = _target.position - transform.forward * dis;

            }
            else
            {

                transform.position = _target.position - transform.forward * _distanceFromTarget;
            }

    }

    IEnumerator ChangeCamera()
    {
        if (player.GetComponent<ThirdPersonMovement>().isGrounded)
        {
            if (!CamMode)
            {
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
                

                Debug.Log("Volver camera");
                _distanceFromTarget = distanceFromTarget_;
                player.gameObject.SetActive(true);

                CamMode = false;
                CameraManager.SetActive(false);
                CameraUi.SetActive(false);

            }
        }
        


    }
}