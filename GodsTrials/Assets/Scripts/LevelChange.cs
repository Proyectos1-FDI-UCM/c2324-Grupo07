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
    private VidaSystem _system;
    private DetectarNivel _detectarNivel;
    
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
    void Update()
    {
        if(_detectarNivel.nivel==1)
        {
            Debug.Log("pene1");
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                SceneManager.LoadScene(2);
            }
        }
        else if (_detectarNivel.nivel == 2) 
        {
            Debug.Log("pene2");
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                SceneManager.LoadScene(1);
            }
        }
        
    }
    public void Muerte()
    {
        SceneManager.LoadScene(3);
    }
    #endregion
}
