using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntosllave : MonoBehaviour
{
    public GameObject llave;
    public Text total;
    // Start is called before the first frame update
    void Start()
    {
        total.text = "0";

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(llave);
        total.text = (int.Parse(total.text) + 10).ToString();
    }
}
