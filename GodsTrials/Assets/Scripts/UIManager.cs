using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region methods
    /// <summary>
    /// Called when the player presses start button.
    /// Needs to inform GameManager that the button has been pressed.
    /// </summary>
    public void OnPressStart()
    {
        Invoke("LoadCueva", 0.0f); 
    }

    public void LoadCueva()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadInfierno()
    {
        SceneManager.LoadScene(2);
    }

    #endregion
}
