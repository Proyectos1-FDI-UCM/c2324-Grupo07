using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public enum SceneID {MainMenu, Cueva, Infierno, Muerte, OptionsMenu, PauseMenu, Montaña, Cielo, Final, Quit, Resume, Restart, Back};

public class StateManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private bool paused = false;

    #region methods
    public void ChangeGameState(SceneID id)
    {
        Debug.Log(id);
        switch (id)
        {
            case SceneID.Quit:
                Application.Quit();
                break;                
            case SceneID.MainMenu:
                StartCoroutine(ChangeScene(0, true, false));
                break;
            case SceneID.Cueva:
                StartCoroutine(ChangeScene(1, true, false));
                break;
            case SceneID.Infierno:
                StartCoroutine(ChangeScene(2, true, false));
                break;
            case SceneID.Montaña:
                StartCoroutine (ChangeScene(6, true, false));
                break;
            case SceneID.Cielo:
                StartCoroutine(ChangeScene(7,true, false));
                break;
            case SceneID.Final:
                StartCoroutine(ChangeScene(8,true, false));
                break;
            case SceneID.Muerte:
                //StartCoroutine(ChangeScene(3, true, true));
                Load(3, true);
                break;
            case SceneID.OptionsMenu:
                StartCoroutine(ChangeScene(4, true, false));
                break;
            case SceneID.PauseMenu:
                //EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
                //eventSystem.enabled = false;
                //StartCoroutine(ChangeScene(5, true, true));
                Load(5, true);
                paused = true;
                break;
            case SceneID.Resume:                
                paused = false;
                StartCoroutine(ChangeScene(5, false, true));
                //Unload(5);
                break;            
            case SceneID.Restart:
                StartCoroutine(ChangeScene(3, false, true));
                //Unload(3);
                break;
            case SceneID.Back:
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
        if (id == 3)
        {//si era la escena de muerte
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    #endregion
}
