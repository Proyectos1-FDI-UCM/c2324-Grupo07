using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosCupido : MonoBehaviour
{
    #region parametros
    [SerializeField]
    private GameObject hercules;
    private Transform _mytransform;
    Animator _animator;
    float tiemporep = 1f;
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
    }


    void Update()
    {
        tiempo += Time.deltaTime;
        jugadorEnRango = Physics2D.OverlapCircle(transform.position, distanciaLinea, capaJugador);

        if (jugadorEnRango)
        {
            if (tiempo > tiemporep)
            {


                _animator.SetTrigger("cupido");
                GameObject bols = Instantiate(bola, transform.position, Quaternion.identity);
                bb = bols.GetComponent<Rigidbody2D>();
                if (transform.rotation == Quaternion.identity)
                {

                    bb.velocity = Vector3.right * veloc;
                    bols.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    bb.velocity = Vector3.left * veloc;
                    bols.transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                tiempo = 0;

            }

        }
        else if (!jugadorEnRango) // Si el jugador está fuera del rango y hay una última bola instanciada
        {
            _animator.ResetTrigger("cupido"); ;
        }
    }
    public void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaLinea);
      
    }
}

