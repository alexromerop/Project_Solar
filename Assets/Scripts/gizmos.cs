using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmos : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1);
    }
}
