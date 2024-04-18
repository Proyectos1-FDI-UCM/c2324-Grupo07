using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Testing : MonoBehaviour
{
    #region references
    //creacion del Singleton del Testing
    private static Testing _instance;
    public static Testing Instance { get { return _instance; } }
    #endregion

    public void escribe(string s){
        string path = Application.persistentDataPath + "/testing.txt";
       //Write some text to the test.txt file
       StreamWriter writer = new StreamWriter(path, true);
       writer.WriteLine(s);
        writer.Close();
       StreamReader reader = new StreamReader(path);
       //Print the text from the file
       Debug.Log(reader.ReadToEnd());
       reader.Close();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
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
    }
}
