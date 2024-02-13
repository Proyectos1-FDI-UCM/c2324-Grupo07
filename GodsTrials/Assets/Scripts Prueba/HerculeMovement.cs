using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerculeMovement : MonoBehaviour
{
    public float _vel;
    Rigidbody2D _hercules;
    float _input;
    void Movimiento()
    {
        _input = Input.GetAxis("Horizontal");
        _hercules.velocity = new Vector2(_input * _vel, _hercules.velocity.y);
    }
    void Start()
    {
        _hercules = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movimiento();
    }
}
