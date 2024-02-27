using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasLava : MonoBehaviour
{
    public float velocidadRotacion;
    Transform rotacion;
    void Start()
    {
        rotacion = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        rotacion.localRotation *= Quaternion.AngleAxis(velocidadRotacion * Time.deltaTime, Vector3.forward);
    }
}
