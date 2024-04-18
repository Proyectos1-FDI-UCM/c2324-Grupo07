using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DanoFlechas : MonoBehaviour
{
    #region parametros
    private VidaSystem vida;
    private TilemapCollider2D wall;
    private Animator animator;
    private float tiempoesp = 3f;
    private float time;

    #endregion
    private void Start()
    {
        time = 0;
        animator = GetComponent<Animator>();
        //animator.SetInteger("bola", 0);
    }
    private void Update()
    {
        time += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D bola)
    {
        vida = bola.gameObject.GetComponent<VidaSystem>();
        if (vida != null)
        {
            vida.DañoCupido();
            Destroy(gameObject);
        }

        wall = bola.GetComponent<TilemapCollider2D>();
        if (wall != null)
        {
            Destroy(gameObject);
        }

    }
}
