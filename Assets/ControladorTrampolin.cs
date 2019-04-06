using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTrampolin : MonoBehaviour
{
    public SpriteRenderer estirado;
    public SpriteRenderer comprimido;

    private float impulso = 4.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("entrando...");

        estirado.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        comprimido.maskInteraction = SpriteMaskInteraction.None;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("saliendo...");
        estirado.maskInteraction = SpriteMaskInteraction.None;
        comprimido.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        collision.rigidbody.AddForce(Vector2.up * impulso,ForceMode2D.Impulse);
    }


}
