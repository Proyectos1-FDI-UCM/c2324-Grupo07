using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    #region methods
    public void ChangeGameState(string id)
    {
        switch (id)
        {
            case "quit":
                Application.Quit();
                break;
            case "cueva":
                StartCoroutine(LoadScene(1));
                break;
            case "infierno":
                StartCoroutine(LoadScene(2));
                break;
            default:
                print("default CGS");
                break;
        }
    }

    IEnumerator LoadScene(int id)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(id);
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
