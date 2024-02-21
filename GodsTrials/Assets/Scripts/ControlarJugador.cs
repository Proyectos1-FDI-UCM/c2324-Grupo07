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
    private bool isGrounded;
    private bool doubleJump;
    private Animator animator;
    private float numSaltos = 2.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform != null)
        {
            numSaltos = 2;
        }
        Debug.Log(numSaltos);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numSaltos > 0)
        {
            Saltar();
            numSaltos--;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && !doubleJump)
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
        else if (!Input.anyKey)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void Saltar()
    {
        animator.SetBool("jumping", true);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpvelocity);
    }
}

