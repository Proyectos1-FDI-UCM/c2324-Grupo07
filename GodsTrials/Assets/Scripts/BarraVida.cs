using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    #region parametros
    public Image barraVida;
    public float vidaActual;
    public float vidaMaxima;
    private float muerteinst = 28f;
    private float muertetres = 10f;
    #endregion

    public void DanoSiete ()
    {
        vidaActual -= 4;
    }
    public void DanoTres()
    {
        vidaActual -= muertetres;
    }

    public void DanoTotal()
    {
        vidaActual -= muerteinst;
    }
    private void Update()
    {
        barraVida.fillAmount = vidaActual/vidaMaxima;
        if (vidaActual == 0)
        {
            vidaActual = vidaMaxima;
        }
    }
}
