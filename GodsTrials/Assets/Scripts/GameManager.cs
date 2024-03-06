using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    #region references
    private GameManager _gameManager;
    private UIManager _UIManager;
    private StateManager _stateManager;
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    #endregion

    #region methods
    public void LevelChange(string _toLevel)
    {        
        if (_toLevel == "muerte"){
            _UIManager.BotonesEscena.SetActive(false);
        }
        _stateManager.ChangeGameState(_toLevel);
    }
    #endregion
    public void SumarMonedas(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }

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
            _stateManager.ChangeGameState("pause");
        }
    }
}