using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaSystem : MonoBehaviour
{
    public GameObject hercules;
    public GameObject lavaHueco;
    public GameObject pinchosA;
    public GameObject pinchosI;
    public GameObject pinchosD;
    public GameObject bolaFuego1;
    public GameObject bolaFuego2;
    public float vida = 3.0f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        hercules = other.gameObject;
        if (hercules == lavaHueco)
        {
            if (SceneManager.GetActiveScene().name == "Cueva" )
            {
                SceneManager.LoadScene(1);
            }
            else if (SceneManager.GetActiveScene().name == "Infierno")
            {
                SceneManager.LoadScene(2);            
            }
        }
        else if(hercules == pinchosA)
        {
            vida--;
            if(vida == 0)
            {
                SceneManager.LoadScene(2);
            }
            Debug.Log(vida);
        }
        else if (hercules == pinchosD)
        {
            vida--;
            if (vida == 0)
            {
                SceneManager.LoadScene(2);
            }
            Debug.Log(vida);
        }
        else if (hercules == pinchosI)
        {
            vida--;
            if (vida == 0)
            {
                SceneManager.LoadScene(2);
            }
            Debug.Log(vida);
        }
        else if(hercules == bolaFuego1)
        {
            vida--;
            if (vida == 0)
            {
                SceneManager.LoadScene(2);
            }
            Debug.Log(vida);
        }
        else if (hercules == bolaFuego2)
        {
            vida--;
            if (vida == 0)
            {
                SceneManager.LoadScene(2);
            }
            Debug.Log(vida);
        }
    }
}