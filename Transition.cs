using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Transition : MonoBehaviour {

    public float fadeInTime;
    private Image fadePanel;
    private Color colorToFadeTo = Color.black;


    void Start()
    {
        fadePanel = GetComponent<Image>();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            colorToFadeTo.a -= alphaChange;
            fadePanel.color = colorToFadeTo;
        } else
        {
            gameObject.SetActive(false);
        }
    }
}
