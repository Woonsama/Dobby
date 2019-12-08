using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.AI;

public class DobbyControll : MonoBehaviour
{
    public string[] dobby_types;
    public float hp;

    private float maxHP;
    private int dobby_idx = 0;
    private SkeletonAnimation animator;
    private IEnumerator waitidle = null;

    private static DobbyControll global = null;

    private void Awake()
    {
        animator = GetComponent<SkeletonAnimation>();
        global = this;
    }

    private void Start()
    {
        maxHP = hp;
        StayIdle();
    }

    public void StayIdle()
    {
        animator.state.SetAnimation(0, dobby_types[dobby_idx] + "idle", true);
    }

    public void Throw()
    {
        if (waitidle == null)
        {
            animator.state.SetAnimation(0, dobby_types[dobby_idx] + "throw", true);
            StartCoroutine(waitidle = WaitIdle(0.667f));
        }
    }

    private void Die()
    {
        if (waitidle != null)
        {
            StopCoroutine(waitidle);
            waitidle = null;
        }
        animator.state.SetAnimation(0, dobby_types[dobby_idx] + "die", true);
        StartCoroutine(waitidle = WaitIdle(1.0f));
        ++dobby_idx;
        dobby_idx %= dobby_types.Length;
    }

    IEnumerator WaitIdle(float sec)
    {
        yield return new WaitForSeconds(sec);
        StayIdle();
        waitidle = null;
    }

    public void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0.0f)
        {
            hp = maxHP;
            Die();
        }
    }

    public static DobbyControll Get()
    {
        return global;
    }

    public bool DieCheck()
    {
        if(hp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
