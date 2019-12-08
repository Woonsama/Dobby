using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Text text;
    private float time;
    public float loadingTime;

    public float textChangeTime;
    private int num = 0;
    private float textTime;

    void Start()
    {
        time = 0;
        textTime = 0;
    }

    void Update()
    {
        LoadingTimeCheck();
        TextChangeTimeCheck();
    }

    public void LoadingTimeCheck()
    {
        if (time >= loadingTime)
        {
            SceneManager.LoadScene("InGame");
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    public void TextChangeTimeCheck()
    {
        if (textTime >= textChangeTime)
        {
            switch (num)
            {
                case 0:
                    text.text = "Loading.";
                    num = 1;
                    break;
                case 1:
                    text.text = "Loading..";
                    num = 2;
                    break;
                case 2:
                    text.text = "Loading...";
                    num = 0;
                    break;
            }
            textTime = 0;
        }
        else
        {
            textTime += Time.deltaTime;
        }
    }
}
