using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPruebas : MonoBehaviour
{
    [SerializeField]
    private GameObject _hercules;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_hercules.transform.position.x, _hercules.transform.position.y, transform.position.z);
    }
}
