using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{
    #region parametros
    private VidaSystem vida;
    [SerializeField]
    private GameObject cam;
    #endregion


    private void OnTriggerEnter2D(Collider2D bola)
    {
        vida = bola.gameObject.GetComponent<VidaSystem>();
        if(vida != null)
        {
            vida.Daño();
            Destroy(gameObject);

        }
    }
    private void FueradeRango()
    {
        
        
    }
}
