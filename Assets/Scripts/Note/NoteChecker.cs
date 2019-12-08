using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class NoteChecker : MonoBehaviour
{
    public AudioSource audio;
    public Transform startPosition;
    public float movingTime;
    public float throwing_before_t;
    public bool jundging = true;
    
    public DobbyControll dobby;

    private List<note> notes = new List<note>();
    private int now = 0;

    public note GetNote(int idx)
    {
        return notes[idx];
    }

    public int GetNoteCount()
    {
        return notes.Count();
    }

    public void AddNote(note note)
    {
        note.transform.position = startPosition.position;
        note.transform.parent = transform;
        note.SetChecker(this);
        notes.Add(note);
    }

    public void EndAdding()
    {
        notes.Add(null);
        notes.Add(null);
    }

    public void Next()
    {
        now++;
    }

    void Update()
    {
        var time = audio.time;
        // judge
        if (jundging)
        {
//            Debug.Log(name + "'s now = " + now.ToString());
            var nownote = notes[now];
            var nextnote = notes[now + 1];

            if (null != nextnote)
            {
                var distant = nownote.getDistant(time);
                var nextdistant = nextnote.getDistant(time);
                if (distant > nextdistant)
                {
                    nownote.Miss();
                    nownote = notes[now];
                }
            }

            if (null != nownote)
                nownote.Judge(time);
        }


        MoveNotes(time);
    }

    private int moving_notes = -1;
    private int throwed_notes = -1;
    private void MoveNotes(float t)
    {
        var delta = transform.position - startPosition.position;
        for (int i = 0; i < notes.Count; ++i)
        {
            if(null == notes[i]) continue;
            var timing = notes[i].GetTiming();
            if (timing < t + throwing_before_t)
            {
                if (i > throwed_notes)
                {
                    throwed_notes = i;
                    if (!notes[i].isProcessed())
                    {
                        dobby.Throw();
                        SoundEffectManager.Get().PlayGenSound();
                    }
                }
            }
            if (timing < t + movingTime)
            {
                if (i > moving_notes)
                {
                    moving_notes = i;
                    if(!notes[i].isProcessed())
                        notes[i].GetComponent<MeshRenderer>().enabled = true;
                }
                var p = (timing - t) / movingTime;
                p = 1 - p;
                notes[i].transform.position = startPosition.position + delta * p;
            }
            else
                notes[i].transform.position = startPosition.position;
        }
    }
}
