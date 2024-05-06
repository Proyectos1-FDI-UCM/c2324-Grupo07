using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlarJugador : MonoBehaviour
{
    [SerializeField]
    private AudioSource sound;
    [SerializeField]
    private AudioClip salto;
    public float jumpvelocity = 10;
    public float platformJumpVelocity = 20;
    public float velocidadHorizontal = -30;
    public float time = 0;
    public float velocity = 5;
    private Rigidbody2D rb;
    public bool enSuelo1;
    public bool enSuelo2;
    public bool enSuelo3;
    private bool dobleSalto = true;
    public GameObject botas;
    public GameObject carro;
    public GameObject pez;
    public Transform circulo1;
    public Transform circulo2;
    public Transform saltoHercules1;
    public Transform saltoHercules2;
    public LayerMask capaSuelo;
    public bool tieneSalto = false;
    public bool dash = false;
    private bool enParedRC1;
    private bool enParedRC2;
    private bool enParedLC1;
    private bool enParedLC2;
    private ShootingComponent shoot;
    UIManager uiManager;
    public int state;
    [SerializeField]
    private GameObject efectoSalto;
    private GameObject prefabSalto;
    private float timeSalto;
    private bool SaltoEfect = false;

    private void OnCollisionEnter2D(Collision2D activarSalto)
    {
        foreach (ContactPoint2D contacto in activarSalto.contacts)
        {
            if (contacto.normal.y > 0.5f)
            {
                dobleSalto = true;
            }
        }
        if (activarSalto.gameObject.CompareTag("Plataforma salto") && activarSalto.contacts[0].point.y < transform.position.y)
        {
            rb.velocity = new Vector2(rb.velocity.x, platformJumpVelocity);

        }
        if (activarSalto.gameObject.CompareTag("Plataforma horizontal"))
        {
            state = 9;
            if (state == 9)
            {
                Vector3 velocity = new Vector3(-1, 1, 0) * platformJumpVelocity;
                rb.velocity = velocity;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D itemBotas)
    {
        if (itemBotas.gameObject == botas)
        {
            tieneSalto = true;
            botas.SetActive(false);
            uiManager.Botas();
        }

        if (itemBotas.gameObject == carro)
        {
            dash = true;
            carro.SetActive(false);
            uiManager.Carro();
        }

        if (itemBotas.gameObject == pez)
        {
            dash = true;
            pez.SetActive(false);
            uiManager.Pez();
        }

    }

    void Start()
    {
        state = 0;
        rb = GetComponent<Rigidbody2D>();
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
    }
    void Update()
    {
        if (SaltoEfect)
        {
            timeSalto += Time.deltaTime;
            if(timeSalto > 0.2f)
            {
                Destroy(prefabSalto);
                SaltoEfect = false;
            }
        }
        if (state == 9)
        {
            time += Time.deltaTime;
            if (time > 0.5)
            {
                state = 0;
            }
        }
        if (state == 0)
        {
            enSuelo1 = Physics2D.Raycast(saltoHercules1.position, Vector3.down, 0.1f, capaSuelo);
            enSuelo2 = Physics2D.Raycast(saltoHercules2.position, Vector3.down, 0.1f, capaSuelo);
            enSuelo3 = Physics2D.Raycast(circulo2.position, Vector3.down, 0.1f, capaSuelo);
            enParedRC1 = Physics2D.Raycast(circulo1.position, Vector3.right, 1f, capaSuelo);
            enParedRC2 = Physics2D.Raycast(circulo2.position, Vector3.right, 1f, capaSuelo);
            enParedLC1 = Physics2D.Raycast(circulo1.position, Vector3.left, 1f, capaSuelo);
            enParedLC2 = Physics2D.Raycast(circulo2.position, Vector3.left, 1f, capaSuelo);
            if (enSuelo1 && Input.GetKeyDown(KeyCode.Space) || enSuelo2 && Input.GetKeyDown(KeyCode.Space) || enSuelo3 && Input.GetKeyDown(KeyCode.Space))
            {
                Salto();
            }
            else if (tieneSalto && dobleSalto && Input.GetKeyDown(KeyCode.Space))
            {
                prefabSalto = Instantiate(efectoSalto, circulo2.position, Quaternion.identity);
                timeSalto = 0;
                SaltoEfect = true;
                Salto();
                dobleSalto = false;
            }
            if (Input.GetKey(KeyCode.D) && !enParedRC1 && !enParedRC2)
            {
                rb.velocity = new Vector2(velocity, rb.velocity.y);
                transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.A) && !enParedLC1 && !enParedLC2)
            {
                rb.velocity = new Vector2(-velocity, rb.velocity.y);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (!Input.anyKey)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                if (enSuelo1 || enSuelo2 || enSuelo3)
                {
                    //bloquea el rebote de las plataformas, buscar mejor integracion?
                    //rb.velocity = new Vector2(0, -2.5f);
                }
            }
        }
        if (state == 6)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    public void Salto()
    {
        sound.PlayOneShot(salto);
        rb.velocity = new Vector2(rb.velocity.x, jumpvelocity);
    }

}

