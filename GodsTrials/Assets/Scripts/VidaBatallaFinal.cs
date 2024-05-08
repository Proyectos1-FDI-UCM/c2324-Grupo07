using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBatallaFinal : MonoBehaviour
{
    [SerializeField]
    private AudioSource daño;
    [SerializeField]
    private AudioClip dolor;
    [SerializeField]
    private float vidaHercules = 25;
    float time;
    private LevelChange morir;
    bool stun = false;
    private ControlarJugador player;
    BarraVida barravida;
    AnimatorController animator;
    [SerializeField]
    private Zeus _zeus;
    private float time1 = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("rayo"))
        {
            daño.PlayOneShot(dolor);
            vidaHercules--;
            animator.Dano();
            barravida.DanoRayo();
            Destroy(collision.gameObject);    
        }
        if (collision.gameObject.CompareTag("stun"))
        {
            stun = true;
            vidaHercules-= 0.25f;
            animator.Dano();
            barravida.DanoStuns();
        }
        if (vidaHercules <= 0)
        {
            Destroy(this.gameObject);
            Destroy(_zeus.gameObject);
            morir.Muerte();
        }
    }
    private void Start()
    {
        player = GetComponent<ControlarJugador>();
        morir = GameObject.Find("GameManager").GetComponent<LevelChange>();
        animator = GetComponent<AnimatorController>();
        barravida = GameObject.Find("barravidahercules").GetComponent<BarraVida>();
    }
    private void Update()
    {
        time1 += Time.deltaTime;
        if(time1 < 4)
        {
            player.state = 20;
        }
        if (stun)
        {
            player.state = 6;    
            time += Time.deltaTime;
            if(time > 1.5f)
            {
                player.state = 0;
                time = 0;
                stun = false;
            }
        }
    }
}
