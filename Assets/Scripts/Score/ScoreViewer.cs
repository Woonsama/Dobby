using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    public float smooth;

    private float val;
    private Text text;
    
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        val = Mathf.Lerp(val, Score.Get().GetScore(), smooth * Time.deltaTime);
        text.text = String.Format("{0,7:D7}", (int)val);
    }
}
