using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaSystem : MonoBehaviour
{
    public int valor=1;
    public GameManager gameManager;
    public float velocidad = 2.0f; 
    public float amplitud = 1.0f; 
    public float frecuencia = 1.0f;
    private Vector3 posicionInicial;
    public Transform moneda;

    // Update is called once per frame
    void Start()
    {
        posicionInicial = moneda.position;
    }
    private void Update()
    {
        float offsetY = Mathf.Sin(Time.time * frecuencia) * amplitud;
        Vector3 nuevaPosicion = posicionInicial + new Vector3(0, offsetY, 0);
        moneda.position = Vector3.Lerp(moneda.position, nuevaPosicion, velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarMonedas(valor);
            Destroy(this.gameObject);
        }
    }
}
