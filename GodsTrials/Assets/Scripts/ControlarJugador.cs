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
    private bool enSuelo1;
    private bool enSuelo2;
    private bool dobleSalto = true;
    public GameObject botas;
    public GameObject hercules;
    public Transform circulo1;
    public Transform circulo2;
    public Transform saltoHercules1;
    public Transform saltoHercules2;
    public LayerMask capaSuelo;
    public bool tieneSalto = false;
    private bool enParedRC1;
    private bool enParedRC2;
    private bool enParedLC1;
    private bool enParedLC2;
    UIManager uiManager;
    public int state = 0;
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
        hercules = itemBotas.gameObject;
        if (hercules == botas)
        {
            tieneSalto = true;
            botas.SetActive(false);
            uiManager.PowerUps();
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
    }
    void Update()
    {
        if (state == 0)
        {
            enSuelo1 = Physics2D.Raycast(saltoHercules1.position, Vector3.down, 0.1f, capaSuelo);
            enSuelo2 = Physics2D.Raycast(saltoHercules2.position, Vector3.down, 0.1f, capaSuelo);
            enParedRC1 = Physics2D.Raycast(circulo1.position, Vector3.right, 1f, capaSuelo);
            enParedRC2 = Physics2D.Raycast(circulo2.position, Vector3.right, 1f, capaSuelo);
            enParedLC1 = Physics2D.Raycast(circulo1.position, Vector3.left, 1f, capaSuelo);
            enParedLC2 = Physics2D.Raycast(circulo2.position, Vector3.left, 1f, capaSuelo);
            if (enSuelo1 && Input.GetKeyDown(KeyCode.Space) || enSuelo2 && Input.GetKeyDown(KeyCode.Space))
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
                if (enSuelo1 || enSuelo2)
                {
                    rb.velocity = new Vector2(0, -2.5f);
                }
            }
        }
    }
    
    public void Salto()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpvelocity);
    }
}

