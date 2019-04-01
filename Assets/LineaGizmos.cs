using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineaGizmos : MonoBehaviour
{
    public Transform desde;
    public Transform hasta;


    private void FixedUpdate()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(desde.position, hasta.position);

    }
}
