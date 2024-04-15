using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AutoScroll : MonoBehaviour
{
    [SerializeField]
    float speed = 100.0f;
    float textPosBegin=-2378.0f;
    float boundaryTextEnd=2563.0f;

    RectTransform myGorectTransform;
    [SerializeField]
    TextMeshProUGUI mainText;


    // Start is called before the first frame update
    void Start()
    {
        myGorectTransform =gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());
    }

    IEnumerator AutoScrollText()
    {
        while (myGorectTransform.localPosition.y < boundaryTextEnd)
        {
            myGorectTransform.Translate(Vector3.up*speed*Time.deltaTime);
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}