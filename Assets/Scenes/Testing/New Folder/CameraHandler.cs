using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform targetTransform;
    public Transform cameraTrasform;
    public Transform cameraPivotTransform;
    private Transform myTransform;
    private Vector3 cameraTransformPosition;
    public LayerMask ignoreLayer;
    public Vector3 cameraFollowVelocity = Vector3.zero;


    public static CameraHandler singleton;

    public float lookSpeed = 0.1f;
    public float followSpeed = 0.1f;
    public float pivotSpeed = 0.03f;

    private float defaultPosition;
    private float lookAngle;
    private float pivotAngle;
    public float minimumPivot = -35;
    public float maximumPivot = 35;

    float MouseX;
    float MouseY;


    private void Awake()
    {
        singleton = this;
        myTransform = transform;
        defaultPosition = cameraTrasform.localPosition.z;

    }



    private void Update()
    {
        float delta = Time.fixedDeltaTime;

        
            FollowTarget(delta);
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");
            HandleCameraRotation(delta, MouseX, MouseY);
        
    }



public void FollowTarget (float delta)
    {
        Vector3 targetPosition = Vector3.SmoothDamp(myTransform.position, targetTransform.position, ref cameraFollowVelocity, delta/ followSpeed);
        myTransform.position = targetPosition;

    }

    public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
    {
        lookAngle +=(mouseXInput* lookSpeed)/delta;
        pivotAngle -=(mouseYInput* pivotSpeed)/delta;
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        myTransform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;

        targetRotation = Quaternion.Euler(rotation);
        cameraPivotTransform.localRotation = targetRotation;
    }
}
