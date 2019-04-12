using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    bool Activo;
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown("space"))
        {
            Activo = !Activo;
            canvas.enabled = Activo;
            Time.timeScale = (Activo) ? 0 : 1f;
        }
    }
}
