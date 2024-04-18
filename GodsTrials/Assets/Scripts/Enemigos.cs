using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;


public class Enemigos : MonoBehaviour
{
    #region parametros
    [SerializeField]
    private GameObject hercules;
    private Transform _mytransform;
    Animator _animator;
    float tiemporep = 3f;
    float tiempo;
    [SerializeField]
    public GameObject bola;
    private Rigidbody2D bb;
    [SerializeField]
    private float veloc = 5.0f;

    public float distanciaLinea = 3f;
    public LayerMask capaJugador;
    private bool jugadorEnRango;

    [SerializeField]
    private LayerMask capasuelo;
    #endregion

    void Start()
    {
        tiempo = 0;
        _mytransform = transform;
        _animator = GetComponent<Animator>();
        transform.rotation = Quaternion.identity;
    }


    void Update()
    {
        tiempo += Time.deltaTime;
        Vector3 direc = (hercules.transform.position - transform.position - Vector3.up);
        jugadorEnRango = Physics2D.OverlapCircle(transform.position, distanciaLinea, capaJugador);
        float distenemx = hercules.transform.position.x - transform.position.x;


        if (jugadorEnRango)
        {
            if (tiempo > 2 && tiempo < 3)
            {
                if (_animator.GetInteger("ciclope") != 2)
                {
                    _animator.SetInteger("ciclope", 1);
                }
                else
                {
                    tiempo = 0;
                }
            }
            else
            {
                if (_animator.GetInteger("ciclope") != 2)
                {
                    _animator.SetInteger("ciclope", 0);
                }
            }
            if (tiempo > tiemporep)
            {
                if (distenemx <= 0 && transform.rotation == Quaternion.identity)
                {
                    Debug.Log("gire izqu");
                    Quaternion targetRotation = Quaternion.Euler(0, 180, 0); // Quaternion de rotación deseada
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1000f); // Interpolar hacia la rotación deseada
                }
                else if (distenemx <= 0 && transform.rotation != Quaternion.identity)
                {
                    //tiene que mirar a la izqu y lo hacia antes no cambia
                }
                else if (distenemx > 0 && transform.rotation == Quaternion.identity)
                {
                    //debe ve dech y ya lo hace
                }
                else if (distenemx > 0 && transform.rotation != Quaternion.identity)
                {
                    Debug.Log("gire a dcha");
                    Quaternion targetRotation = Quaternion.Euler(0, 0, 0); // Quaternion de rotación deseada
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100f); // Interpolar hacia la rotación deseada
                }
                GameObject bols = Instantiate(bola, transform.position + Vector3.up, Quaternion.identity);
                bb = bols.GetComponent<Rigidbody2D>();
                float mod = Mathf.Sqrt(direc.x * direc.x + direc.y * direc.y);
                bb.velocity = (direc / mod) * veloc;

                tiempo = 0;

            }

        }
        else if (!jugadorEnRango) // Si el jugador está fuera del rango y hay una última bola instanciada
        {
            _animator.SetInteger("ciclope", 0);
        }
    }
    public void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaLinea);
    }
}

