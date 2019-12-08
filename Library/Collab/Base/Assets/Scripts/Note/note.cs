using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class note : MonoBehaviour
{
    [Serializable]
    public struct Data
    {
        public Data(float timing, bool exact, int type)
        {
            this.timing = timing;
            this.exact = exact;
            this.type = type;
        }
        public float timing;
        public int type;
        public bool exact;
    }
    public enum Type {UP=0, DOWN=1, EVENT_UP=2, EVENT_DOWN=3}
    
    public static float[] conditions = {0.05f, 0.13f};    // great, good
   
    private float timing = 0.0f;
    private bool exact = true;
    private Type type = 0;

    private MeshRenderer renderer;

    void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    
    public Data GetNoteData()
    {
        return new Data(timing, exact, (int)type);
    }

    public void Setup(Data data)
    {
        this.timing = data.timing;
        this.exact = data.exact;
        this.type = (Type)data.type;
    }

    public float getDistant(float time)
    {
        return Mathf.Abs(time - timing);
    }

    public void Miss()
    {
        Debug.Log("Miss");
        enabled = false;
        renderer.enabled = false;
    }

    public void Clear(Score.ScoreType type)
    {
        Score.Get().Up(type);
        Debug.Log(((int)type).ToString());
        enabled = false;
        renderer.enabled = false;
    }

    // 터치로 고쳐야 함
    public bool CheckKeyDown()
    {
        switch (type)
        {
            case Type.UP:
                return (TouchCheck.Get().isClickUp);
            case Type.DOWN:
                return (TouchCheck.Get().isClickDown);
            case Type.EVENT_UP:
                return (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.X))
                       || (Input.GetKey(KeyCode.Z) && Input.GetKeyDown(KeyCode.X));
            default:
                Debug.Log("invalid type");
                return false;
        }
    }
    
    // 터치로 고쳐야 함
    public bool CheckKey()
    {
        switch (type)
        {
            case Type.UP:
                return TouchCheck.Get().isTouchUp;
            case Type.DOWN:
                return TouchCheck.Get().isTouchDown;
            case Type.EVENT_UP:
                return (Input.GetKey(KeyCode.Z) && Input.GetKeyDown(KeyCode.X));
            default:
                Debug.Log("invalid type");
                return false;
        }
    }

    public bool Judge(float time)
    {
        if ((exact && CheckKeyDown()) || (!exact && CheckKey()))
        {
            var distant = getDistant(time);
            if (!exact && timing-time < conditions[1])
                Clear(Score.ScoreType.Great);
            else if (distant < conditions[0])
                Clear(Score.ScoreType.Great);
            else if (distant < conditions[1])
                Clear(Score.ScoreType.Good);
            else
                Miss();
            return true;
        }
        
        if (time - timing > conditions[1])
        {
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
