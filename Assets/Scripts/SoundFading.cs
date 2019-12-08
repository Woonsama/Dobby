using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct FadingInfo
{
    public float fadein;
    public float fadeout;
}

public class SoundFading : MonoBehaviour
{
    public AudioSource source;
    public FadingInfo info;
    
    void Start()
    {
        StartCoroutine(fadein());
    }

    void Update()
    {
        if (source.clip.length - info.fadeout < source.time)
            StartCoroutine(fadeout());
    }

    private IEnumerator fadein()
    {
        source.volume = 0.0f;
        float t = 0.0f;
        while (t < info.fadein)
        {
            t += Time.deltaTime;
            source.volume = t / info.fadein;
            yield return null;
        }

        source.volume = 1.0f;
    }

    private IEnumerator fadeout()
    {
        source.volume = 1.0f;
        float t = 0.0f;
        while (t < info.fadeout)
        {
            t += Time.deltaTime;
            source.volume = 1.0f-(t / info.fadein);
            yield return null;
        }

        source.volume = 0.0f;
    }
}
