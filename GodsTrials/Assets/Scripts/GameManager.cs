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
    private AudioSource _audio;
    private StateManager _stateManager;
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    [SerializeField]
    private bool isMenu;
    private bool isDead;
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

    public void SetDead(bool b){
        isDead = b;
        if (b){
            _audio.Stop();
        }
        else{
            _audio.Play();
        }
    }

    /// Initial setup of references and call to StartMenu
    void Start()
    {
        _instance = GetComponent<GameManager>();

        _UIManager = GetComponent<UIManager>();

        _stateManager = GetComponent<StateManager>();

        _audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();

        isDead = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isMenu && !isDead)
        {
            if (_stateManager.isPaused()) {
                _audio.Play();
            }
            else {
                _audio.Stop();
            }
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