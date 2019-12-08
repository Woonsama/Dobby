using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDieCheck : MonoBehaviour
{
    DobbyControll boss;

    public GameObject panel;

    void Start()
    {
        Time.timeScale = 1;
        boss = GameObject.FindWithTag("Boss").GetComponent<DobbyControll>();
    }

    void Update()
    {
        if(boss.DieCheck())
        {
            panel.SetActive(true);
        }
    }
}
