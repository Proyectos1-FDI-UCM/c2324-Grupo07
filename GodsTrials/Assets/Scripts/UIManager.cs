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
    private int totalmonedas;
    [SerializeField] private TMP_Text textomonedas;

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
        print("resume is clicked");
        _stateManager.ChangeGameState("resume");
    }

    public void SetFullScreen (bool isFS){
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void SetScreenBrightness(float br){
        Screen.brightness = br;
    }

    private void SumarRupias(int rupias)
        {
            totalmonedas += rupias;
            textomonedas.text = totalmonedas.ToString();

        }

        public void PowerUps()
        {
            Botas.SetActive(true);
        }

        public void Vidas()
        {
            
            

        }

        public void Monedas()
        {
            
        }
    #endregion

    /// <summary>
    /// Initial setup of references and call to StartMenu
    /// </summary>
    void Start()
    {        
        _stateManager = GetComponent<StateManager>();
        Screen.fullScreen = true;
        Screen.brightness = 0.5f;
    }
    
}
