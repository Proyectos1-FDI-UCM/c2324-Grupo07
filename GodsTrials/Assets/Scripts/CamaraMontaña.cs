using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class CamaraMontaña : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    public Camera _camara = Camera.main;
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
        bool tocandoParteInferiorPantalla = _circuloPies.position.y <= _camara.transform.position.y - 5;
        if (_circuloPies.position.y > -6.9)
        {
            if (_circuloPies.position.x > 1.3 && _circuloPies.position.x < 140.7 && _circuloPies.position.y < 22.7)
            {
                canvas.SetActive(true);
                _camara.transform.position = new Vector3(_circuloPies.position.x, _camara.transform.position.y, _camara.transform.position.z);
            }
            if (_circuloPies.position.y > 22.7 && _circuloPies.position.x < 140.7 && _circuloPies.position.x > 132.4)
            {
                canvas.SetActive(true);
                _camara.transform.position = new Vector3(_circuloPies.position.x, _camara.transform.position.y, _camara.transform.position.z);
            }
            if ((tocandoSuelo || tocandoColliderArriba || tocandoParteInferiorPantalla) && !moviendose)
            {
                canvas.SetActive(true);
                Vector3 posicionObjetivo = new Vector3(_camara.transform.position.x, _circuloPies.position.y + distanciaVertical, _camara.transform.position.z);
                _camara.transform.position = Vector3.Lerp(_camara.transform.position, posicionObjetivo, velMov * Time.deltaTime);
                moviendose = true;
            }
            else
            {
                canvas.SetActive(true);
                moviendose = false;
            }
        }
        if (_circuloPies.position.y < -6.9f)
        {
            canvas.SetActive(false);
            _camara.orthographicSize = 18;
            _camara.transform.position = new Vector3(59.7f, -38f, _camara.transform.position.z);
        }
        if (_circuloPies.position.y > -6.8f && _circuloPies.position.x > -0.6f)
        {
            _camara.orthographicSize = 6;
            _camara.transform.position = new Vector3(_circuloPies.position.x, _camara.transform.position.y, _camara.transform.position.z);
        }
    }
}
