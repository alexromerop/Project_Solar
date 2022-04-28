using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFreeze : MonoBehaviour
{
    public Transform CharacterMesh;
    public ThirdPersonMovement personaje;

    public Camera cam;

    public float ghostPositionY;
    public Transform ghostTransform;
    public Vector3 velocity = Vector3.zero;
    public float speed;

    public bool cam_colliison;

    void OnLeaveGround()
{
    // update Y for behavior 3
    ghostPositionY = CharacterMesh.position.y;


}

   

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update() {
        if (personaje&& !cam_colliison)
        {
            if (personaje.gravity == -1)
            {
                speed = 20;
            }
            else
            {
                speed = 10;
            }
            if (personaje.isGrounded == true)
            {
                OnLeaveGround();
            }
        }
        else
        {
            speed = 0;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (personaje)
        {
            Vector3 characterViewPos = cam.WorldToViewportPoint(CharacterMesh.position + personaje.velocity * Time.deltaTime);

            if (characterViewPos.y > 0.99f || characterViewPos.y < 0.5f)
            {
                ghostPositionY = CharacterMesh.position.y;
            }
            else if (personaje.isGrounded == true)
            {
                ghostPositionY = CharacterMesh.position.y;
            }
            var desiredPosition = new Vector3(CharacterMesh.position.x, ghostPositionY, CharacterMesh.position.z);
            ghostTransform.position = Vector3.SmoothDamp(ghostTransform.position, desiredPosition, ref velocity, speed * Time.deltaTime);

        }
    }
}
