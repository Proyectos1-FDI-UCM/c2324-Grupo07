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
    public Transform hercules;
    public Transform circulo1;
    public Transform circulo2;
    public LayerMask capaSuelo;
    public LayerMask capaPared;
    public bool tieneSalto = false;
    private bool enParedRC1;
    private bool enParedRC2;
    private bool enParedLC1;
    private bool enParedLC2;
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
        enSuelo = Physics2D.OverlapCircle(hercules.position, 1f, capaSuelo);
        enParedRC1 = Physics2D.Raycast(circulo1.position, Vector3.right, 1f, capaPared);
        enParedRC2 = Physics2D.Raycast(circulo2.position, Vector3.right, 1f, capaPared);
        enParedLC1 = Physics2D.Raycast(circulo1.position, Vector3.left, 1f, capaPared);
        enParedLC2 = Physics2D.Raycast(circulo2.position, Vector3.left, 1f, capaPared);
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            Salto();
        }
        else if (tieneSalto && dobleSalto && Input.GetKeyDown(KeyCode.Space))
        {
            Salto();
            dobleSalto = false;
        }
        if (Input.GetKey(KeyCode.D) && !enParedRC1 && !enParedRC2)
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.A) && !enParedLC1 && !enParedLC2)
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
        }
        else if (!Input.anyKey)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (enSuelo)
            {
                rb.velocity= new Vector2(0,0);
            }
        }
    }
    
    public void Salto()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpvelocity);
    }
}

