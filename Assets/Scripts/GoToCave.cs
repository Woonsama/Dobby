using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCave : MonoBehaviour
{
    public AudioSource audio;
    public MachaAppear cave;
    public FadeOut fadeout;
    

    // Update is called once per frame
    void Update()
    {
        if (audio.time > audio.clip.length - cave.time) 
            cave.StartMove();
        if(audio.time > audio.clip.length - fadeout.time)
            fadeout.StartFadeOut();
    }
}
