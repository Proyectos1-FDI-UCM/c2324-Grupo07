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
    private float veloc = 1.0f;

    public float distanciaLinea = 3f;
    public LayerMask capaJugador;
    private bool jugadorEnRango;
    #endregion

    void Start()
    {
        tiempo = 3;
        _mytransform = transform;
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        tiempo += Time.deltaTime;
       Vector3 direc= (hercules.transform.position - transform.position-Vector3.up);
        jugadorEnRango = Physics2D.OverlapCircle(transform.position, distanciaLinea, capaJugador);
     
        if (jugadorEnRango)

        {
            
            if (tiempo > tiemporep)
            {
               
                GameObject bols = Instantiate(bola, transform.position + Vector3.up, Quaternion.identity);
                _animator.SetTrigger("New Trigger");
                bb = bols.GetComponent<Rigidbody2D>();
                float mod = Mathf.Sqrt(direc.x * direc.x + direc.y * direc.y);
                bb.velocity = (direc/mod) * veloc;
                tiempo = 0;

            }
        }
        else if (!jugadorEnRango) // Si el jugador está fuera del rango y hay una última bola instanciada
        {
           

        }

    }

    public void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaLinea);
    }
}

