using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPinchos : MonoBehaviour
{
    public Transform pinchosIzquierda, pinchosDerecha;
    float movimiento = 10;
    public float tiempoMovimiento = 10;
    float currentTime;
    Vector3 finalIzquierda, finalDerecha, inicioIzquierda, inicioDerecha;
    bool inicio;
    // Start is called before the first frame update
    void Start()
    {
        finalIzquierda = pinchosIzquierda.position + new Vector3(movimiento, 0);
        finalDerecha = pinchosDerecha.position + new Vector3(- movimiento, 0);
        inicioIzquierda = pinchosIzquierda.position; 
        inicioDerecha = pinchosDerecha.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < tiempoMovimiento && inicio)
        {
            pinchosIzquierda.position = Vector3.Lerp(inicioIzquierda, finalIzquierda, currentTime / tiempoMovimiento);
            pinchosDerecha.position = Vector3.Lerp(inicioDerecha, finalDerecha, currentTime / tiempoMovimiento);
            currentTime += Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inicio = true;
        }
    }
}
