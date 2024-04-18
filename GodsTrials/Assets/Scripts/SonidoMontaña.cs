using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoMontaña : MonoBehaviour
{
    #region parameters
    public AudioSource audiosource;
    public AudioClip roca;
    Animator animator;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RocaRota()
    {
        audiosource.PlayOneShot(roca);
        
    }
}
