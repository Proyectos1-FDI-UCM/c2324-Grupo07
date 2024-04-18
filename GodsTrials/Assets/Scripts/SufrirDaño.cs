using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SufrirDaño : MonoBehaviour
{
    [SerializeField]
    private float vidaEnemiga = 3;
    [SerializeField]
    Animator animator;
    private float time=2f;
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
                Debug.Log("entra");
                }
                else if (gameObject.CompareTag("Cupido"))
                {

                }

                Destroy(GetComponent<Enemigos>());
                Destroy(gameObject, 2f);
                   // gameObject.SetActive(false);
                
            }
        }
    }
}
