using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform hercules;
    public Vector2 direccion;
    public float tiempoViaje = 2;
    public float distanciaViaje = 0;
    private Vector3 puntoInicio;
    private Vector3 puntoFinal;
    private float currentTiempoFinal;
    bool inicioAFin = true;
    private Vector3 realDirection;
    // Start is called before the first frame update
    void Start()
    {
        direccion.Normalize();
        realDirection = new Vector3(direccion.x, direccion.y);
        puntoInicio = transform.position;
        puntoFinal = transform.position + realDirection * distanciaViaje;

    }

    // Update is called once per frame
    void Update()
    {
        if (inicioAFin)
        {
            transform.position = Vector3.Lerp(puntoInicio, puntoFinal, currentTiempoFinal/tiempoViaje);
            currentTiempoFinal += Time.deltaTime;
            if (currentTiempoFinal > tiempoViaje)
            {
                inicioAFin = false;
                currentTiempoFinal = 0;
                transform.position = puntoFinal;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(puntoFinal, puntoInicio, currentTiempoFinal / tiempoViaje);
            currentTiempoFinal += Time.deltaTime;
            if (currentTiempoFinal > tiempoViaje)
            {
                inicioAFin = true;
                currentTiempoFinal = 0;
                transform.position = puntoInicio;
            }
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == hercules)
        {
            collision.gameObject.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == hercules)
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
