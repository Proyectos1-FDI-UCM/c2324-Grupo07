using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class MonedaSystem : MonoBehaviour
{
    public int valor = 1;
    public GameManager gameManager;
    private ControlarJugador jugador;
    public float velocidad = 2.0f;
    public float amplitud = 0.3f;
    public float frecuencia = 1.0f;
    private Vector3 posicionInicial;
    public Transform moneda = null;

    // Update is called once per frame
    void Start()
    {
        posicionInicial = moneda.transform.position;
    }
    void Update()
    {
        if (moneda != null){
            float offsetY = Mathf.Sin(Time.time * frecuencia) * amplitud;
            Vector3 nuevaPosicion = posicionInicial + new Vector3(0, offsetY, 0);
            moneda.transform.position = Vector3.Lerp(moneda.transform.position, nuevaPosicion, velocidad * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        jugador = collision.gameObject.GetComponent<ControlarJugador>();
        if (jugador != null)
        {
            gameManager.SumarMonedas(valor);
            Destroy(this.gameObject);
            gameObject.SetActive(false);
        }  
    }
}