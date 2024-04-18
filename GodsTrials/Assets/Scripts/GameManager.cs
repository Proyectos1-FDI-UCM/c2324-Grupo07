using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region references
    //creacion del Singleton del GameManager
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private UIManager _UIManager;
    private StateManager _stateManager;
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    [SerializeField]
    private bool isMenu;
    #endregion

    #region methods
    public void LevelChange(SceneID _toScene)
    {
        _stateManager.ChangeGameState(_toScene);
    }
    #endregion
    public void SumarMonedas(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }


    /// Initial setup of references and call to StartMenu
    void Start()
    {
        _instance = GetComponent<GameManager>();

        _UIManager = GetComponent<UIManager>();

        _stateManager = GetComponent<StateManager>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isMenu)
        {
            //Debug.Log("KeyDownESC");
            _stateManager.ChangeGameState(SceneID.PauseMenu);          
        }        
    }

   /* private void Awake()
    {

        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

      
    }*/
}