using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    #region parametros
    Animator animator;
    private Rigidbody2D rb;
    private bool enSuelo1;
    private bool enSuelo2;
    private bool enSuelo3;
    public LayerMask capaSuelo;
    public Transform _circuloPies;
    public Transform _circuloPies2;
    public Transform _circuloPies1;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enSuelo1 = (Physics2D.Raycast(_circuloPies.position, Vector3.down, 0.5f,capaSuelo));//raycasts para ver cuando toca el suelo hercules
        enSuelo2 = (Physics2D.Raycast(_circuloPies2.position, Vector3.down, 0.5f,capaSuelo));
        enSuelo3 = (Physics2D.Raycast(_circuloPies1.position, Vector3.down, 0.5f,capaSuelo));
        if (!enSuelo1 && !enSuelo2 && !enSuelo3 && rb.velocity.x > 0.1f || !enSuelo1 && !enSuelo3 && rb.velocity.x < -0.1f && !enSuelo2)
        {
            animator.SetInteger("AnimState", 2); //jump
        }
        else if(!enSuelo1 && rb.velocity.x < 0.1f && rb.velocity.x > -0.1f && !enSuelo2 && !enSuelo3)
        {
            animator.SetInteger("AnimState", 3); //jump parado
        }
        else
        {
            if (rb.velocity.x > 0.1f && enSuelo3 || rb.velocity.x > 0.1f && enSuelo1 || enSuelo2 && rb.velocity.x > 0.1f)
            {
                animator.SetInteger("AnimState", 1); //run derecha
            }
            else if (rb.velocity.x < -0.1f && enSuelo3 || rb.velocity.x < -0.1f && enSuelo1 || rb.velocity.x < -0.1f && enSuelo2)
            {
                animator.SetInteger("AnimState", 1); //run izquierda
            }
            else if (enSuelo1 && rb.velocity.x < 0.1f && rb.velocity.x > -0.1f || enSuelo2 && rb.velocity.x < 0.1f && rb.velocity.x > -0.1f || enSuelo3 && rb.velocity.x < 0.1f && rb.velocity.x > -0.1f)
            {
                animator.SetInteger("AnimState", 0); //idle
            }
        }
    }
    public void Dano()//animacion de daño
    {
        
        animator.SetTrigger("AnimTrigger");//dano
    }
}
