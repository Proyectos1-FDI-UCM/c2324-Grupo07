using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDeSalto : MonoBehaviour
{
    public float force = 5;
    public Vector2 direccion = Vector2.up;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.contacts[0].point);
        Vector3 colldirection = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y) - collision.gameObject.transform.position;
        
        Debug.Log(colldirection);
        float angle = Vector3.Angle(collision.gameObject.transform.up, colldirection.normalized);
        Debug.Log(angle);
        if (collision.gameObject.layer == 9 && angle > 130 && angle < 230)
        {
            Debug.Log("Entro");
            collision.gameObject.GetComponent<Rigidbody2D>().velocity += direccion*force;
            
        }
    }

}
//collision.contacts[0].point.y < collision.gameObject.transform.position.y