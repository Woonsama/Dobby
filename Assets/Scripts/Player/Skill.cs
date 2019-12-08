using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    private Player player;

    [Header("Skill Delay")]
    public float skill1Delay;
    public float skill2Delay;

    private float skill1Time;
    private float skill2Time;

    public bool isSkill1On;
    public bool isSkill2On;

    [Header("Skill UI")]
    [SerializeField] Image skill1;
    [SerializeField] Image skill2;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        skill1Time = skill2Time = 0;
        isSkill1On = isSkill2On = false;
    }
    private void Update()
    {

        if(skill1Time >= skill1Delay)
        {
            isSkill1On = true;
            skill1Time = skill1Delay;
        }
        else
        {
            skill1Time += Time.deltaTime;
            skill1.fillAmount = skill1Time / skill1Delay;
        }

        if (skill2Time >= skill2Delay)
        {
            isSkill2On = true;
            skill2Time = skill2Delay;
        }
        else
        {
            skill2Time += Time.deltaTime;
            skill2.fillAmount = skill2Time / skill2Delay;
        }
    }

    public void GaugeUp(float amount)
    {
        skill1Time += amount;
    }

    public void SKILL_1()
    {
        if (isSkill1On && !player.isSkilling())
        {
            skill1Time = 0;
            player.SetPlayerState(Player.PLAYER_STATE.SKILL1);
            isSkill1On = false;
            
            DobbyControll.Get().Damage(60);
        }
    }

    public void SKILL_2()
    {
        if (isSkill2On && !player.isSkilling())
        {
            skill2Time = 0;
            player.SetPlayerState(Player.PLAYER_STATE.SKILL2);
            isSkill2On = false;
            
            DobbyControll.Get().Damage(60);
        }
    }
}
