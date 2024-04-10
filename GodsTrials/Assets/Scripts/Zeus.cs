using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zeus : MonoBehaviour
{
    Vector3 direccion;
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
    [SerializeField]
    private GameObject marcadorSuelo;
    [SerializeField]
    private GameObject stun;
    private GameObject marcSuelo;
    private GameObject stunSuelo;
    private Rigidbody2D proyectilRB;
    public GameObject hercules;
    float dispara1;
    float dispara2;
    float dispara3;
    float sizeX = 15;
    float sizeY = 15;
    [SerializeField]
    float vidaZ = 50f;
    bool pos = false;
    Vector3 marca = Vector3.zero;
    Vector3 ataca = Vector3.zero;
    float caeRayo = 0;
    bool instancia = true;
    bool instancia1 = true;
    bool instancia2 = true;
    bool instancia3 = true;
    bool instancia4 = true;
    bool state4 = false;
    bool simultaneo = false;
    private GameObject marc;
    private GameObject ray;
    [SerializeField]
    private float si;
    Quaternion rotationZ;
    public void VidaZeus()
    {
        vidaZ--;
        if (vidaZ == 0)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        direccion = hercules.transform.position - rayo.transform.position;
        si = hercules.transform.position.x - transform.position.x;
        time1 = 0;
        time2 = 0;
        dispara1 = 0;
        dispara2 = 0;
        dispara3 = 0;
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
        if (estado == 2 && !simultaneo)
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
        if (estado == 0 && !simultaneo)
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
                if (dispara1 < 0.04 && instancia)
                {
                    Vector3 direc = (hercules.transform.position - transform.position);
                    float anguloZ = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
                    rotationZ = Quaternion.Euler(new Vector3(0, 0, anguloZ));
                    GameObject proyectil = Instantiate(rayo, transform.position, rotationZ);
                    dispara1 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    float mod = Mathf.Sqrt(direc.x * direc.x + direc.y * direc.y);
                    proyectilRB.velocity = (direc / mod) * 12;
                    instancia = false;
                }
                //Tiempo entre disparos
                if (dispara1 > 1.25f)
                {
                    instancia = true;
                    dispara1 = 0;
                }
            }
            //Cambio de estados e inicializacion de los tiempos del nuevo estado para que al hacer el bucle funcione
            if (timeDisparos1 > 10)
            {
                instancia = true;
                instancia1 = true;
                instancia2 = true;
                timeDisparos2 = 0;
                dispara2 = 0;
                estado = 1;
                sizeX = 15;
                sizeY = 15;
            }
        }
        //Segundo estado
        if (estado == 1 && !simultaneo)
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
                if (dispara2 < 0.04 && transform.localScale != new Vector3(10, 10) && instancia)
                {
                    GameObject proyectil = Instantiate(rayo, transform.position, Quaternion.Euler(0, 0, 90));
                    dispara2 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    proyectilRB.velocity = Vector3.left * 8.5f;
                    sizeX -= 0.2f;
                    sizeY -= 0.2f;
                    transform.localScale = new Vector3(sizeX, sizeY);
                    instancia = false;
                }
                //Disparo arriba
                if (dispara2 > 0.50 && dispara2 < 0.54 && transform.localScale != new Vector3(10, 10) && instancia1)
                {
                    GameObject proyectil = Instantiate(rayo, transform.position + Vector3.up * 2, Quaternion.Euler(0, 0, 90));
                    dispara2 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    proyectilRB.velocity = Vector3.left * 8.5f;
                    sizeX -= 0.2f;
                    sizeY -= 0.2f;
                    transform.localScale = new Vector3(sizeX, sizeY);
                    instancia1 = false;
                }
                //Disparo abajo
                if (dispara2 > 1 && dispara2 < 1.04 && transform.localScale != new Vector3(10, 10) && instancia2)
                {
                    GameObject proyectil = Instantiate(rayo, transform.position + Vector3.down * 2, Quaternion.Euler(0, 0, 90));
                    dispara2 += 0.01f;
                    proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                    proyectilRB.velocity = Vector3.left * 8.5f;
                    sizeX -= 0.2f;
                    sizeY -= 0.2f;
                    transform.localScale = new Vector3(sizeX, sizeY);
                    instancia2 = false;
                }
                //Tiempo entre disparos
                if (dispara2 > 1.5f)
                {
                    instancia = true;
                    instancia1 = true;
                    instancia2 = true;
                    dispara2 = 0;
                }
                //Cambia a la fase anterior e inicializa las variables de la fase para que comience desde el principio
                //creando bucle infinito
                if (transform.localScale == new Vector3(10, 10))
                {
                    instancia = true;
                    time2 = 0;
                    timeDisparos1 = -1;
                    dispara1 = 0;
                    estado = 0;
                }
            }
        }
        if (vidaZ <= 40 && vidaZ > 15 && estado != 3 && !state4)
        {
            instancia = true;
            instancia1 = true;
            instancia2 = true;
            time2 = 0;
            timeDisparos1 = 0;
            dispara1 = 0;
            dispara2 = 0;
            estado = 3;
        }
        if (estado == 3 || estado == 5)
        {
            time2 += Time.deltaTime;
            if (time2 < 1f && !simultaneo)
            {
                zeusRB.velocity = new Vector3(Random.Range(4, -5), Random.Range(4, -5));
            }
            if (time2 > 1f)
            {
                zeusRB.velocity = new Vector3(0, 0);
                timeDisparos1 += Time.deltaTime;
                dispara1 += Time.deltaTime;
                dispara2 += Time.deltaTime;
                if (timeDisparos1 > 0 && timeDisparos1 < 9)
                {
                    if (dispara1 < 0.1 && !pos)
                    {
                        caeRayo = Random.Range(-10f, 10f);
                        marca = new Vector3(caeRayo, -6.3f, 0);
                        ataca = new Vector3(caeRayo, 0, 0);
                        pos = true;
                    }
                    if (pos)
                    {
                        if (dispara1 > 0.1 && dispara1 < 0.2 && instancia)
                        {
                            marc = Instantiate(marcador, marca, Quaternion.identity);
                            instancia = false;
                        }
                        if (dispara1 > 0.6 && dispara1 < 0.8f && instancia1)
                        {
                            ray = Instantiate(rayoCielo, ataca, Quaternion.identity);
                            instancia1 = false;
                        }
                        if (dispara1 > 1)
                        {
                            Destroy(ray);
                            Destroy(marc);
                        }
                        if (dispara1 > 1.5f)
                        {
                            pos = false;
                            instancia = true;
                            instancia1 = true;
                            dispara1 = 0;
                        }
                        if (dispara2 < 0.1 && instancia2)
                        {
                            Vector3 direc = (hercules.transform.position - transform.position);
                            float anguloZ = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
                            rotationZ = Quaternion.Euler(new Vector3(0, 0, anguloZ));
                            GameObject proyectil = Instantiate(rayo, transform.position, rotationZ);
                            proyectilRB = proyectil.GetComponent<Rigidbody2D>();
                            float mod = Mathf.Sqrt(direc.x * direc.x + direc.y * direc.y);
                            proyectilRB.velocity = (direc / mod) * 10;
                            instancia2 = false;
                        }
                        //Tiempo entre disparos
                        if (dispara2 > 1f)
                        {
                            instancia2 = true;
                            dispara2 = 0;
                        }
                    }
                }
                if (timeDisparos1 > 9)
                {
                    if (simultaneo)
                    {
                        instancia = true;
                        instancia1 = true;
                        instancia2 = true;
                        time2 = 0;
                        timeDisparos1 = 0;
                        dispara1 = 0;
                        dispara2 = 0;
                        estado = 5;
                    }
                    if (!simultaneo)
                    {
                        timeDisparos2 = 0;
                        time1 = 0;
                        dispara3 = 0;
                        instancia3 = true;
                        instancia4 = true;
                        estado = 4;
                    }
                }
            }
        }
        if (estado == 4 || estado == 5)
        {
            state4 = true;
            time1 += Time.deltaTime;
            if (time1 < 1)
            {
                transform.position = new Vector3(8, -3.4f, 0);
            }
            if (time1 > 1)
            {
                timeDisparos2 += Time.deltaTime;
                dispara3 += Time.deltaTime;
                if (timeDisparos2 > 0 && timeDisparos2 < 10)
                {
                    if (dispara3 < 0.1 && instancia3)
                    {
                        marcSuelo = Instantiate(marcadorSuelo, new Vector3(0, -5.5f, 0), Quaternion.identity);
                        instancia3 = false;
                    }
                    if (dispara3 > 0.3 && dispara3 < 0.4)
                    {
                        Destroy(marcSuelo);
                    }
                    if (dispara3 > 0.6 && dispara3 < 0.7 && !instancia3)
                    {
                        marcSuelo = Instantiate(marcadorSuelo, new Vector3(0, -5.5f, 0), Quaternion.identity);
                        instancia3 = true;
                    }
                    if (dispara3 > 0.9 && dispara3 < 1)
                    {
                        Destroy(marcSuelo);
                    }
                    if (dispara3 > 1.2 && dispara3 < 1.3 && instancia4)
                    {
                        marcSuelo = Instantiate(marcadorSuelo, new Vector3(0, -5.5f, 0), Quaternion.identity);
                        instancia4 = false;
                    }
                    if (dispara3 > 1.5 && dispara3 < 1.6)
                    {
                        Destroy(marcSuelo);
                    }
                    if (dispara3 > 2 && dispara3 < 2.1 && !instancia4)
                    {
                        stunSuelo = Instantiate(stun, new Vector3(0, -5.5f, 0), Quaternion.identity);
                        instancia4 = true;
                    }
                    if (dispara3 > 2.5 && dispara3 < 2.6)
                    {
                        Destroy(stunSuelo);
                    }
                    if (dispara3 > 3.5)
                    {
                        dispara3 = 0;
                    }
                }
                if (timeDisparos2 > 10)
                {
                    if (simultaneo)
                    {
                        time1 = 0;
                        dispara3 = 0;
                        timeDisparos2 = 0;
                        instancia3 = true;
                        instancia4 = true;
                        estado = 5;
                    }
                    if (!simultaneo)
                    {
                        instancia = true;
                        instancia1 = true;
                        instancia2 = true;
                        time2 = 0;
                        timeDisparos1 = 0;
                        dispara1 = 0;
                        dispara2 = 0;
                        estado = 3;
                    }
                }
            }
            if (vidaZ <= 15 && estado != 5)
            {
                Destroy(marc);
                Destroy(ray);
                Destroy(marcSuelo);
                Destroy(stunSuelo);
                instancia = true;
                instancia1 = true;
                instancia2 = true;
                time2 = 0;
                timeDisparos1 = 0;
                dispara1 = 0;
                dispara2 = 0;
                timeDisparos2 = 0;
                time1 = 0;
                dispara3 = 0;
                instancia3 = true;
                instancia4 = true;
                simultaneo = true;
                estado = 5;
            }
        }
        if (hercules.transform.position.x - transform.position.x > 0)
        {
            transform.rotation = Quaternion.identity;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
