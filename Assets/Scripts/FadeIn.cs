using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float time;
    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fadein());
    }

    private IEnumerator Fadein()
    {
        float t = 0.0f;
        var color = img.color;
        while (t < time)
        {
            t += Time.deltaTime;
            color.a = 1.0f - (t / time);
            img.color = color;
            yield return null;
        }

        color.a = 0.0f;
        img.color = color;
        gameObject.SetActive(false);
    }
}
