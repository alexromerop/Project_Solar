using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnvironmentChange : MonoBehaviour
{

    [SerializeField]
    AudioMixerSnapshot outdoorSnapshot;
    [SerializeField]
    AudioMixerSnapshot indoorSnapshot;

    public float transitionTime = 0.25f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="EcoTrigger")
        {
            Debug.Log("eco");
            indoorSnapshot.TransitionTo(transitionTime); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "EcoTrigger") 
        {
            Debug.Log("adios eco");
            outdoorSnapshot.TransitionTo(transitionTime); 
        }
    }


}
