using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    #region references
    private GameManager _gameManager;
    private UIManager _UIManager;
    private StateManager _stateManager;
    #endregion

    #region methods
    public void LevelChange(string _toLevel)
    {
        _stateManager.ChangeGameState(_toLevel);
    }
    #endregion

    /// <summary>
    /// Initial setup of references and call to StartMenu
    /// </summary>
    void Start()
    {
        _gameManager = GetComponent<GameManager>();

        _UIManager = GetComponent<UIManager>();

        _stateManager = GetComponent<StateManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            print("pasamos a paused");
            //print("event sys disable");
            //EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            //eventSystem.enabled = false;
            _stateManager.ChangeGameState("pause");
        }
    }
}