using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaSystem : MonoBehaviour
{
    private LevelChange morir;
    public GameObject lavaHueco;
    public GameObject pinchosA;
    public GameObject pinchosI;
    public GameObject pinchosD;
    public GameObject bolaFuego1;
    public GameObject bolaFuego2;
    public float vida = 3.0f;

    private void Start()
    {
        morir = GameObject.Find("GameManager").GetComponent<LevelChange>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == lavaHueco)
        {
            if (SceneManager.GetActiveScene().name == "Cueva")
            {
                morir.Muerte();
                StartCoroutine(DelayedAfterDeath());
            }
            else if (SceneManager.GetActiveScene().name == "Infierno")
            {
                morir.Muerte();
            }
        }
        else if (other.gameObject == pinchosA || other.gameObject == pinchosI || other.gameObject == pinchosD ||
                 other.gameObject == bolaFuego1 || other.gameObject == bolaFuego2)
        {
            vida--;
            if (vida <= 0)
            {
                morir.Muerte();
            }
            Debug.Log("Vida restante: " + vida);
        }
    }
    IEnumerator DelayedAfterDeath()
    {
        Debug.Log("Entra");
        yield return new WaitForSeconds(5f);
        Debug.Log("Sale");
        SceneManager.LoadScene(1);
    }
}