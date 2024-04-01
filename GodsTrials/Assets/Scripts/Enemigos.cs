using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    #region parametros
    [SerializeField]
    private GameObject hercules;
    private Transform _mytransform;
    Animator _animator;
    float tiemporep = 3f;
    float tiempo;
    [SerializeField]
    public GameObject bola;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        tiempo = 0;
        _mytransform = transform;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        float disty = Mathf.Abs(transform.position.y - hercules.transform.position.y);
        tiempo += Time.deltaTime; 
        //float distx = Mathf.Abs(transform.position.x - hercules.transform.position.x);
        if (disty <= 10)
        {
            if (tiempo > tiemporep)
            {
                _animator.Play("lazapiedra");
                Instantiate(bola, transform.position + Vector3.up, Quaternion.identity);
                //Shoot();
                tiempo = 0;

            }
                bola.transform.position +=( new Vector3(1,0,0))*Time.deltaTime;

        }
    }
}
