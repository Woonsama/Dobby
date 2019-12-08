using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Serialization;

public class note : MonoBehaviour
{
    [Serializable]
    public struct Data
    {
        public Data(float timing, int type)
        {
            this.timing = timing;
            this.type = type;
        }
        public float timing;
        public int type;
    }
    public enum Type {UP=0, DOWN=1, OUT_UP=2, OUT_DOWN=3}
    
    public static float[] conditions = {0.07f, 0.15f, 1.3f};    // great, good, not recog
   
    private float timing = 0.0f;
    private Type type = 0;
    private bool processed = false;
    private NoteConnector connector = null;
    private NoteChecker checker = null;

    private MeshRenderer renderer;

    private Player player;

    public void SetChecker(NoteChecker chekcer)
    {
        this.checker = chekcer;
    }

    void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void SetConnector(NoteConnector conn)
    {
        connector = conn;
    }
    
    public Data GetNoteData()
    {
        return new Data(timing, (int)type);
    }

    public void Setup(Data data)
    {
        this.timing = data.timing;
        this.type = (Type)data.type;
    }

    public float getDistant(float time)
    {
        return Mathf.Abs(time - timing);
    }

    public void Miss()
    {
        enabled = false;
        renderer.enabled = false;
        processed = true;

        if (connector)
        {
            var renderer = connector.GetComponent<SpriteRenderer>();
            var color = renderer.color;
            color.a /= 2;
            renderer.color = color;
            if ((int) type >= 2) 
                renderer.enabled = false;
            else
            {
                connector.getSecondJoint().GetComponent<note>().Miss();
                connector.SetFirstJoint(transform.parent);
            }
        }
        
        EffectShower.Get().Miss(transform);
        
        SoundEffectManager.Get().PlayHitSound();
        checker.Next();
    }

    public void Clear(Score.ScoreType type)
    {
        enabled = false;
        renderer.enabled = false;
        processed = true;


        if (connector)
        {
            if ((int) this.type >= 2)
            {
                connector.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
                connector.SetFirstJoint(transform.parent);
        }

        if (type == Score.ScoreType.Good)
        {
//            Debug.Log("Good");
            DobbyControll.Get().Damage(5);
            EffectShower.Get().Good(transform);
            Score.Get().Up(150);
        }
        else if (type == Score.ScoreType.Great)
        {
//            Debug.Log("Great");
            DobbyControll.Get().Damage(10);
            EffectShower.Get().Great(transform);
            Score.Get().Up(300);
        }

        switch (this.type)
        {
            case Type.UP:
            case Type.OUT_UP:
                SoundEffectManager.Get().PlayUpSound();
                break;
            case Type.DOWN:
            case Type.OUT_DOWN:
                SoundEffectManager.Get().PlayDownSound();
                break;
            default: break;
        }
        checker.Next();
    }

    public bool isProcessed()
    {
        return processed;
    }

    public bool CheckKeyDown()
    {
        var touch = TouchCheck.Get();
        if (!touch) return false;
        switch (type)
        {
            case Type.UP:
                return (touch.isClickUp);
                break;
            case Type.DOWN:
                return (touch.isClickDown);
                break;
            case Type.OUT_UP:
                return (touch.isUnClickUp);
                break;
            case Type.OUT_DOWN:
                return (touch.isUnClickDown);
            default:
                Debug.Log("invalid type");
                return false;
        }
    }

    public bool Judge(float time)
    {
        if (CheckKeyDown())
        {
            var distant = getDistant(time);
            if (distant < conditions[0])
            {
                player.GetHeal(2);
                Clear(Score.ScoreType.Great);
            }
            else if (distant < conditions[1])
            {
                player.GetHeal(1);
                Clear(Score.ScoreType.Good);
            }
            else if(distant < conditions[2] || ((int)type >= 2))
            {
                player.GetDamage(15);
                Miss();
            }
            else
            {
                return false;
            }
            return true;
        }
            
        if (time - timing > conditions[1])
        {
            player.GetDamage(15);
            Miss();
            return true;
        }

        return false;
    }

    public float GetTiming()
    {
        return timing;
    }
}
