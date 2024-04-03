using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeus : MonoBehaviour
{
    private float time;
    float randomX;
    float randomY;
    [SerializeField]
    private float vel = 2f;
    private Rigidbody2D zeusRB;
    private bool changeVel = false;
    private Vector3 randomVelocity;
    public LayerMask suelo;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        zeusRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time < 2f)
        {
            zeusRB.velocity = Vector3.up * vel;
            transform.localScale += new Vector3(0.05f, 0.05f);
        }
        if(time > 2f && time < 4f)
        {
            zeusRB.velocity = Vector3.down * vel;
            transform.localScale -= new Vector3(0.05f, 0.05f);
        }
        if (time > 4f && time < 4.1f)
        {
            randomX = Random.Range(-1f, 1f) * 5f;
            randomY = Random.Range(-1f, 1f) * 5f;
            randomVelocity = new Vector3(randomX, randomY);
            changeVel = true;
        }
        if (changeVel)
        {
            if (transform.position.y > -3.2 && transform.position.y < 2.8 && transform.position.x < 8.75 && transform.position.x > -9.15)
            {
                zeusRB.velocity = randomVelocity;
                if (time > 6f)
                {
                    changeVel = false;
                    time = 4f;
                }
            }
        }
        if(transform.position.y < -3.2)
        {
            zeusRB.velocity = new Vector3(randomX, 5);
            changeVel = false;
            if(time > 6f)
            {
                time = 4f;
            }
        }
        else if(transform.position.y > 2.8)
        {
            zeusRB.velocity = new Vector3(randomX, -5);
            changeVel = false;
            if (time > 6f)
            {
                time = 4f;
            }
        }
        if (transform.position.x > 8.75)
        {
            zeusRB.velocity = new Vector3(-5, randomY);
            changeVel = false;
            if (time > 6f)
            {
                time = 4f;
            }
        }
        else if(transform.position.x < -9.15)
        {
            zeusRB.velocity = new Vector3(5, randomY);
            changeVel = false;
            if (time > 6f)
            {
                time = 4f;
            }
        }
    }
}
