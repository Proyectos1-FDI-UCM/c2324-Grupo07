using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    private Animator animator;
    private ControlarJugador hercules;
    public GameObject pez;
    public GameObject bala;
    public GameObject ciclope;
    public bool disparo = false;
    private bool shoot;
    private float time;
    private float timeToShoot = 0.5f;
    private float velocidadBala = 7;
    Rigidbody2D rb;
    void Shoot()
    {
        if (Input.GetKey(KeyCode.J) && disparo && shoot)
        {
            time = 0;
            hercules = gameObject.GetComponent<ControlarJugador>();
            Vector3 instantiate;
            if(hercules.transform.rotation == Quaternion.identity)
            {
                instantiate = new Vector3(hercules.transform.position.x + 0.8f, hercules.transform.position.y + 0.4f, 0);
                bala.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                instantiate = new Vector3(hercules.transform.position.x - 0.8f, hercules.transform.position.y + 0.4f, 0);
                bala.transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            GameObject valBel = Instantiate(bala, instantiate, bala.transform.rotation);
            rb = valBel.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (hercules.transform.rotation == Quaternion.identity)
                {
                    rb.velocity = Vector2.right * velocidadBala;
                }
                else
                {
                    rb.velocity = Vector2.left * velocidadBala;
                }
            }
            shoot = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == pez)
        {
            disparo = true;
        }
    }
    void Start()
    {
        shoot = true;
        time = 0;
    }
    void Update()
    {
        Shoot();
        time += Time.deltaTime;
        if(time > timeToShoot)
        {
            shoot = true;
            time = 0;
        }
    }
}
