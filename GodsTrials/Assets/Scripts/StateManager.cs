using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StateManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    
    private bool paused = false;

    #region methods
    public void ChangeGameState(string id)
    {
        switch (id)
        {
            case "quit":
                Application.Quit();
                break;                
            case "mainMenu":
                StartCoroutine(ChangeScene(0, true, false));
                break;
            case "cueva":
                StartCoroutine(ChangeScene(1, true, false));
                break;
            case "infierno":
                StartCoroutine(ChangeScene(2, true, false));
                break;
            case "monta�a":
                StartCoroutine (ChangeScene(6, true, false));
                break;
            case "muerte":
                //StartCoroutine(ChangeScene(3, true, true));
                Load(3, true);
                break;
            case "options":
                StartCoroutine(ChangeScene(4, true, false));
                break;
            case "pause":
                //EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
                //eventSystem.enabled = false;
                //StartCoroutine(ChangeScene(5, true, true));
                Load(5, true);
                paused = true;
                break;
            case "resume":                
                paused = false;
                StartCoroutine(ChangeScene(5, false, true));
                //Unload(5);
                break;            
            case "restartLevel":
                StartCoroutine(ChangeScene(3, false, true));
                //Unload(3);
                break;
            case "back":
                StartCoroutine(ChangeScene(0, true, false));
                break;
                
            default:
                print("default CGS");
                break;
        }
    }

    IEnumerator ChangeScene(int id, bool isLoad, bool isAdditive)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if (isLoad)
        {
            Load(id, isAdditive);
        }
        else
        {
            Unload(id);
        }
    }

    private void Load(int id, bool isAdditive = false)
    {
        if (isAdditive)
        {
            SceneManager.LoadScene(id, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(id);
        }
    }
    
    private void Unload(int id)
    {
        SceneManager.UnloadSceneAsync(id);
        if(id == 3){//si era la escena de muerte
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
