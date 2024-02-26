using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaManager : MonoBehaviour
{
    public GameObject hercules;
    private Vector3 posicionInicial;
    private void Start()
    {
        posicionInicial = hercules.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == hercules)
        {
            hercules.transform.position = posicionInicial;
        }
    }
}