using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private CharacterController characterController;
    private Animator anim;
    private Transform _myTransform;

    void Start()
    {
        // Obtén el componente CharacterController y Animator del objeto
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        if (characterController == null || anim == null)
        {
            Debug.LogError("Se requieren los componentes CharacterController y Animator en este objeto.");
        }
    }

    void Update()
    {
        // Obtén la velocidad actual del CharacterController
        Vector3 velocidad = characterController.velocity;

        // Verifica la dirección del movimiento
        if (velocidad.x >= 0.1f) // Movimiento hacia la derecha
        {
            anim.SetInteger("AnimState", 1);
        }
        else if (velocidad.x <= -0.1f) // Movimiento hacia la izquierda
        {
            anim.SetInteger("AnimState", 1);
        }
        else if (!Input.anyKey)
        {
            anim.SetInteger("AnimState", 0); // Puedes cambiar "Idle" por el nombre de tu animación de inactividad
        }
    }
}
