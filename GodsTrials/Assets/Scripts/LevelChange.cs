using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    #region references
        /// <summary>
    /// Reference to Game Manager
    /// </summary>
    [SerializeField]
    private GameManager _gameManager;
    private VidaSystem _system;
    /// <summary>
    /// Level id to load when triggered
    /// </summary>
    [SerializeField]
    private SceneID _toLevel;
    [SerializeField] GameObject dialogue;
    #endregion

    #region methods
    public void Muerte()
    {
        dialogue.SetActive(false);
        _gameManager.SetDead(true);
        _gameManager.LevelChange(SceneID.Muerte);
    }

    public void MuerteFinal()
    {
        _gameManager.LevelChange(SceneID.Cinematica);
    }

    /// <summary>
    /// Method to detect if a bullet reaches the target and inform the GameManager
    /// </summary>
    /// <param name="collision">Colliding object</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HOLA HERCULES");

        if (collision.GetComponent<ControlarJugador>() != null)
        {
            _gameManager.LevelChange(_toLevel);
       
        }
    }
    #endregion

    
}
