using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_caida : MonoBehaviour
{
    private Rigidbody2D rg2d;
    private PolygonCollider2D pc2d;
    private Vector3 inicio;

    public float tiempoCaida = 1f;
    public float tiempoReaparecer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<PolygonCollider2D>();
        inicio = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Caer", tiempoCaida);
            Invoke("Reaparecer", tiempoCaida + tiempoReaparecer);
        }
    }

    void Caer()
    {
        rg2d.isKinematic = false;
        pc2d.isTrigger = true;


    }


    void Reaparecer()
    {
        transform.position = inicio;
        rg2d.isKinematic = true;
        rg2d.velocity = Vector3.zero;
        pc2d.isTrigger = false;
    }
}
