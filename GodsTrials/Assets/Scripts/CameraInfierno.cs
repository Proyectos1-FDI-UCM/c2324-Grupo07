using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraInfierno : MonoBehaviour
{
    public Transform _camara;
    public Transform _circuloCabeza;
    public Transform _circuloPies;
    public float velMov = 5.0f;
    private Vector3 posicionObjetivo;
    public LayerMask capaColisionArriba;
    public LayerMask enSuelo;

    private void Update()
    {
        posicionObjetivo = new Vector3(_camara.position.x, _circuloPies.position.y + 3, _camara.position.z);
        if (Physics2D.Raycast(_circuloPies.position, Vector3.down, 0.5f, enSuelo) ||
            Physics2D.Raycast(_circuloCabeza.position, Vector3.up, 0.5f, capaColisionArriba))
        {
            _camara.position = Vector3.Lerp(_camara.position, posicionObjetivo, velMov * Time.deltaTime);
        }
    }
}
