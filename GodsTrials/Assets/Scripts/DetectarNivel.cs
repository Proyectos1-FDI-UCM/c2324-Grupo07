using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarNivel : MonoBehaviour
{
    public int nivel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Object.DontDestroyOnLoad(this);
        if (collision.gameObject.CompareTag("Infierno"))
        {
            nivel = 1;
        }
        else if (collision.gameObject.CompareTag("Mazmorra"))
        {
            nivel = 2;
           
        }
    }


}
