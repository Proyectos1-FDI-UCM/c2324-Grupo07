using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    #region references
    private StateManager _stateManager;

    public GameObject botas = null;
    public GameObject carro = null;
    public GameObject pez = null;
    public Array rallas;
    public GameObject ralla = null;
    public GameManager gameManager;
    public TextMeshProUGUI monedas = null;
    public GameObject BotonesMuerte = null;
    public GameObject BotonesEscena = null;
    public AudioClip buttonClickFXClip = null;
    #endregion

    #region methods

    public void OnPress(int _toScene)
    {
        Debug.Log(_toScene);
        //play sound FX
        if (buttonClickFXClip != null)
        {
            SoundFXManager.instance.PlaySoundFXClip(buttonClickFXClip, transform, 1f);
        }
        _stateManager.ChangeGameState((SceneID)_toScene);
    }

    public void SetFullScreen(bool isFS)
    {
        if (buttonClickFXClip != null)
        {
            SoundFXManager.instance.PlaySoundFXClip(buttonClickFXClip, transform, 1f);
        }
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void EncenderBotonesMuerte()
    {
        BotonesMuerte.SetActive(true);
    }
    #endregion

    #region Power-Ups

    public void Botas()
    {
        botas.SetActive(true);
    }

    public void Carro()
    {
        carro.SetActive(true);
    }

    public void Pez()
    {
        pez.SetActive(true);
    }

    #endregion

    /// <summary>
    /// Initial setup of references and call to StartMenu
    /// </summary>
    void Start()
    {
        _stateManager = GetComponent<StateManager>();
        if (BotonesMuerte != null){
            BotonesMuerte.SetActive(false);
            Invoke("EncenderBotonesMuerte", 4.0f);
        }
        Screen.fullScreen = true;
        Screen.brightness = 0.5f;
        if (botas != null){
            botas = GameObject.Find("BotasCanvas").GetComponent<GameObject>();
        }
        if (pez != null){
            pez = GameObject.Find("pez").GetComponent<GameObject>();
        }
        if (carro != null){
            carro = GameObject.Find("carrocanvas").GetComponent<GameObject>();
        }
    }
    
    void Update()
    {
        if (monedas != null)
        {
            monedas.text = gameManager.PuntosTotales.ToString();
        }
    }

}
