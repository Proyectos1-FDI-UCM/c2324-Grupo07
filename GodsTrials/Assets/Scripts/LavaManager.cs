using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaManager : MonoBehaviour
{
    public GameObject hercules;
    private Vector3 posoriginal;
   

    private void Start()
    {
        posoriginal = hercules.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == hercules)
        {   
            hercules.transform.position = posoriginal;   
        }
    }
}
