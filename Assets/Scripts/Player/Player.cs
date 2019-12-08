using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PLAYER_STATE
    {
        BASIC,
        ATTACK_UP,
        ATTACK_DOWN,
        DISATTACK,
        SKILL1,
        SKILL2,
    }
    [Header("Player State")]
    public PLAYER_STATE playerState;

    [Header("Player Health")]
    public float health;

    private Animator animator;

    private float maxhealth = 0.0f;
    private int atk1 = 0;
    private int atk2 = 0;
    private bool playing = false;
    private bool skill = false;

    [SerializeField] bool isDie;

    void Start()
    {
        playerState = PLAYER_STATE.BASIC;
        animator = GetComponent<Animator>();
        isDie = false;
        maxhealth = health;
    }

    void Update()
    {
        HpCheck();

        switch (playerState)
        {
            case PLAYER_STATE.BASIC:
                break;
            case PLAYER_STATE.ATTACK_UP:
                if (!playing)
                {
                    animator.SetTrigger("up" + (atk1 + 1).ToString());
                    atk1++;
                    atk1 %= 3;
                    playing = true;
                }
                playerState = PLAYER_STATE.BASIC;
                break;
            case PLAYER_STATE.ATTACK_DOWN:
                if (!playing)
                {
                    animator.SetTrigger("down" + (atk2 + 1).ToString());
                    atk2++;
                    atk2 %= 3;
                    playing = true;
                }
                playerState = PLAYER_STATE.BASIC;
                break;
            case PLAYER_STATE.DISATTACK:
                animator.SetTrigger("damage");
                playerState = PLAYER_STATE.BASIC;
                break;
            case PLAYER_STATE.SKILL1:
                if (!playing)
                {
                    animator.SetTrigger("skill1");
                    skill = true;
                    playing = true;
                }
                playerState = PLAYER_STATE.BASIC;
                break;
            case PLAYER_STATE.SKILL2:
                if (!playing)
                {
                    animator.SetTrigger("skill2");
                    skill = true;
                    playing = true;
                }

                playerState = PLAYER_STATE.BASIC;
                break;
        }
    }

    public bool isSkilling()
    {
        return skill;
    }

    public void EndPlaying()
    {
        playing = false;
    }

    public void EndSkill()
    {
        skill = false;
    }

    public void SetPlayerState(PLAYER_STATE value)
    {
        playerState = value;
    }

    public float GetHealth()
    {
        return health;
    }

    public void GetDamage(float damage)
    {
        if (!isSkilling())
        {
            SetPlayerState(PLAYER_STATE.DISATTACK);
            health -= damage;
        }
    }
    public void GetHeal(float value)
    {
        health += value;
        health = health > maxhealth ? maxhealth : health;
    }

    public void HpCheck()
    {
        if(health  <= 0)
        {
            isDie = true;
        }
    }

    public bool DieCheck()
    {
        if(isDie)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
