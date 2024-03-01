using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            case "cueva":
                StartCoroutine(ChangeScene(1, true, false));
                break;
            case "infierno":
                StartCoroutine(ChangeScene(2, true, false));
                break;
            case "options":
                StartCoroutine(ChangeScene(4, true, false));
                break;
            case "pause":
                Load(5, true);
                paused = true;
                //StartCoroutine(ChangeScene(4, true, true));
                break;
            case "resume":                
                paused = false;
                Unload(5);
                //StartCoroutine(ChangeScene(4, false, false));
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
            print("is load");
            Load(id, isAdditive);
        }
        else
        {
            print("is unload");
            Unload(id);
        }
    }

    private void Load(int id, bool isAdditive = false)
    {
        if (isAdditive)
        {
            print("is additive");
            print(id);
            var scn = SceneManager.GetSceneByBuildIndex(id);
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(id));
            print("pause is loaded and active");
        }
        else
        {
            SceneManager.LoadScene(id);
        }
    }
    
    private void Unload(int id)
    {
            print("pause is unloaded");
            SceneManager.UnloadScene(id);
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
