using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaSystem : MonoBehaviour
{
    private LevelChange morir;
    [SerializeField]
    private GameObject hercules;
    [SerializeField]
    private float vida = 3.0f;
    BarraVida barravida;
    private ControlarJugador jugador;
    [SerializeField]
    private AnimatorController animatorController;
    [SerializeField]
    private Rigidbody2D rb;
    private float time;
    private float timeToEnter = 0.5f;
    private bool contador;
    public GameObject plataforma;
    public GameObject tilemap;
    private bool colisionandoConObjeto1 = false;
    private bool colisionandoConObjeto2 = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == plataforma)
        {
            colisionandoConObjeto1 = true;
        }
        if (collision.gameObject == tilemap)
        {
            colisionandoConObjeto2 = true;
        }
        if (colisionandoConObjeto1 && colisionandoConObjeto2)
        {
            MuerteCompleta();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == plataforma)
        {
            colisionandoConObjeto1 = false;
        }
        if (collision.gameObject == tilemap)
        {
            colisionandoConObjeto2 = false;
        }
    }
    private void Start()
    {
        morir = GameObject.Find("GameManager").GetComponent<LevelChange>();
        jugador = GetComponent<ControlarJugador>();
        rb = GetComponent<Rigidbody2D>();
        time = 0;
        contador = false;
        barravida = GameObject.Find("barravida").GetComponent<BarraVida>();
    }
    public void MuerteCompleta()
    {
        barravida.DanoTotal();
        morir.Muerte();
    }
    public void Daño()
    {
        animatorController.Dano();
        barravida.DanoTres();
        vida--;
        if (vida <= 0)
        {
            morir.Muerte();
        }
    }
    public void ImpulsoPorDaño()
    {
        jugador.state = 1;
        if (hercules.transform.rotation == Quaternion.identity)
        {
            Vector3 velocidad = new Vector3(-1, 1, 0) * 5;
            rb.velocity = velocidad;
        }
        else
        {
            Vector3 velocidad = new Vector3(1, 1, 0) * 5;
            rb.velocity = velocidad;
        }
        contador = true;
    }
    private void Update()
    {
        if (contador)
        {
            time += Time.deltaTime;
            if (time > timeToEnter)
            {
                jugador.state = 0;
            }
        }
    }
}