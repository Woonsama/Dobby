using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectShower : MonoBehaviour
{
    public GameObject prefab_effect;
    public int reserve_count;

    private BubbleEffect[] reserve;
    private bool[] playing;

    private static EffectShower global = null;

    private void Awake()
    {
        reserve = new BubbleEffect[reserve_count];
        playing = new bool[reserve_count];
        for (int i = 0; i < reserve_count; ++i)
        {
            var obj = Instantiate(prefab_effect, transform);
            reserve[i] = obj.GetComponent<BubbleEffect>();
            reserve[i].SetIdx(i);
            playing[i] = false;
        }

        global = this;
    }

    private void Play(Transform note, string type)
    {
        for (int i = 0; i < reserve_count; ++i)
        {
            if (!playing[i])
            {
                reserve[i].transform.position = note.position;
                reserve[i].Show(type);
                playing[i] = true;
                break;
            }
        }
    }

    public void SetEnd(int idx)
    {
        playing[idx] = false;
    }

    public void Miss(Transform note)
    {
        Play(note, "miss");
    }

    public void Good(Transform note)
    {
        Play(note, "good");
    }

    public void Great(Transform note)
    {
        Play(note, "perfect");
    }

    public static EffectShower Get()
    {
        return global;
    }
}
