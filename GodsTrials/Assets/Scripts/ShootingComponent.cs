using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    private ControlarJugador hercules;
    public GameObject pez;
    public GameObject bala;
    public GameObject ciclope;
    private bool disparo;
    private bool shoot;
    private float time;
    private float timeToShoot = 0.5f;
    private float velocidadBala = 7;
    Rigidbody2D rb;
    void Shoot()
    {
        if (Input.GetMouseButton(0) && disparo && shoot)
        {
            time = 0;
            hercules = gameObject.GetComponent<ControlarJugador>();
            Vector3 instantiate;
            if(hercules.transform.rotation == Quaternion.identity)
            {
                instantiate = new Vector3(hercules.transform.position.x + 0.8f, hercules.transform.position.y + 0.4f, 0);
            }
            else
            {
                instantiate = new Vector3(hercules.transform.position.x - 0.8f, hercules.transform.position.y + 0.4f, 0);
            }
            GameObject valBel = Instantiate(bala, instantiate, Quaternion.identity);
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
        Debug.Log(disparo);
    }
    void Start()
    {
        disparo = false;
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
