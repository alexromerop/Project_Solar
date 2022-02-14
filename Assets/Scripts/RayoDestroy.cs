using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoDestroy : MonoBehaviour
{
    public Light mylight;
    public bool changeIntensity;
    public float intensitySpeed = 1f;
    public float maxIntensity = 10f;
    float startTime;
    public GameObject antenaPoint;
    // Start is called before the first frame update
    void Start()
    {
        antenaPoint=GameObject.Find("RayoSpawner");
        mylight = GetComponent<Light>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.SetParent(antenaPoint.gameObject.transform);
        if(changeIntensity){
            mylight.intensity = Mathf.PingPong(Time.time * intensitySpeed, maxIntensity);
        }
        if(gameObject.name == "RayoParticle(Clone)"){
         Destroy(gameObject, 30f*Time.deltaTime);
     }
    }
}
