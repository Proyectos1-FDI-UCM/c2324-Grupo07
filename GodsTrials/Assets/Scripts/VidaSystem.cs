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
    public float vida = 3.0f;
    public float fuerzaEmpuje = 2f;
    UIManager uiManager;
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
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Da�o(other));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        numColisiones++;

        if (numColisiones >= 2)
        {
            morir.Muerte();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        numColisiones--;
    }
    private IEnumerator Da�o(Collider2D other)
    {
        jugador.state = 1;
        hercules = other.gameObject;
        if (hercules == lavaHueco)
        {
            if (SceneManager.GetActiveScene().name == "Cueva" || SceneManager.GetActiveScene().name == "Infierno")
            {
                morir.Muerte();
            }
        }
        else if (hercules == pinchosA || hercules == pinchosD)
        {
            animatorController.Da�o();
            Debug.Log("Lee");
            vida--;
            uiManager.Vidas();
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
            animatorController.Da�o();
            Debug.Log("Lee");
            vida--;
            uiManager.Vidas();
            rb.velocity = Vector3.zero;
            Vector3 velocidad = new Vector3(1, 1, 0) * 5;
            rb.velocity = velocidad;
            if (vida <= 0)
            {
                morir.Muerte();
            }
            Debug.Log("Vida restante: " + vida);
        }
        yield return new WaitForSeconds(0.5f);
        jugador.state = 0;
    }
}