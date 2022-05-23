using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIxMenuCamera : MonoBehaviour
{

    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        pause = GameObject.Find("PauseMenu");
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnEnable()
    {
        if (pause != null)
        pause.SetActive(false);

    }


    private void OnDisable()
    {
        if (pause != null)
            pause.SetActive(true);

    }
}
