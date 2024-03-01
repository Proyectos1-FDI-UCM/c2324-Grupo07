using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region references
    private GameManager _gameManager;
    private UIManager _UIManager;
    private StateManager _stateManager;
    public DetectarNivel _detectarNivel;
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
        _detectarNivel = GameObject.Find("Hercules").GetComponent<DetectarNivel>();

        _gameManager = GetComponent<GameManager>();

        _UIManager = GetComponent<UIManager>();

        _stateManager = GetComponent<StateManager>();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Muerte")
        {
            if (_detectarNivel.nivel == 1)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    SceneManager.LoadScene(2);
                }
            }
            else if (_detectarNivel.nivel == 2)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
       

    }
}