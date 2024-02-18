using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    #region references
    private GameManager _gameManager;
    private UIManager _UIManager;
    #endregion

    #region methods
    /// <param name="collision">Colliding object</param>
    public void ChangeLevel(int lvl)
    {
        switch (lvl)
        {
            case 1:
                _UIManager.LoadCueva();
                print("to Cueva");
                break;
            case 2:
                _UIManager.LoadInfierno();
                print("to Infierno");
                break;
            default:
                break;
        }
    }
    #endregion

    /// <summary>
    /// Initial setup of references and call to StartMenu
    /// </summary>
    void Start()
    {
        _gameManager = GetComponent<GameManager>();

        _UIManager = GetComponent<UIManager>();
    }
}