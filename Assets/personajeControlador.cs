using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class personajeControlador : MonoBehaviour
{ 
    public float speed = 100f;
    public float VelocidadMax = 3.5f;
    public bool TocandoSuelo = false;
    public bool saltar;
    public bool saltoDoble;
    public float fuerzaSalto = 7f;
    
    private Rigidbody2D rg2d;
    private Animator animador;
    // Start is called before the first frame update

    public SpriteRenderer[] vida;
    public SpriteRenderer[] sinVidas;
    private int vidas = 2;

    void Start()
    {
        Physics2D.gravity = new Vector2(0f,-13.5f);
        Physics2D.gravity *= 1.8f;
        Debug.Log(Physics2D.gravity);
        rg2d = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
    }

    private void Update()
    {
        animador.SetFloat("velocidad", Mathf.Abs(rg2d.velocity.x));
        animador.SetBool("enPiso", TocandoSuelo);

        if (TocandoSuelo)
        {
            saltoDoble = true;
        }
        if ( Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (TocandoSuelo)
            {
                saltar = true;
                saltoDoble = true;
            }else if(saltoDoble)
            {
                saltar = true;
                saltoDoble = false;
            }
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
        if( collision.gameObject.tag == "suelo")
        {

            TocandoSuelo = true;
        }
        if(collision.gameObject.tag == "plataforma")
        {
            transform.parent = collision.transform;
            TocandoSuelo = true;
        }



    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            TocandoSuelo = false;
        }
        if(collision.gameObject.tag == "plataforma")
        {
            transform.parent = null;
            TocandoSuelo = false;
        }
    }

    private void OnBecameInvisible()
    {
        transform.position = new Vector3(-3, 0, 0);
        perderVida();
    }

    private void perderVida()
    {
       
        if(vidas >= 1)
        {

            vida[vidas].sortingOrder = 0;
            vida[vidas].maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            sinVidas[vidas-1].sortingOrder = 1;
            sinVidas[vidas-1].maskInteraction = SpriteMaskInteraction.None;
            vidas--;
        }
        else
        {
            SceneManager.LoadScene("Portada");
        }

    }
}
