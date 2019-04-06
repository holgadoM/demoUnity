using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    public GameObject jugador;
    private Vector2 minCamPos , maxCamPos;
    private Vector2 velocidad;
    // Start is called before the first frame update
    void Start()
    {
        minCamPos = new Vector2(2.5f, 2f);
        maxCamPos = new Vector2(20f, 2f);
       
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float posX = SuavizarMovimiento( transform.position.x, jugador.transform.position.x, velocidad.x);
       
        float posY = SuavizarMovimiento(transform.position.y, jugador.transform.position.y, velocidad.y);
        transform.position = new Vector3(   
                Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
                Mathf.Clamp(posY, minCamPos.y, maxCamPos.y), 
                transform.position.z);
     
    }

    float SuavizarMovimiento(float inicio, float fin, float eje )
    {
        return Mathf.SmoothDamp(inicio, fin, ref eje, .15f);
    }
}