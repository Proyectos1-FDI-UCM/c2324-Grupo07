using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    #region references
    //creacion del Singleton del GameManager
    private GameManager _instance;
    public GameManager Instance;

    private UIManager _UIManager;
    private StateManager _stateManager;
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    [SerializeField]
    private GameObject _canvas;
    #endregion

    #region methods
    public void LevelChange(string _toLevel)
    {
        if (_toLevel == "muerte")
        {
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


    /// Initial setup of references and call to StartMenu
    void Start()
    {
        _instance = GetComponent<GameManager>();

        _UIManager = GetComponent<UIManager>();

        _stateManager = GetComponent<StateManager>();

        _canvas = GetComponent<GameObject>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _stateManager.ChangeGameState("pause");
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(_canvas);

        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}