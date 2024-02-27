using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    #region references
    private StateManager _StateManager;
    #endregion

    #region methods
    /// <summary>
    /// Called when the player presses start button.
    /// Needs to inform GameManager that the button has been pressed.
    /// </summary>
    public void OnPressStart()
    {
        _StateManager.ChangeGameState("cueva");
    }
    
    public void OnPressExit()
    {
        _StateManager.ChangeGameState("quit");
    }
    #endregion

    /// <summary>
    /// Initial setup of references and call to StartMenu
    /// </summary>
    void Start()
    {
        _StateManager = GetComponent<StateManager>();
    }
}
