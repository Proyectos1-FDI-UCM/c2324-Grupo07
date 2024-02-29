using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    #region references
    /// <summary>
    /// Level id to load when triggered
    /// </summary>
    [SerializeField]
    private string _toLevel;
    /// <summary>
    /// Reference to Game Manager
    /// </summary>
    [SerializeField]
    private GameManager _gameManager;
    #endregion
    #region methods
    /// <summary>
    /// Method to detect if a bullet reaches the target and inform the GameManager
    /// </summary>
    /// <param name="collision">Colliding object</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ControlarJugador>() != null)
        {
            _gameManager.LevelChange(_toLevel);
        }

    }

    public void Muerte()
    {
        SceneManager.LoadScene(3);
    }
    public void DespuesMuerte()
    {
        SceneManager.LoadScene(1);
    }
    #endregion
}
