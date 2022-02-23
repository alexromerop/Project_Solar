using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour
{
    public GameObject socket;
    public ThirdPersonMovement personaje;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = socket.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (personaje.isGrounded == true)
        {
            transform.position = socket.transform.position;
        }
        else
        {
            transform.position = new Vector3(personaje.transform.position.x, this.gameObject.transform.position.y, personaje.transform.position.z);
        }
        
    }
}
