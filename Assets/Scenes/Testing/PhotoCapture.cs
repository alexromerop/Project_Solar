using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    
    
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject CameraUI;



    [Header("Photo Taker")]
    [SerializeField] private GameObject CameraFlash;
    [SerializeField] private float flashTime;


    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;

    [Header("Audio")]
    [SerializeField] private AudioSource cameraAudio;

    private Texture2D screenCapture;
    private bool viewingPhoto;

    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!viewingPhoto)
            {
                StartCoroutine(CapturePhoto());

            }
            else
            {
                RemovePhoto();
            }
        }
    }


    IEnumerator CapturePhoto()
    {
        CameraUI.SetActive(false);
        viewingPhoto = true;
        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0,0,Screen.width,Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();

    }

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0, 0, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        photoFrame.SetActive(true);
        StartCoroutine(CameraFlashEffect());
        fadingAnimation.Play("CamFadeOut");
    }


    IEnumerator CameraFlashEffect()
    {
        cameraAudio.Play();
        CameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        CameraFlash.SetActive(false);



    }


    void RemovePhoto() { 
        viewingPhoto = false;
        photoFrame.SetActive(false);
        CameraUI.SetActive(true);
    }
}
