using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class TrueManiMenu : MonoBehaviour
{

    //Gestionar el menu de pausa
    [SerializeField]
    GameObject principal;
    [SerializeField]
    GameObject settings;
     [SerializeField]
    GameObject exit;
    [SerializeField]
    static bool GameIsPause = false;

    //Gestion del menu settings del volumen
    [SerializeField]
    public AudioMixer audioMixer;

    //Resoluciones de pantalla
    [SerializeField]
    Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private GameObject cam;
    private GameObject player;
    public bool can;
    public Canvas[] canvas;

    private void Start()
    {   
        Cursor.visible = true;
        player = GameObject.Find("Player");
        cam = GameObject.Find("CameraCollider");
        //Resolucion pantalla
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        
    }


    public void PlayGame()
    {
        try
        {
            string filePath = Application.dataPath + "/RenderOutput";

            var dir = new DirectoryInfo(filePath);
            dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
            dir.Delete(true);



        }
        catch
        {
            Debug.Log("falie");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        //Con tecla Esc se activa el menu de pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           exit.SetActive(true);
        }
    }

    //Control de los Sliders
    public void VolumeMusic(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void VolumeSFX(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    //Control de ajustes de pantalla
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ActiveSettings()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        bool isActive = settings.activeSelf;
        settings.SetActive(true);
        bool Active = principal.activeSelf;
        cam.GetComponent<testcam>().enabled = false;
        player.GetComponent<ThirdPersonMovement>().enabled = false;
        Time.timeScale = 0f;

    }


    void OnLevelWasLoaded(int level)
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void ExitGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
      


    }


}