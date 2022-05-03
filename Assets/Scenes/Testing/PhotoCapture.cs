using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    private  string iterator;
    
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

    [SerializeField] private GameObject cam;
    [SerializeField] private Text date;
    [SerializeField] private Text name;



    private Texture2D screenCapture;
    private bool viewingPhoto;


    [SerializeField] public GameObject Animal;

    public Canvas[] canvas;


    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        canvas =FindObjectsOfType<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (!viewingPhoto)
            {
                StartCoroutine(CapturePhoto());
               
            }
            
        }
    }


    IEnumerator CapturePhoto()
    {

        for (int i = 0; i < canvas.Length; i++)
        {
            if (canvas[i] == !CameraUI)
            {
                canvas[i].gameObject.SetActive(false);
            }
        }

        cam.GetComponent<testcam>().canCam=false;
        CameraUI.SetActive(false);
        viewingPhoto = true;

        cam.GetComponent<testcam>()._mouseSensitivity = 0;

        yield return new WaitForEndOfFrame();



        //screenCapture = ScreenCapture.CaptureScreenshotAsTexture();

        Rect regionToRead = new Rect(0,0,Screen.width,Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();






        StartCoroutine( capture());
        //SaveTexture(screenCapture);
        //StartCoroutine(SaveImg(screenCapture));
        ShowPhoto();
        yield return new WaitForSeconds(2);
        RemovePhoto();
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




    //Funcion temporal para quitar la imagen de golpe
    //en un futuro hacer que se minimize mientras se mueve a la izquierda
    void RemovePhoto() {



        viewingPhoto = false;
        photoFrame.SetActive(false);
        CameraUI.SetActive(true);
        cam.GetComponent<testcam>().canCam = true;

        for (int i = 0; i < canvas.Length; i++)
        {
            if (canvas[i].gameObject.name == "UI-Canvas")
            {
                Debug.Log("wtf");
            }
                canvas[i].gameObject.SetActive(true);
            
        }
    }




    IEnumerator capture()
    {
        System.DateTime.UtcNow.ToString();
        System.DateTime theTime = System.DateTime.Now;
        
        string a = theTime.ToString(","+"yyyy-MM-dd\\THHmmss");
        string b = theTime.ToString("dd-MM-2147");


        

        iterator = a;
        if (Animal)
        {
            iterator = Animal.tag + iterator;
            name.text = Animal.tag;
        }
        else
        {
            name.text = null;
        }
        date.text = b;

        var dirPath = Application.dataPath + "/Resources/RenderOutput";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }

        ScreenCapture.CaptureScreenshot(dirPath + "/R_" + iterator + ".png");
        yield return new WaitForSeconds(1f);
#if UNITY_EDITOR


        //hay que comprobar si se puede acceder aun si no se hace eso
        UnityEditor.AssetDatabase.Refresh();

#endif
        yield return new WaitForSeconds(0.5f);

        cam.GetComponent<testcam>()._mouseSensitivity = 2;


        
    }

}
