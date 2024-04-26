using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigopiedra : MonoBehaviour
{
    #region parametros
    private Transform _mytransform;
    private Vector3 _position;
    private float primerapos;
    private bool derecha = true;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _mytransform = transform;
        _position = new Vector3(1, 0, 0);
        primerapos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (derecha)
        {
            if(primerapos - transform.position.x < -3)
            {
                derecha = false;
            }
            transform.position += _position * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (!derecha)
        {
            if(primerapos - transform.position.x > 3)
            {
                derecha = true;
            }
            transform.position += (Vector3.left) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
