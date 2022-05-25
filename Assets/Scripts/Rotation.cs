using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
 public float rotationSpeed = 0.4f;
    //grados por segundo de rotación

    void Update()
    {
        transform.Rotate(0,  rotationSpeed * Time.deltaTime, 0); 
    }
}
