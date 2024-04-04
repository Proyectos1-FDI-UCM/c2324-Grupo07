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
    [SerializeField]
    private GameObject rayoCielo;
    [SerializeField]
    private GameObject marcador;
    private Rigidbody2D proyectilRB;
    public GameObject hercules;
    float dispara1;
    float dispara2;
    float sizeX = 15;
    float sizeY = 15;
    [SerializeField]
    float vidaZ = 50f;
    bool pos = false;
    Vector3 marca = Vector3.zero;
    Vector3 ataca = Vector3.zero;
    float caeRayo = 0;
    public void VidaZeus()
    {
        vidaZ--;
        if(vidaZ == 0)
        {
            Destroy(gameObject);
        }
    }
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
        pos = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Inicio de primera fase, solo se hara al iniciar la escena
        if (estado == 2)
        {
            time1 += Time.deltaTime;
            //Sube y se agranda
            if (time1 < 2f)
            {
                zeusRB.velocity = Vector3.up * vel;
                transform.localScale += new Vector3(4f, 4f) * Time.deltaTime;
            }
            //Baja y disminuye
            if (time1 > 2f && time1 < 4f)
            {
                zeusRB.velocity = Vector3.down * vel;
                transform.localScale -= new Vector3(4f, 4f) * Time.deltaTime;
                //Cambia al siguiente estado
                if (time1 > 3.9f)
                {
                    estado = 0;
                }
            }
        }
        if (estado == 0)
        {
            //Contadores 
            time2 += Time.deltaTime;
            timeDisparos1 += Time.deltaTime;
            dispara1 += Time.deltaTime;
            //Crea un solo vector aleatorio (por la limitacion de tiempo) para darle movimiento al zeus 
            if (time2 > 0f && time2 < 0.1f)
            {
                randomX = Random.Range(-1f, 1f) * 5f;
                randomY = Random.Range(-1f, 1f) * 5f;
                randomVelocity = new Vector3(randomX, randomY);
                changeVel = true;
            }
            //Movimiento zeus
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
            //Limite pantalla
            if (transform.position.y < -3.2)
            {
                zeusRB.velocity = new Vector3(randomX, 5);
                changeVel = false;
                if (time2 > 2f)
                {
                    time2 = 0f;
                }
            }
            //Limite pantalla
            else if (transform.position.y > 2.8)
            {
                zeusRB.velocity = new Vector3(randomX, -5);
                changeVel = false;
                if (time2 > 2f)
                {
                    time2 = 0f;
                }
            }
            //Limite pantalla
            if (transform.position.x > 8.75)
            {
                zeusRB.velocity = new Vector3(-5, randomY);
                changeVel = false;
                if (time2 > 2f)
                {
                    time2 = 0f;
                }
            }
            //Limite pantalla
            else if (transform.position.x < -9.15)
            {
                zeusRB.velocity = new Vector3(5, randomY);
                changeVel = false;
                if (time2 > 2f)
                {
                    time2 = 0f;
                }
            }
            //Disparos Zeus
            if (timeDisparos1 < 10 && timeDisparos1 > 0)
            {
                //Direccion disparos
                if (dispara1 < 0.04)
                {
                    Vector3 direc = (hercules.transform.position - transform.position);
                    GameObject proyectil = Instantiate(rayo, transform.position, Quaternion.identity);
                    dispara1 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    float mod = Mathf.Sqrt(direc.x * direc.x + direc.y * direc.y);
                    proyectilRB.velocity = (direc / mod) * 12;
                }
                //Tiempo entre disparos
                if (dispara1 > 1.25f)
                {
                    dispara1 = 0;
                }
            }
            //Cambio de estados e inicializacion de los tiempos del nuevo estado para que al hacer el bucle funcione
            if (timeDisparos1 > 10)
            {
                timeDisparos2 = 0;
                dispara2 = 0;
                estado = 1;
                sizeX = 15;
                sizeY = 15;
            }
        }
        //Segundo estado
        if (estado == 1)
        {
            timeDisparos2 += Time.deltaTime;
            //Crece
            if (timeDisparos2 < 4)
            {
                zeusRB.velocity = Vector3.zero;
                transform.localScale += new Vector3(1.5f, 1.5f) * Time.deltaTime;
            }
            //Cambia de posicion
            if (timeDisparos2 > 4 && timeDisparos2 < 4.1)
            {
                transform.localScale = new Vector3(15, 15);
                transform.position = new Vector3(7.7f, -3.4f);
            }
            //Dispara
            if (timeDisparos2 > 4.1)
            {
                dispara2 += Time.deltaTime;
                //Disparo medio
                if (dispara2 < 0.04 && transform.localScale != new Vector3(10, 10))
                {
                    GameObject proyectil = Instantiate(rayo, transform.position, Quaternion.Euler(0, 0, 90));
                    dispara2 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    proyectilRB.velocity = Vector3.left * 8.5f;
                    sizeX -= 0.2f;
                    sizeY -= 0.2f;
                    transform.localScale = new Vector3(sizeX, sizeY);
                }
                //Disparo arriba
                if (dispara2 > 0.50 && dispara2 < 0.54 && transform.localScale != new Vector3(10, 10))
                {
                    GameObject proyectil = Instantiate(rayo, transform.position + Vector3.up * 2, Quaternion.Euler(0, 0, 90));
                    dispara2 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    proyectilRB.velocity = Vector3.left * 8.5f;
                    sizeX -= 0.2f;
                    sizeY -= 0.2f;
                    transform.localScale = new Vector3(sizeX, sizeY);
                }
                //Disparo abajo
                if (dispara2 > 1 && dispara2 < 1.04 && transform.localScale != new Vector3(10, 10))
                {
                    GameObject proyectil = Instantiate(rayo, transform.position + Vector3.down * 2, Quaternion.Euler(0, 0, 90));
                    dispara2 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    proyectilRB.velocity = Vector3.left * 8.5f;
                    sizeX -= 0.2f;
                    sizeY -= 0.2f;
                    transform.localScale = new Vector3(sizeX, sizeY);
                }
                //Tiempo entre disparos
                if (dispara2 > 1.5f)
                {
                    dispara2 = 0;
                }
                //Cambia a la fase anterior e inicializa las variables de la fase para que comience desde el principio
                //creando bucle infinito
                if (transform.localScale == new Vector3(10, 10))
                {
                    time2 = 0;
                    timeDisparos1 = -1;
                    dispara1 = 0;
                    estado = 0;
                }
            }
        }
        if (vidaZ <= 35 && vidaZ > 20 && estado != 3)
        {
            time2 = 0;
            timeDisparos1 = 0;
            dispara1 = 0;
            estado = 3;
        }
        if (estado == 3)
        {
            time2 += Time.deltaTime;
            if (time2 < 3f)
            {
                zeusRB.velocity = new Vector3(Random.Range(4, -5), Random.Range(4, -5));
            }
            if (time2 > 3f)
            {
                zeusRB.velocity = new Vector3(0, 0);
                timeDisparos1 += Time.deltaTime;
                dispara1 += Time.deltaTime;
                if (timeDisparos1 > 0 && timeDisparos1 < 9)
                {
                    if(dispara1 < 0.04 && !pos)
                    {
                        Debug.Log(dispara1);
                        caeRayo = Random.Range(-10.7f, 4.1f);
                        marca = new Vector3(caeRayo, -6.3f, 0);
                        ataca = new Vector3(caeRayo, 0, 0);
                        pos = true;
                    }
                    if (pos)
                    {
                        Debug.Log(dispara1);
                        if (dispara1 > 0.04 && dispara1 < 0.09)
                        {
                            Instantiate(marcador, marca, Quaternion.identity);
                            dispara1 += 0.01f;
                        }
                        if (dispara1 > 0.75 && dispara1 < 0.8f)
                        {
                            Instantiate(rayoCielo, ataca, Quaternion.identity);
                            dispara1 += 0.01f;
                        }
                        if (dispara1 > 1.5f)
                        {
                            pos = false;
                            dispara1 = 0;
                        }
                    }
                }
            }
        }
    }
}
