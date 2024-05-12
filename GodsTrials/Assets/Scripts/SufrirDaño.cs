using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SufrirDaño : MonoBehaviour
{
    [SerializeField]
    private float vidaEnemiga = 3;
    [SerializeField]
    Animator animator;
    private float time = 2f;
    private float delta;
    



    private void Update()
    {
        //delta += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            //delta = 0;
            vidaEnemiga--;
            Destroy(collision.gameObject);
            if (vidaEnemiga == 0)
            {
                if (gameObject.CompareTag("Ciclope"))
                {
                    animator.SetInteger("ciclope",2);
                
                }
                else if (gameObject.CompareTag("Cupido"))
                {
                    
                    animator.SetInteger("cupido 0", 1);
                }

                Destroy(GetComponent<Enemigos>());
                Destroy(GetComponent<EnemigosCupido>());
                Destroy(gameObject, 2f);
                   // gameObject.SetActive(false);
                
            }
        }
    }
}
