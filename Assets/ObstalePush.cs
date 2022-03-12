using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstalePush : MonoBehaviour
{
    public AudioClip soundClip;
    public float ObMass = 300;
    public float PushAtMass = 100;
    public float PushingTime = 1;
    public float ForceToPush = 100;
    Rigidbody rb;
    public float vel;
    AudioSource AudioPlayer;
    Vector3 dir;

    Vector3 lastPos;
    float _PushingTime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.CompareTag("Box"))
        {
            rb = hit.gameObject.GetComponent<Rigidbody>();


           
            
            if (Input.GetKey(KeyCode.F))
            {
                //cojer la posion i el vector direccion
                //poner al player en el centro de la cara de la caja


                //hit.gameObject.GetComponent<Rigidbody>().isKinematic = false;



                rb.isKinematic = false;


                dir = hit.point - transform.position;
                // We then get the opposite (-Vector3) and normalize it
                dir = -dir.normalized;

                _PushingTime += Time.deltaTime;
                if (_PushingTime >= PushingTime)
                {
                    _PushingTime = PushingTime;
                }

                rb.mass = Mathf.Lerp(ObMass, PushAtMass, _PushingTime / PushingTime);
                rb.AddForce(dir * ForceToPush, ForceMode.Force);


            }
        }

    }
}

