using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoControlador : MonoBehaviour
{
    private Rigidbody2D Rb2d;
    private float Velocidad = 1f;
    private float MaxVeloc = 1f;
    private Animator animacion;

    public bool animacionMuerto = false;

    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovimientoPerpetuo();
    }



    void MovimientoPerpetuo()
    {
        Rb2d.AddForce(Vector2.right * Velocidad);
        float limiteVelicidad = Mathf.Clamp(Rb2d.velocity.x, -MaxVeloc, MaxVeloc);
        Rb2d.velocity = new Vector2(limiteVelicidad, Rb2d.velocity.y);
        CambiarDireccion();
    }

    void CambiarDireccion()
    {


        if( Rb2d.velocity.x > -0.01f && Rb2d.velocity.x < 0.01f)
        {
            Velocidad = -Velocidad;
            Rb2d.velocity = new Vector2(Velocidad, Rb2d.velocity.y);
        }

        if (Rb2d.velocity.x > 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (Rb2d.velocity.x < -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }


    }

   

    private void OnTriggerEnter2D(Collider2D tri)
    {
        if (tri.gameObject.CompareTag("Player"))
        {

            float offsetY = 0.11f;
          
            if ( (  offsetY + transform.position.y ) < tri.transform.position.y)
            {
                tri.SendMessage("Salto");
                animacion.SetBool("animacionMuerto", true);
                Destroy(gameObject, .2f);
            }
            else
            {
                tri.SendMessage("SaltoPerdida", transform.position.x);
            }

        }
    }
}
