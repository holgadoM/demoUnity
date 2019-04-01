using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personajeControlador : MonoBehaviour
{ 
    public float speed = 100f;
    public float VelocidadMax = 3.5f;
    public bool TocandoSuelo = false;
    public bool saltar;
    public float fuerzaSalto = 8.25f;

    private Rigidbody2D rg2d;
    private Animator animador;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity *= 1.4f;
        rg2d = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
    }

    private void Update()
    {
        animador.SetFloat("velocidad", Mathf.Abs(rg2d.velocity.x));
        animador.SetBool("enPiso", TocandoSuelo);
        if( Input.GetKeyDown(KeyCode.UpArrow) && TocandoSuelo)
        {
            saltar = true;
        }
    }

    void FixedUpdate()
    {
        //reparar friccion
        Vector3 fixVelocidad = rg2d.velocity;
        fixVelocidad.x *= 0.75f;
        if (TocandoSuelo)
        {
            rg2d.velocity = fixVelocidad;
        }
        //mover porsonaje
        float ejeX = Input.GetAxis("Horizontal");
        rg2d.AddForce(Vector2.right * speed * ejeX);

        float velocidadLimite = Mathf.Clamp( rg2d.velocity.x, -VelocidadMax, VelocidadMax );
        rg2d.velocity = new Vector2( velocidadLimite, rg2d.velocity.y );
        
            // cambiar direccion
        if( ejeX > 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if( ejeX < -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if(saltar)
        {
            rg2d.velocity = new Vector2(rg2d.velocity.x, 0); //rectificar impulso para que no salte de mas
            rg2d.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltar = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "suelo" || collision.gameObject.tag == "plataforma")
        { 
            TocandoSuelo = true;
        }

        if(collision.gameObject.tag == "llave")
        {

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo" || collision.gameObject.tag == "plataforma")
        {
            TocandoSuelo = false;
        }
    }

    private void OnBecameInvisible()
    {
        transform.position = new Vector3(-3, 0, 0);
    }
}
