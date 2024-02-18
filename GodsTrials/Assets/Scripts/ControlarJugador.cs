using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;

public class ControlarJugador : MonoBehaviour
{
    public float jumpvelocity = 10;
    public float velocity = 5;
    public Transform marcadorSuelo;
    private float MarcadorSuelo;
    public LayerMask Suelo;
    private bool isGrounded;
    private bool doubleJump;
    private Animator animator;

 
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
       
        isGrounded = Physics2D.OverlapCircle(marcadorSuelo.position, MarcadorSuelo, Suelo);
    }
    void Update()
    {
      
        if (isGrounded)
        {
            doubleJump = false;
            animator.SetBool("jumping", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Saltar();
            
        }
    
        
        if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !isGrounded)
        {
            Saltar();
            doubleJump = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-velocity, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void Saltar()
    {
        animator.SetBool("jumping", true);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpvelocity);
    }
}

