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
    public AnimatorController animatorController;
    public Rigidbody2D rb;
    private void Start()
    {
        morir = GameObject.Find("GameManager").GetComponent<LevelChange>();
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        hercules = other.gameObject;
        if (hercules == lavaHueco)
        {
            if (SceneManager.GetActiveScene().name == "Cueva" || SceneManager.GetActiveScene().name == "Infierno")
            {
                morir.Muerte();
            }
        }
        else if (hercules == pinchosA || hercules == pinchosI || hercules == pinchosD ||
                 hercules == bolaFuego1 || hercules == bolaFuego2)
        {
            animatorController.Daño();
            Debug.Log("Lee");
            vida--;
            uiManager.Vidas();
            Vector3 velocidad = new Vector3(1, 1, 0) * 5;
            rb.velocity = velocidad;
            if (vida <= 0)
            {
                morir.Muerte();
            }
            Debug.Log("Vida restante: " + vida);
        }
    }
}