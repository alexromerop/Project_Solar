using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsCamera : MonoBehaviour
{

    public float MouseX;
    public float MouseY;

    PlayerController inputactions;
    public CameraHandler handler;

    Vector2 cameraInput;

    private void Awake()
    {
        //handler = CameraHandler.singleton;
    }

    private void Update()
    {
        float delta = Time.fixedDeltaTime;

        if (handler != null)
          
        {
            handler.FollowTarget(delta);
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");
            handler.HandleCameraRotation(delta, MouseX, MouseY);
        }
    }

}
