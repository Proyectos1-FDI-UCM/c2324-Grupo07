using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraCaida : MonoBehaviour
{
    /// <summary>
    /// Reference to Game Manager
    /// </summary>
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private float speed = 0.3f;
    // Start is called before the first frame update
    [SerializeField] private float shakeMagnitude = 0.01f; // ajusta para controlar intensidad de shake

    void Start()
    {
        StartCoroutine(NextScene());        
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(9);
        _gameManager.LevelChange(SceneID.Cueva);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Random.insideUnitSphere * shakeMagnitude;
        transform.position += Vector3.down * speed;
    }
}
