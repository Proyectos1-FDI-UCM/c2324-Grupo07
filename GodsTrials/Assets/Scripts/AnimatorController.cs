using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    #region parametros
    private Transform player;
    Animator animator;
    private Rigidbody2D rb;
    private bool enSuelo1;
    private bool enSuelo2;
    public LayerMask capaSuelo;
    public Transform _circuloPies;
    public Transform _circuloPies2;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        player = transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enSuelo1 = (Physics2D.Raycast(_circuloPies.position, Vector3.down, 0.5f,capaSuelo));
        enSuelo2 = (Physics2D.Raycast(_circuloPies2.position, Vector3.down, 0.5f,capaSuelo));
        if (!enSuelo1 && !enSuelo2 && rb.velocity.x > 0.1f || !enSuelo1  && rb.velocity.x < -0.1f && !enSuelo2)
        {
            animator.SetInteger("AnimState", 2); //jump
        }
        else if(!enSuelo1 && rb.velocity.x == 0 && !enSuelo2)
        {
            animator.SetInteger("AnimState", 3); //jump parado
        }
        else
        {
            if (rb.velocity.x > 0.1f || rb.velocity.x > 0.1f && enSuelo1 || !enSuelo2 && rb.velocity.x > 0.1f)
            {
                animator.SetInteger("AnimState", 1); //run derecha
                if (player.rotation == Quaternion.Euler(0, 180, 0))
                {
                    player.rotation = Quaternion.identity;                    
                }
                else
                {
                    animator.SetInteger("AnimState", 1); //run derecha
                    player.rotation = Quaternion.identity;
                }
            }
            else if (rb.velocity.x < -0.1f || rb.velocity.x < -0.1f && enSuelo1 || rb.velocity.x < -0.1f && enSuelo2)
            {
                animator.SetInteger("AnimState", 1); //run izquierda
                player.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (enSuelo1 && rb.velocity.x == 0 || enSuelo2 && rb.velocity.x == 0)
            {
                animator.SetInteger("AnimState", 0); //idle
            }
        }
    }
    public void Dano()
    {
        Debug.Log("entra");
        animator.SetTrigger("AnimTrigger");//dano
    }
}
