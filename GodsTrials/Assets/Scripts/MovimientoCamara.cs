using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public Transform _hercules;
    public Rigidbody2D _hercRb;
    Camera cam;
    private float camSize = 20.0f;
    private float minCamSize = 5.0f;
    private Vector3 camFollow = new Vector3(0.0f, 0.0f, -10.0f);


    private void Start()
    {
        cam = Camera.main;
        cam.orthographicSize = camSize - 1f;
    }
    private void Update()
    {
        //POSITION
        if (_hercules != null)
        {
            if (_hercules.position.x < 86.7)
            {
                camFollow[0] = _hercules.position.x;
                transform.position = camFollow;
            }           
        }

        //CAM ZOOM
        if (_hercules.position.x < 55)
        {
            if (cam.orthographicSize > minCamSize && _hercRb.velocity.x > 0.1f)
            {
                cam.orthographicSize -= 2.5f * Time.deltaTime;
            }
            else if (cam.orthographicSize < camSize && _hercRb.velocity.x < -0.1f)
            {
                cam.orthographicSize += 2.5f * Time.deltaTime;
            }
        }
        else
        {
            cam.orthographicSize = minCamSize;
        }
    }
}
