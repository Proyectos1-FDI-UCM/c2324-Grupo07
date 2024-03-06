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
    public GameObject moneda;
    public GameObject hercules;

    // Update is called once per frame
    void Start()
    {
        posicionInicial = moneda.transform.position;
    }
    private void Update()
    {
        float offsetY = Mathf.Sin(Time.time * frecuencia) * amplitud;
        Vector3 nuevaPosicion = posicionInicial + new Vector3(0, offsetY, 0);
        moneda.transform.position = Vector3.Lerp(moneda.transform.position, nuevaPosicion, velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entra");
        if (collision.gameObject == hercules)
        {
            Debug.Log("Collides");

            gameManager.SumarMonedas(valor);
            Destroy(moneda);
        }
    }
}
