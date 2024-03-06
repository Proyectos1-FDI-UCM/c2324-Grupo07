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
    [SerializeField] 
    public GameObject BotonesMuerte;


    #region methods
    /// <summary>
    /// Called when the player presses start button.
    /// Needs to inform GameManager that the button has been pressed.
    /// </summary>
    public void OnPressStart()
    {
        _stateManager.ChangeGameState("cueva");
    }
    
    public void OnPressExit()
    {
        _stateManager.ChangeGameState("quit");
    }

    public void OnPressOptions()
    {
        _stateManager.ChangeGameState("options");
    }
    
    public void OnPressBack()
    {
        _stateManager.ChangeGameState("back");
    }

    public void OnPressResume()
    {
        _stateManager.ChangeGameState("resume");
    }

    public void OnPressPause()
    {
        _stateManager.ChangeGameState("pause");
    }

    public void OnPressRestart()
    {
        _stateManager.ChangeGameState("mainMenu");
    }

    public void OnPressRestartLevel()
    {
        _stateManager.ChangeGameState("restartLevel");
    }

    public void SetFullScreen (bool isFS){
        Screen.fullScreen = !Screen.fullScreen;
    }    

    public void PowerUps()
    {
        Botas.SetActive(true);
    }

    public void EncenderBotones(){
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
        Invoke("EncenderBotones", 4.0f);
        Screen.fullScreen = true;
        Screen.brightness = 0.5f;
    }
    
    
    void Update()
    {
        monedas.text = gameManager.PuntosTotales.ToString();
    }

}
