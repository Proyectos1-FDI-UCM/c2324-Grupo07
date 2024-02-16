using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public Transform _hercules;
    private void Start()
    {
        _hercules = transform;
    }
    private void Update()
    {
        if (_hercules != null)
        {
            transform.position = new Vector3(_hercules.position.x, 0, -10);
        }
    }
}
