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
    public GameObject Botas;
    public Array rallas;
    public GameObject ralla;
    public GameManager gameManager;
    public TextMeshProUGUI monedas;
    public GameObject BotonesMuerte;
    public GameObject BotonesEscena;


    #region methods
    public void OnPress(string s)
    {
        _stateManager.ChangeGameState(s);
    }

    public void SetFullScreen (bool isFS){
        Screen.fullScreen = !Screen.fullScreen;
    }    

    public void PowerUps()
    {
        Botas.SetActive(true);
    }

    public void EncenderBotonesMuerte(){
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
        monedas.text = gameManager.PuntosTotales.ToString();
    }

}
