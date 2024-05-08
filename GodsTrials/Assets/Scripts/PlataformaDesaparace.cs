using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDesaparace : MonoBehaviour
{
    public GameObject muro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entro "+ collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            muro.SetActive(false);
        }
    }
}
