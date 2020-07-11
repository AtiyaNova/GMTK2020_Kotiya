using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script for the context text that shows up on the screen
public class ContextScript : MonoBehaviour
{
    Text text;
    Color originalColor;
    float fadeIn = 0.5f;

    private void Start()
    {
        text = GetComponent<Text>();
        originalColor = text.color;
        text.color = Color.clear;
    }

    //Referred to this for syntax: https://answers.unity.com/questions/1312063/fade-out-text.html
    private IEnumerator FadeIn()
    {
        Text text = GetComponent<Text>();
        for (float t = 0.01f; t < fadeIn; t += Time.deltaTime)
        {
            text.color = Color.Lerp(Color.clear, originalColor, Mathf.Min(1, t / fadeIn));
            yield return null;
        }
        text.color = originalColor;
    }

    public void PlayContext(string message)
    {
        text.text = message;
        StartCoroutine(FadeIn());
    }

    public void StopContext()
    {
        text.color = Color.clear;
    }

    public bool IsClear()
    {
        return text.color == Color.clear ? true : false;
    }
}
