using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Movimiento movement;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            movement.Horizontal(-1);
            movement.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.Horizontal(1);
            movement.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            movement.Horizontal(0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            movement.Salto();
        }
    }
}
