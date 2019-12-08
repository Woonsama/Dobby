using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public enum MONSTER_STATE
    {
        BASIC,
        ATTACK,
        DISATTACK,
    }
    public MONSTER_STATE monsterState;

    void Start()
    {
        monsterState = MONSTER_STATE.BASIC;    
    }

    void Update()
    {
        switch(monsterState)
        {
            case MONSTER_STATE.BASIC:
                break;
            case MONSTER_STATE.ATTACK:
                break;
            case MONSTER_STATE.DISATTACK:
                break;
        }
    }
}
