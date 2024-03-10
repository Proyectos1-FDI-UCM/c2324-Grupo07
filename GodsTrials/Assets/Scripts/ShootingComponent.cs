using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    public GameObject hercules;
    public GameObject pez;
    public GameObject bala;
    private bool disparo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hercules = collision.gameObject;
        if(hercules == pez)
        {
            disparo = true;
            pez.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        disparo = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && disparo)
        {
            Instantiate(bala, hercules.transform.position + 0.5f * Vector3.up, Quaternion.identity);
            bala.transform.position += Vector3.right * Time.deltaTime;
        }
    }
}
