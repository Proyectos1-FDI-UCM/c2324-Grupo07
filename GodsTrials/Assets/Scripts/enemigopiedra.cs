using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

public class enemigopiedra : MonoBehaviour
{
    #region parametros
    private Transform _mytransform;
    private Vector3 _position;
    private float primerapos;
    private bool derecha = true;
    private bool dano;
    private bool movimiento = true;
    private bool danoherculesderch;
    private bool danoherculesizq;
    [SerializeField]
    private float drch = 3;
    [SerializeField]
    private float izqu = -3;
    [SerializeField]
    LayerMask hercules;
    Animator animator;
    [SerializeField]
    private VidaSystem vidaSystem;
    [SerializeField]
    private GameObject camara;
    //Sonido
    [SerializeField]
    private AudioSource audio;
    private bool play = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _mytransform = transform;
        _position = new Vector3(1, 0, 0);
        primerapos = transform.position.x;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float camdist = Mathf.Abs(transform.position.x - camara.transform.position.x);
        float camdisty = Mathf.Abs(transform.position.y - camara.transform.position.y);
     
        if (camdist <= 8 && !play && camdisty<=5)
        {
            audio.Play();
            play = true;
        }
        else if(camdist >= 8)
        {
            audio.Stop();
            play = false;
        }
        

        if (movimiento)
        {

            if (derecha)
            {
                if (primerapos - transform.position.x < izqu)
                {
                    derecha = false;
                }
                transform.position += _position * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (!derecha)
            {
                if (primerapos - transform.position.x > drch)
                {
                    derecha = true;
                }
                transform.position += (Vector3.left) * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        dano = Physics2D.Raycast(transform.position, Vector3.up, 0.5f, hercules);
        danoherculesderch = Physics2D.Raycast(transform.position, Vector3.right, 1.1f, hercules);
        danoherculesizq = Physics2D.Raycast(transform.position, Vector3.left, 1f, hercules);

        if (dano)
        {
            movimiento = false;
            vidaSystem.ImpulsoPorDaño();
            animator.SetInteger("enemigopiedra", 1);
            audio.Stop();
            Destroy(audio);
            Destroy(gameObject, 1.5f);
        }

        if (danoherculesderch || danoherculesizq)
        {
            Debug.Log("Entra");
            vidaSystem.ImpulsoPorDaño();
            vidaSystem.DanoPiedra();
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * 1f);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * 1.2f);
    }
}
