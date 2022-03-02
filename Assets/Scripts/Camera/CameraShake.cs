using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    
    public MochilaController mochila;
    public float amplitudeGain;
    public float frequemcyGain;
    public float shakeDuration;

    public CinemachineFreeLook cmFreeCam;
    public void DoShake()
 {
     StartCoroutine(Shake());
 }
 public IEnumerator Shake()
 {
     Noise(amplitudeGain, frequemcyGain);
     yield return new WaitForSeconds(shakeDuration);
     Noise(0,0);
 }
 void Noise(float amplitude,float frequency)
 {
     cmFreeCam.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
     cmFreeCam.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
     cmFreeCam.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
     cmFreeCam.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;
     cmFreeCam.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;
     cmFreeCam.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;
 }
 void Update (){
     if(Input.GetKeyDown(KeyCode.E) && mochila.energia>0){
         DoShake();
     }
 }
}
