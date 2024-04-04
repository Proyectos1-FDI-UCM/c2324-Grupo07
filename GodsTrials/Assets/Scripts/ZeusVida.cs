using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeusVida : MonoBehaviour
{
    private Zeus zeus;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        zeus = GetComponent<Zeus>();
        if (collision.gameObject.CompareTag("bala"))
        {
            zeus.VidaZeus();
            Destroy(collision.gameObject);
        }
    }
}
