using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zona1 : MonoBehaviour
{
    public GameObject zona;
    public GameObject zona2;



    private void OnEnable()
    {
        zona.SetActive(false);
        zona2.SetActive(false);

    }
}
