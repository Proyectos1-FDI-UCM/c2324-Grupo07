using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInfierno : MonoBehaviour
{
    private ControlarJugador _hercules;
    private void OnTriggerEnter2D(Collider2D cam)
    {
        _hercules = cam.GetComponent<ControlarJugador>();
        float arriba = transform.position.y;
        float reach = transform.position.y + 10f;
        if (_hercules != null)
        {
            float mueve = Mathf.Lerp(arriba, reach, 1.0f);
            transform.position = new Vector3 (0f, mueve, 0f);
        }
        if (cam.CompareTag("Abajo"))
        {
            float move = Mathf.Lerp(arriba, -reach, 1.0f);
            transform.position = new Vector3(0f, move, 0f);
        }
    }
}
