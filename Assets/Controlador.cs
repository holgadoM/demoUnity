using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{

    public void CambiarScene(string nombre){
        SceneManager.LoadScene(nombre);
    }

    public void Salir(){
        print("Saliendo...");
        Application.Quit();
    }


}
