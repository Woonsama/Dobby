using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Score score;
    public Text text;

    void Start()
    {
        score = Score.Get();
    }

    
    void Update()
    {
        text.text = score.GetScore().ToString() + "점";
    }
}
