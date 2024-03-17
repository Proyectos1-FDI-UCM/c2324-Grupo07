using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMontaña : MonoBehaviour
{
    public Transform _camara;
    public Transform _circuloCabeza;
    public Transform _circuloPies;
    public float velMov = 5.0f;
    public float distanciaVertical = 3.0f;
    public LayerMask capaColisionArriba;
    public LayerMask enSuelo;
    private bool moviendose = false;
    private void Update()
    {
        bool tocandoSuelo = Physics2D.Raycast(_circuloPies.position, Vector3.down, 0.5f, enSuelo);
        bool tocandoColliderArriba = Physics2D.Raycast(_circuloCabeza.position, Vector3.up, 0.5f, capaColisionArriba);
        bool tocandoParteInferiorPantalla = _circuloPies.position.y <= _camara.position.y - 5;
        if(_circuloPies.position.x > 1.3 && _circuloPies.position.x < 47.85 && _circuloPies.position.y < 22.7)
        {
            _camara.position = new Vector3(_circuloPies.position.x,_camara.position.y,_camara.position.z);
        }
        if(_circuloPies.position.y > 22.7 && _circuloPies.position.x < 47.85 && _circuloPies.position.x > 39.2)
        {
            _camara.position = new Vector3(_circuloPies.position.x, _camara.position.y, _camara.position.z);
        }
        if ((tocandoSuelo || tocandoColliderArriba || tocandoParteInferiorPantalla) && !moviendose)
        {
            Vector3 posicionObjetivo = new Vector3(_camara.position.x, _circuloPies.position.y + distanciaVertical, _camara.position.z);
            _camara.position = Vector3.Lerp(_camara.position, posicionObjetivo, velMov * Time.deltaTime);
            moviendose = true;
        }
        else
        {
            moviendose = false;
        }
    }
}
