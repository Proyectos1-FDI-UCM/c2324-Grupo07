using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class MonedaSystem : MonoBehaviour
{
    public int valor = 1;
    public GameManager gameManager;
    public float velocidad = 2.0f;
    public float amplitud = 0.3f;
    public float frecuencia = 1.0f;
    private Vector3 posicionInicial;
    public Transform moneda;
    public Transform playerTransform;

    // Update is called once per frame
    void Start()
    {
        posicionInicial = moneda.transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {

        float offsetY = Mathf.Sin(Time.time * frecuencia) * amplitud;
        Vector3 nuevaPosicion = posicionInicial + new Vector3(0, offsetY, 0);
        moneda.transform.position = Vector3.Lerp(moneda.transform.position, nuevaPosicion, velocidad * Time.deltaTime);

        float distancia = Vector3.Distance(transform.position, playerTransform.position);
        if (distancia < 1.5f)
        {
            Debug.Log("Moneda recogida");
            gameManager.SumarMonedas(valor);
            Destroy(this.gameObject);
            gameObject.SetActive(false);
        }

    }
}