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
    Rigidbody2D rb;
    void Shoot()
    {
        if (Input.GetMouseButton(0) && disparo && shoot)
        {
            hercules = gameObject.GetComponent<ControlarJugador>();
            GameObject valBel = Instantiate(bala, hercules.transform.position + 0.5f * Vector3.up, Quaternion.identity);
            rb = valBel.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (hercules.transform.rotation == Quaternion.identity)
                {
                    rb.velocity = Vector2.right * 15;
                }
                else
                {
                    rb.velocity = Vector2.left * 15;
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
