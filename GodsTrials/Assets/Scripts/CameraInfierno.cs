using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraInfierno : MonoBehaviour
{
    public Transform _camara;
    public Transform _hercules;
    public float velMov = 5.0f;
    private bool moviendoseArriba = false;
    private bool moviendoseAbajo = false;
    private Vector3 posicionObjetivo;
    public LayerMask capaColisionArriba;
    public LayerMask capaColisionAbajo;

    private void Update()
    {
        if (Physics2D.OverlapCircle(_hercules.position, 1f, capaColisionArriba) && !moviendoseArriba)
        {
            posicionObjetivo = _camara.position + Vector3.up * 10;
            moviendoseArriba = true;
        }
        else if (Physics2D.OverlapCircle(_hercules.position, 1f, capaColisionAbajo) && !moviendoseAbajo)
        {
            posicionObjetivo = _camara.position - Vector3.up * 10;
            moviendoseAbajo = true;
        }
        if (moviendoseArriba)
        {
            _camara.position = Vector3.Lerp(_camara.position, posicionObjetivo, velMov * Time.deltaTime);
            if (Vector3.Distance(_camara.position, posicionObjetivo) < 0.01f)
            {
                moviendoseArriba = false;
            }
        }
        else if (moviendoseAbajo)
        {
            _camara.position = Vector3.Lerp(_camara.position, posicionObjetivo, velMov * Time.deltaTime);
            if (Vector3.Distance(_camara.position, posicionObjetivo) < 0.01f)
            {
                moviendoseAbajo = false;
            }
        }
    }
}
