using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaSystem : MonoBehaviour
{
    private LevelChange morir;
    public GameObject hercules;
    public GameObject lavaHueco;
    public GameObject pinchosA;
    public GameObject pinchosI;
    public GameObject pinchosD;
    public GameObject bolaFuego1;
    public GameObject bolaFuego2;
    public Collider2D Grid;
    public Collider2D Plataforma;
    private bool contacto1 = false;
    private bool contacto2 = false;
    public float vida = 3.0f;
    public float fuerzaEmpuje = 2f;
    UIManager uiManager;
    BarraVida barravida;
    private ControlarJugador jugador;
    public AnimatorController animatorController;
    public Rigidbody2D rb;
    private int numColisiones = 0;

    private void Start()
    {
        morir = GameObject.Find("GameManager").GetComponent<LevelChange>();
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        jugador = GetComponent<ControlarJugador>();
        rb = GetComponent<Rigidbody2D>();
        barravida = GameObject.Find("barravida").GetComponent<BarraVida>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Dano(other));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider == Grid)
        {
            contacto1 = true;
        }
        else if(collision.collider == Plataforma)
        {
            contacto2 = true;
        }
        if(contacto1 && contacto2)
        {
            morir.Muerte();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider == Grid)
        {
            contacto1 = false;
        }
        else if(collision.collider == Plataforma)
        {
            contacto2 = false;
        }
    }

    private IEnumerator Dano(Collider2D other)
    {
        jugador.state = 1;
        hercules = other.gameObject;
        if (hercules == lavaHueco)
        {
            if (SceneManager.GetActiveScene().name == "Cueva" || SceneManager.GetActiveScene().name == "Infierno")
            {
                morir.Muerte();
                barravida.DanoTotal();
            }
        }
        else if (hercules == pinchosA || hercules == pinchosD)
        {
            animatorController.Dano();
            Debug.Log("Lee");
            vida--;
            barravida.DanoTres();
            rb.velocity = Vector3.zero;
            Vector3 velocidad = new Vector3(-1, 1, 0) * 5;
            rb.velocity = velocidad;
            if (vida <= 0)
            {
                morir.Muerte();
            }
            Debug.Log("Vida restante: " + vida);
        }
        else if (hercules == bolaFuego1 || hercules == bolaFuego2 || hercules == pinchosI)
        {
            animatorController.Dano();
            Debug.Log("Lee");
            vida--;
            barravida.DanoTres();
            rb.velocity = Vector3.zero;
            Vector3 velocidad = new Vector3(1, 1, 0) * 5;
            rb.velocity = velocidad;
            if (vida <= 0)
            {
                Destroy(this.gameObject);
                morir.Muerte();
            }
            Debug.Log("Vida restante: " + vida);
        }
        yield return new WaitForSeconds(0.5f);
        jugador.state = 0;
    }
}