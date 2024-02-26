using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaManager : MonoBehaviour
{
    public GameObject hercules;
    private Vector3 posicionInicial;
    private void Start()
    {
        posicionInicial = hercules.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == hercules)
        {
            if (SceneManager.GetActiveScene().name == "Cueva" )
            {
                SceneManager.LoadScene(1);
            }
            else if (SceneManager.GetActiveScene().name == "Infierno")
            {
                SceneManager.LoadScene(2);            }
        }
    }
}