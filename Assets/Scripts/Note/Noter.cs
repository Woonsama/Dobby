using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System;
using UnityEngine.Serialization;

[Serializable]
public class NoteData
{
    public List<note.Data> notes = new List<note.Data>();

    public void Add(note.Data data)
    {
        notes.Add(data);
    }

    public void SortData()
    {
        notes.Sort(delegate(note.Data data, note.Data data1)
        {
            if (data.timing > data1.timing) return 1;
            if (data.timing < data1.timing) return -1;
            return 0;
        });
    }

    public void ProcessStacked(float recog, float interval)
    {
        SortData();

        for (int i = 0; i < notes.Count; ++i)
        {
            for (int j = 1; i+j <notes.Count && Math.Abs(notes[i].timing - notes[i+j].timing) < recog && notes[i].type == notes[i+j].type; ++j)
            {
                notes[i + j] = new note.Data(notes[i+j].timing + interval*j, notes[i+j].type);
            }
        }
    }

    public void Reset()
    {
        notes.Clear();
    }
}

public class Noter : MonoBehaviour
{
    public NoteData data = new NoteData();
    public int bpm = 0;
    public bool noting = true;
    public bool longnote = true;
    public AudioSource audio;
    public NoteChecker[] checkers;

    [Header("겹치는거")] 
    public float interval_recog;
    public float creating_interval;
    
    private NoteData newdata = new NoteData();

    void Start()
    {
        if (noting)
        {
            for (int i = 0; i < checkers.Length; ++i)
                checkers[i].jundging = false;
            StartCoroutine(Noting());
        }
        else
        {
            for (int i = 0; i < checkers.Length; ++i)
                checkers[i].jundging = true;
        }
    }

    IEnumerator Noting()
    {
        var time_per_beat = 60.0f / bpm;
        var beatcount = 0;
        while (true)
        {
            var t = audio.time;

            var next_beat = (beatcount + 1) * time_per_beat;
            var now_beat = beatcount * time_per_beat;
            if (Math.Abs(next_beat - t) < Math.Abs(now_beat - t))
            {
                beatcount += 1;
            }
            
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                note.Data note;
                note.timing = beatcount*time_per_beat;
                note.type = 0;
                newdata.Add(note);
                Debug.Log("Note!");
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                note.Data note;
                note.timing = beatcount*time_per_beat;
                note.type = 1;
                newdata.Add(note);
                Debug.Log("Note!");
            }

            if (longnote)
            {
                if (Input.GetKeyUp(KeyCode.A))
                {
                    note.Data note;
                    note.timing = beatcount*time_per_beat;
                    note.type = 2;
                    newdata.Add(note);
                    Debug.Log("Note!");
                }
                else if (Input.GetKeyUp(KeyCode.Z))
                {
                    note.Data note;
                    note.timing = beatcount*time_per_beat;
                    note.type = 3;
                    newdata.Add(note);
                    Debug.Log("Note!");
                }
            }

            yield return null;
        }
    }

    public void makeData()
    {
        
        data.Reset();
        for(int i=0; i<newdata.notes.Count; ++i)
            data.Add(newdata.notes[i]);
        for (int i = 0; i < checkers.Length; ++i)
        {
            var checker = checkers[i];
            var len = checker.GetNoteCount();
            Debug.Log("checker:" + len.ToString());
            for (int j = 0; j < len; ++j)
            {
                if(null != checker.GetNote(j))
                    data.Add(checker.GetNote(j).GetNoteData());
            }
        }
        data.ProcessStacked(interval_recog, creating_interval);
    }
}
