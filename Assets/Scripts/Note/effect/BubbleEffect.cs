using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class BubbleEffect : MonoBehaviour
{
    public float timescale = 1.0f;
    private MeshRenderer renderer;
    private SkeletonAnimation animator;
    private int idx = -1;

    public void SetIdx(int idx)
    {
        this.idx = idx;
    }
    
    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        animator = GetComponent<SkeletonAnimation>();
    }

    public void Show(string name)
    {
        renderer.enabled = true;
        animator.state.SetAnimation(0, name, false).TimeScale = timescale;
        StartCoroutine(AutoDisable());
    }

    IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(0.667f/timescale);
        renderer.enabled = false;
        EffectShower.Get().SetEnd(idx);
    }
}
