using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testo : MonoBehaviour
{
    #region parametros
    public GameObject sprite;
    public ParticleSystem particles;
    #endregion

    private void Start()
    {
        StartCoroutine(waitForIt());
    }

    IEnumerator waitForIt()
    {
        yield return new WaitForSeconds(1.5f);
        play();
    }

    public void play()
    {
        sprite.gameObject.SetActive(false);
        particles.Emit(9999);
    }
}
