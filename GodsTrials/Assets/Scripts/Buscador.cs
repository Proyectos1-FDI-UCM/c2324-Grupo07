using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Buscador : MonoBehaviour
{
    /*#region parametros
    private static Canvas _instance;
    public static Canvas Instance { get { return _instance; } }
    private UIManager _uiManager;

    private Transform _myTransform;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _uiManager = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //OnEnable();
        
    }
    private void OnLevelWasLoaded()
    {
        
        Camera camara = Camera.main;
       
        Debug.Log(camara);

        // Si se encuentra la cámara y el canvas
        if (camara != null && transform != null)
        {
            Canvas canvas = transform.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = camara;

            }
        }
    }
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = GetComponent<Canvas>();
            DontDestroyOnLoad(gameObject);
        }
    }*/
}

