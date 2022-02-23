using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    //Gestionar el menu de pausa
    [SerializeField]
    GameObject principal;
    [SerializeField]
    GameObject settings;
    [SerializeField]
    static bool GameIsPause = false;

    //Gestion del menu settings del volumen
    [SerializeField]
    public AudioMixer audioMixer;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        //Con tecla Esc se activa el menú de pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                ContinueGame();
            }
            else
            {
                Pause();
            }

        }
    }


    public void Pause()
    {
        bool isActive = principal.activeSelf;
        principal.SetActive(!isActive);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void ContinueGame()
    {
        bool isActive = principal.activeSelf;
        principal.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        Debug.Log("Jugando");

    }

    public void ReturnToMainMenu()
    {

        Time.timeScale = 1f;
        Debug.Log("Otra Scene");
        SceneManager.LoadScene("Menu");

    }

    public void Setting()
    {
        bool isActive = settings.activeSelf;
        settings.SetActive(false);
        bool Active = principal.activeSelf;
        principal.SetActive(true);

    }

    public void Back()
    {
        bool isActive = settings.activeSelf;
        settings.SetActive(false);
        bool Active = principal.activeSelf;
        principal.SetActive(true);
    }

    //Control de los Sliders
    public void VolumeMusic(float volume)
    {
        //audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void VolumeSFX(float volume)
    {
        //audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

}
