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
    #endregion

    public void DañoTres()
    {
        vidaActual -= 10;
    }

    public void DañoTotal()
    {
        vidaActual -= 28;
    }
    private void Update()
    {
        barraVida.fillAmount = vidaActual/vidaMaxima;
    }
}
