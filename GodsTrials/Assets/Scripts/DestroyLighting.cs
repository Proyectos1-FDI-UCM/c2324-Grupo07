using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLighting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("perimetro"))
        {
            Destroy(this.gameObject);
        }
    }
}
