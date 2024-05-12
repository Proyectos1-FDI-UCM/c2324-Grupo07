using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DashComponent : MonoBehaviour
{
    private float time;
    private float timeToDash = 0.2f;
    [SerializeField]
    bool dashea;
    private ControlarJugador jugador;
    private Rigidbody2D hercules;
    [SerializeField]
    private bool dashActive = false;
    public GameObject carro;
    [SerializeField]
    private GameObject efectoDash;
    private GameObject prefabDash;
    [SerializeField] private AudioSource dash;
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
        jugador = GetComponent<ControlarJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashea && dashActive && jugador.state != 20)
        {
            dash.Play();

            time = 0;
            jugador.state = 3;
            if (transform.rotation == Quaternion.identity)
            {
                prefabDash = Instantiate(efectoDash, transform.position + Vector3.right * 3, Quaternion.identity);
                hercules.velocity = new Vector3(35, 0, 0);
            }
            else
            {
                prefabDash = Instantiate(efectoDash, transform.position + Vector3.left * 3, Quaternion.Euler(0, 180, 0));
                hercules.velocity = new Vector3(-35, 0, 0);
            }
            dashea = false;
        }
        time += Time.deltaTime;
        if (time > timeToDash)
        {
            Destroy(prefabDash);
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
