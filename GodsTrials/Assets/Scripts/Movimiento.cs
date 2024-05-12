using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocity = 5;
    public float jumpvelocity = 10;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float finalvelocity = 0;

        if (Input.GetKey(KeyCode.D))
        {
            finalvelocity = velocity;
        }
        if (Input.GetKey(KeyCode.A))
        {
            finalvelocity = -velocity;
        }
        rb.velocity = new Vector2(finalvelocity, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += new Vector2(0, jumpvelocity);
        }

    }
}

