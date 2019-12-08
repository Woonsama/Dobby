using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public enum BOSS_STATE
    {
        BASIC,
        ATTACK,
        DISATTACK,
    }
    public BOSS_STATE bossState;

    void Start()
    {
        bossState = BOSS_STATE.BASIC;
    }

    void Update()
    {
        switch(bossState)
        {
            case BOSS_STATE.BASIC:
                break;
            case BOSS_STATE.ATTACK:
                break;
            case BOSS_STATE.DISATTACK:
                break;
        }
    }
}
