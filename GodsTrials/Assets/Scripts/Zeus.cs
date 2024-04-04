using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeus : MonoBehaviour
{
    private float time1;
    private float time2;
    float randomX;
    float randomY;
    [SerializeField]
    private float vel = 2f;
    private Rigidbody2D zeusRB;
    private bool changeVel = false;
    private Vector3 randomVelocity;
    public LayerMask suelo;
    private float timeDisparos1;
    private float timeDisparos2;
    [SerializeField]
    private float estado;
    [SerializeField]
    private GameObject rayo;
    private Rigidbody2D proyectilRB;
    public GameObject hercules;
    float dispara1;
    float dispara2;
    float sizeX = 15;
    float sizeY = 15;
    // Start is called before the first frame update
    void Start()
    {
        time1 = 0;
        time2 = 0;
        dispara1 = 0;
        dispara2 = 0;
        timeDisparos1 = -1;
        timeDisparos2 = 0;
        zeusRB = GetComponent<Rigidbody2D>();
        estado = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == 2)
        {
            time1 += Time.deltaTime;
            if (time1 < 2f)
            {
                zeusRB.velocity = Vector3.up * vel;
                transform.localScale += new Vector3(4f, 4f) * Time.deltaTime;
            }
            if (time1 > 2f && time1 < 4f)
            {
                zeusRB.velocity = Vector3.down * vel;
                transform.localScale -= new Vector3(4f, 4f) * Time.deltaTime;
                if (time1 > 3.9f)
                {
                    estado = 0;
                }
            }
        }
        if (estado == 0)
        {
            time2 += Time.deltaTime;
            timeDisparos1 += Time.deltaTime;
            dispara1 += Time.deltaTime;
            if (time2 > 0f && time2 < 0.1f)
            {
                randomX = Random.Range(-1f, 1f) * 5f;
                randomY = Random.Range(-1f, 1f) * 5f;
                randomVelocity = new Vector3(randomX, randomY);
                changeVel = true;
            }
            if (changeVel)
            {
                if (transform.position.y > -3.2 && transform.position.y < 2.8 && transform.position.x < 8.75 && transform.position.x > -9.15)
                {
                    zeusRB.velocity = randomVelocity;
                    if (time2 > 2f)
                    {
                        changeVel = false;
                        time2 = 0f;
                    }
                }
            }
            if (transform.position.y < -3.2)
            {
                zeusRB.velocity = new Vector3(randomX, 5);
                changeVel = false;
                if (time2 > 2f)
                {
                    time2 = 0f;
                }
            }
            else if (transform.position.y > 2.8)
            {
                zeusRB.velocity = new Vector3(randomX, -5);
                changeVel = false;
                if (time2 > 2f)
                {
                    time2 = 0f;
                }
            }
            if (transform.position.x > 8.75)
            {
                zeusRB.velocity = new Vector3(-5, randomY);
                changeVel = false;
                if (time2 > 2f)
                {
                    time2 = 0f;
                }
            }
            else if (transform.position.x < -9.15)
            {
                zeusRB.velocity = new Vector3(5, randomY);
                changeVel = false;
                if (time2 > 2f)
                {
                    time2 = 0f;
                }
            }
            if (timeDisparos1 < 10 && timeDisparos1 > 0)
            {
                if (dispara1 < 0.02)
                {
                    Vector3 direc = (hercules.transform.position - transform.position);
                    GameObject proyectil = Instantiate(rayo, transform.position, Quaternion.identity);
                    dispara1 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    float mod = Mathf.Sqrt(direc.x * direc.x + direc.y * direc.y);
                    proyectilRB.velocity = (direc / mod) * 12;
                }
                if (dispara1 > 1.25f)
                {
                    dispara1 = 0;
                }
            }
            if (timeDisparos1 > 10)
            {
                timeDisparos2 = 0;
                dispara2 = 0;
                estado = 1;
                sizeX = 15;
                sizeY = 15;
            }
        }
        if (estado == 1)
        {
            timeDisparos2 += Time.deltaTime;
            if (timeDisparos2 < 4)
            {
                zeusRB.velocity = Vector3.zero;
                transform.localScale += new Vector3(1.5f, 1.5f) * Time.deltaTime;
            }
            if (timeDisparos2 > 4 && timeDisparos2 < 4.1)
            {
                transform.localScale = new Vector3(15, 15);
                transform.position = new Vector3(7.7f, -3.4f);
            }
            if (timeDisparos2 > 4.1)
            {
                dispara2 += Time.deltaTime;
                if (dispara2 < 0.02 && transform.localScale != new Vector3(10, 10))
                {
                    GameObject proyectil = Instantiate(rayo, transform.position, Quaternion.Euler(0, 0, 90));
                    dispara2 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    proyectilRB.velocity = Vector3.left * 8.5f;
                    sizeX -= 0.2f;
                    sizeY -= 0.2f;
                    transform.localScale = new Vector3(sizeX, sizeY);
                }
                if (dispara2 > 0.50 && dispara2 < 0.52 && transform.localScale != new Vector3(10, 10))
                {
                    GameObject proyectil = Instantiate(rayo, transform.position + Vector3.up * 2, Quaternion.Euler(0, 0, 90));
                    dispara2 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    proyectilRB.velocity = Vector3.left * 8.5f;
                    sizeX -= 0.2f;
                    sizeY -= 0.2f;
                    transform.localScale = new Vector3(sizeX, sizeY);
                }
                if (dispara2 > 1 && dispara2 < 1.02 && transform.localScale != new Vector3(10, 10))
                {
                    GameObject proyectil = Instantiate(rayo, transform.position + Vector3.down * 2, Quaternion.Euler(0, 0, 90));
                    dispara2 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    proyectilRB.velocity = Vector3.left * 8.5f;
                    sizeX -= 0.2f;
                    sizeY -= 0.2f;
                    transform.localScale = new Vector3(sizeX, sizeY);
                }
                if (dispara2 > 1.5f)
                {
                    dispara2 = 0;
                }
                if (transform.localScale == new Vector3(10, 10))
                {
                    time2 = 0;
                    timeDisparos1 = -1;
                    dispara1 = 0;
                    estado = 0;
                }
            }
        }
    }
}
