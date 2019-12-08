using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] AudioSource IngameMusic;
    public float length;
    private bool isStart;

    [Header("Audio Length Slider")]
    public Slider ingameMusicSlider;

    [Header("Music Time")]
    [SerializeField] Text timeText;

    private AudioClip clip;

    [Header("Volume")]
    public float volume;


    void Start()
    {
        clip = IngameMusic.clip;
        length = clip.length;
        isStart = true;
        IngameMusic.Play();
    }

    void Update()
    {
//        IngameMusic.time = time;

        if (!isStart)
        {            
            IngameMusic.time = ingameMusicSlider.value * length;
        }
        timeText.text = (int)IngameMusic.time / 60 + "분 " + (int)IngameMusic.time % 60 + "초";
    }


    public void MusicStart()
    {
        IngameMusic.volume = volume * 0.01f;
        isStart = true;
    }
    public void MusicStop()
    {
        IngameMusic.volume = 0;
        isStart = false;
    }
}
