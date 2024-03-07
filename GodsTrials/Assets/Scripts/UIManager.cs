using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class UIManager : MonoBehaviour
{
    #region references
    private StateManager _stateManager;
    #endregion
    [SerializeField] 
    public GameObject botas;
    public GameObject carro;
    public Array rallas;
    public GameObject ralla;
    public GameManager gameManager;
    public TextMeshProUGUI monedas = null;
    public GameObject BotonesMuerte = null;
    public GameObject BotonesEscena;


    #region methods
    public void OnPress(string s)
    {
        _stateManager.ChangeGameState(s);
    }

    public void SetFullScreen (bool isFS){
        Screen.fullScreen = !Screen.fullScreen;
    }    

    public void Botas()
    {
        botas.SetActive(true);
    }

    public void Carro()
    {
        carro.SetActive(true);
    }
    public void EncenderBotonesMuerte()
    {
        BotonesMuerte.SetActive(true);
    }

    #endregion

    /// <summary>
    /// Initial setup of references and call to StartMenu
    /// </summary>
    void Start()
    {        
        _stateManager = GetComponent<StateManager>();
        BotonesMuerte.SetActive(false);
        Invoke("EncenderBotonesMuerte", 4.0f);
        Screen.fullScreen = true;
        Screen.brightness = 0.5f;
    }
    
    
    void Update()
    {
        if (monedas != null){
            monedas.text = gameManager.PuntosTotales.ToString();
        }
    }

}
