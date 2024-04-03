using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DañoEnemigo : MonoBehaviour
{
    #region parametros
    private VidaSystem vida;
    private TilemapCollider2D wall;
  
    #endregion

    private void OnTriggerEnter2D(Collider2D bola)
    {
        vida = bola.gameObject.GetComponent<VidaSystem>();
        if(vida != null)
        {
            vida.Daño();
            Destroy(gameObject);

        }
        wall = bola.GetComponent<TilemapCollider2D>();
        if(wall != null)
        {
            Destroy(gameObject);
        }
        
    }
    private void FueradeRango()
    {
        
        
    }
}
