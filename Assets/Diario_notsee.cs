using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Diario_notsee : MonoBehaviour
{
    public Button[] zonas;

    private void OnDisable()
    {
        foreach (var t in zonas)
        {
            t.enabled = true;
        }
    }

    private void OnEnable()
    {
        foreach (var t in zonas)
        {
            t.enabled = false;
        }
    }
}
