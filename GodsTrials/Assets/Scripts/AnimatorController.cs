using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    #region parametros
    private Transform player;
    Animator animator;
    private Rigidbody2D rb; 
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

        if (rb.velocity.y > 0.1f && rb.velocity.x > 0.1f || rb.velocity.y > 0.1f && rb.velocity.x < -0.1f)
        {
            animator.SetInteger("AnimState", 2); //jump
        }
        else if(rb.velocity.y > 0.1f && rb.velocity.x == 0)
        {
            animator.SetInteger("AnimState", 3); //jump parado
        }
        else
        {
            if (rb.velocity.x > 0.1f || rb.velocity.x > 0.1f && rb.velocity.y > 0.1f)
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
            else if (rb.velocity.x < -0.1f || rb.velocity.x < -0.1f && rb.velocity.y > 0.1f)
            {
                animator.SetInteger("AnimState", 1); //run izquierda
                player.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (rb.velocity.y == 0 && rb.velocity.x == 0)
            {
                animator.SetInteger("AnimState", 0); //idle
            }
        }
    }
}
