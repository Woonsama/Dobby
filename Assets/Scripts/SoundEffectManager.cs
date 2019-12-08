using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    private AudioSource audio;
    [Header("Clips")]
    public AudioClip UpSound;
    public AudioClip DownSound;
    public AudioClip hitSound;

    private static SoundEffectManager global = null;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        global = this;
    }

    public void PlayUpSound()
    {
        audio.PlayOneShot(UpSound);
    }

    public void PlayDownSound()
    {
        audio.PlayOneShot(DownSound);
    }

    public void PlayHitSound()
    {
        audio.PlayOneShot(hitSound);
    }

    public void PlayGenSound()
    {
        ;
    }

    public static SoundEffectManager Get()
    {
        return global;
    }
}
