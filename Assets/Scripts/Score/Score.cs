using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static Score global = null;
    private int score = 0;
    public enum ScoreType { None=-1, Great=0, Good=1}

    void Awake()
    {
        global = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Reset()
    {
        score = 0;
    }

    public void Up(int val)
    {
        score += val;
    }

    public int GetScore()
    {
        return score;
    }

    public static Score Get()
    {
        return global;
    }
}
