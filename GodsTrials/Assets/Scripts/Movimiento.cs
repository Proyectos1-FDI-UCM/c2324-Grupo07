using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField]
    private float _velocidad = 0.2f;
    [SerializeField]
    private float _salto = 5.0f;
    [SerializeField]
    private float _gravity = -5.0f;
    private CharacterController characterController;
    private Transform _personaje;
    private float _horizontal;
    private Vector3 _direccion;
    private float _velSalto;
    public void Horizontal(float x)
    {
        _horizontal = x;
    }
    public void Salto()
    {
        if (characterController.isGrounded)
        {
            _velSalto = _salto;
        }
    }
    void Start()
    {
        _personaje = transform;
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        _direccion = new Vector3(_horizontal, 0, 0);
        _direccion.Normalize();
        _velSalto += Physics.gravity.y * Time.deltaTime;
        _velSalto = Mathf.Clamp(_velSalto, _gravity, _salto);
        characterController.Move((_direccion * _velocidad + Vector3.up * _velSalto) * Time.deltaTime);
        _personaje.position += _direccion * _velocidad;
    }
}
