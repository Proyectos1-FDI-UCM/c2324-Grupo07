using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SufrirDaño : MonoBehaviour
{
    [SerializeField]
    private float vidaEnemiga = 3;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            vidaEnemiga--;
            Destroy(collision.gameObject);
            if (vidaEnemiga == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
