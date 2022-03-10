using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SnapshotScript snapCam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            snapCam.CallTakeSnapshot();
        }
    }
}
