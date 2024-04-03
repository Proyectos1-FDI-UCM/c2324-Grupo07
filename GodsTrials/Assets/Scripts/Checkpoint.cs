using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Animator m_Animator;

    private void OnTriggerEnter2D(Collider2D collision)    {
        if (collision.GetComponent<ControlarJugador>() != null)
        {
            print("startCheckpoint");
            m_Animator.SetTrigger("startCheckpoint");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }
}