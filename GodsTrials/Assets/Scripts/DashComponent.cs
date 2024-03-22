using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashComponent : MonoBehaviour
{
    private float time;
    private float timeToDash = 0.2f;
    bool dashea;
    private ControlarJugador jugador;
    private Rigidbody2D hercules;
    private bool dashActive;
    public GameObject carro;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == carro)
        {
            dashActive = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        hercules = GetComponent<Rigidbody2D>();
        dashea = true;
        dashActive = false;
        jugador = GetComponent<ControlarJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashea && dashActive)
        {
            time = 0;
            jugador.state = 3;
            if (transform.rotation == Quaternion.identity)
            {
                hercules.velocity = new Vector3(35, 0, 0);
            }
            else
            {
                hercules.velocity = new Vector3(-35, 0, 0);
            }
            dashea = false;
        }
        time += Time.deltaTime;
        if (time > timeToDash)
        {
            if (jugador.state == 3)
            {
                hercules.velocity = new Vector3(0, hercules.velocity.y, 0);
            }
            if (time > 1f)
            {
                dashea = true;
            }
            jugador.state = 0;
        }
    }
}
