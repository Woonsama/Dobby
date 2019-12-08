using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public float time;
    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void StartFadeOut()
    {
        StartCoroutine(fadeout());
    }

    private IEnumerator fadeout()
    {
        float t = 0.0f;
        var color = img.color;
        img.enabled = true;
        while (t < time)
        {
            t += Time.deltaTime;
            color.a = (t / time);
            img.color = color;
            yield return null;
        }

        color.a = 1.0f;
        img.color = color;

        SceneManager.LoadScene("Boss");
    }
}
