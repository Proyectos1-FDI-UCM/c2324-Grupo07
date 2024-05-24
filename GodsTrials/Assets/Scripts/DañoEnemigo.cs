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
    private Animator animator;
    private float tiempoesp = 3f;
    private float time;
    private SonidoMontaña sonido;
    #endregion
    private void Start()
    {
        time = 0;
        animator = GetComponent<Animator>();
        //animator.SetInteger("bola", 0);
        sonido =GameObject.Find("Grids").GetComponent<SonidoMontaña>();
    }
    private void Update()
    {
        time += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D bola)//como danoflechas pero para los enemigos de montaña
    {
        vida = bola.gameObject.GetComponent<VidaSystem>();
        if (vida != null)
        {
            vida.Daño();
            //animator.SetInteger("bola", 1);
            sonido.RocaRota();
            Destroy(gameObject);

        }

        wall = bola.GetComponent<TilemapCollider2D>();
        if (wall != null)
        {
            //animator.SetInteger("bola", 1);
            sonido.RocaRota();
            Destroy(gameObject);
        }

    }

}
