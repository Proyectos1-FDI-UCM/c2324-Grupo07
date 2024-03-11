using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    private ControlarJugador hercules;
    public GameObject pez;
    public GameObject bala;
    private bool disparo;
    Rigidbody2D rb;
    void Shoot()
    {
        if (Input.GetMouseButton(0) && disparo)
        {
            hercules = gameObject.GetComponent<ControlarJugador>();
            GameObject valBel = Instantiate(bala, hercules.transform.position + 0.5f * Vector3.up, Quaternion.identity);
            rb = valBel.GetComponent<Rigidbody2D>();
            if (bala != null)
            {
                rb.velocity = Vector3.right * 5;
                Debug.Log("gg");
            }
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
    // Start is called before the first frame update
    void Start()
    {
        disparo = false;
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
}
