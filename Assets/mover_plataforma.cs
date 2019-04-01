using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover_plataforma : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 1f;
    public Vector3 inicio;
    public Vector3 final;
    void Start()
    {
        if( objetivo != null)
        {
            objetivo.parent = null;
            inicio = transform.position;
            final = objetivo.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if( objetivo != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
        }

        if( transform.position == objetivo.position)
        {
            objetivo.position = (objetivo.position == inicio) ? final : inicio;
        }
    }
}
