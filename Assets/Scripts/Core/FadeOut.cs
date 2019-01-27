﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    private Image img;
    public string Scene;

    void Start()
    {
        Debug.Log("start");
        img = transform.Find("Panel").GetComponent<Image>();
        StartCoroutine(FadeImage(false));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        Debug.Log("fading");
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 2f; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);
    }
}
