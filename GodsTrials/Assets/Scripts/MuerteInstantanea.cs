using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteInstantanea : MonoBehaviour
{
    private VidaSystem vida;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        vida = collision.gameObject.GetComponent<VidaSystem>();
        if(vida != null)
        {
            vida.MuerteCompleta();
        }
    }
}
