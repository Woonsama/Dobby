using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCheck : MonoBehaviour
{
    [Header("Audio")] 
    public AudioSource audio;
    public float fadeouttime;
    
    [Header("Win BG")]
    public GameObject WinBG;
    public Image WinBGImg;

    [Header("Game Clear UI")]
    public GameObject gameClearUI;
    public Image gameClearImage;
    public float moveSpeed;
    public float moveSmooth;
    private Vector2 firstPos;

    public float pos_Y;
    public float distance;

    [Header("Panel")]
    public GameObject panel;
    Color c;
    public float opacitySpeed;


    public float timeScale;

    void Start()
    {
        StartCoroutine(MusicFadeOut());
        Time.timeScale = 1;
        firstPos = gameClearUI.transform.position;

        c.a = 0;
    }

    void Update()
    {        
        WinBGImg.color = new Color(WinBGImg.color.r, WinBGImg.color.g, WinBGImg.color.b, c.a/2);
        gameClearImage.color = new Color(gameClearImage.color.r, gameClearImage.color.g, gameClearImage.color.b, c.a);

        if (c.a <= 1)
        {
            c.a += Time.deltaTime * opacitySpeed;
        }
        else
        {
            c.a = 1;
        }        

        OpacityCheck();
    }

    public void OpacityCheck()
    {
        if (c.a >= 0.999f)
        {
            gameClearUI.transform.position =
            Vector2.Lerp
            (
                gameClearUI.transform.position,
                firstPos + new Vector2(0, pos_Y),
                moveSmooth
            );

            if(gameClearUI.transform.position.y - (firstPos.y + pos_Y) <= distance)
            {
                Time.timeScale = timeScale;
                panel.SetActive(true);
            }
        }
    }

    IEnumerator MusicFadeOut()
    {
        float t = 0.0f;
        while (t < fadeouttime)
        {
            t += Time.deltaTime;
            audio.volume = 1.0f - t / fadeouttime;
            yield return null;
        }
        audio.Stop();
    }
}
