using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;

public class ControlarJugador : MonoBehaviour
{
    public float jumpvelocity = 10;
    public float velocity = 5;
    private Rigidbody2D rb;
    private bool enSuelo;
    private bool dobleSalto = true;
    public GameObject botas;
    public Transform suelo;
    public Transform pared;
    public LayerMask capaSuelo;
    public LayerMask capaPared;
    public bool tieneSalto = false;
    private bool enPared;
    private void OnCollisionEnter2D(Collision2D activarSalto)
    {
        foreach (ContactPoint2D contacto in activarSalto.contacts)
        {
            if (contacto.normal.y > 0.5f)
            {
                dobleSalto = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D itemBotas)
    {
        if (itemBotas.gameObject == botas)
        {
            tieneSalto = true;
            botas.SetActive(false);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        enSuelo = Physics2D.OverlapCircle(suelo.position, 1f, capaSuelo);
        enPared = Physics2D.OverlapCircle(pared.position, 1f, capaPared);
        Debug.Log(enPared);
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            Salto();
        }
        else if (tieneSalto && dobleSalto && Input.GetKeyDown(KeyCode.Space))
        {
            Salto();
            dobleSalto = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
        }
        else if (!Input.anyKey || enPared && !enSuelo)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void Salto()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpvelocity);
    }
}

