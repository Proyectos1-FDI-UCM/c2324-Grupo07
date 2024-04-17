using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoFinal : MonoBehaviour
{
    [SerializeField]
    AudioSource audio;
    [SerializeField]
    AudioClip musicaBatalla;
    private float time;
    private bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 4 && isPlaying)
        {
            audio.PlayOneShot(musicaBatalla);
            isPlaying = false;
        }
    }
}
