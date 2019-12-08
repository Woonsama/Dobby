using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public GameObject[] prefab_notes;
    public GameObject prefab_connector;
    public Noter noter;
    public AudioSource audio;

    public NoteChecker checker0;
    public NoteChecker checker1;
    
    private int now = 0;
    
    void Start()
    {   
        NoteData notedata = noter.data;
        if (null != notedata)
        {
            List<note.Data> notelist = notedata.notes;

            var length = audio.clip.length;

            note checker0_last = null;
            note checker1_last = null;
            GameObject connector = null;
            NoteConnector conn = null;
            
            for (var i = 0; i < notelist.Count; ++i)
            {
                var obj = Instantiate(prefab_notes[notelist[i].type]);
                var note_compo = obj.GetComponent<note>();
                note_compo.Setup(new note.Data(notelist[i].timing, notelist[i].type));
                switch (notelist[i].type)
                {
                    case (int)note.Type.UP:
                        checker0.AddNote(note_compo);
                        checker0_last = note_compo;
                        break;
                    case (int)note.Type.OUT_UP:
                        checker0.AddNote(note_compo);
                        connector = Instantiate(prefab_connector, checker0.transform);
                        conn = connector.GetComponent<NoteConnector>();
                        conn.SetJoint(checker0_last.transform, note_compo.transform);
                        checker0_last.SetConnector(conn);
                        note_compo.SetConnector(conn);
                        break;
                    case (int)note.Type.DOWN:
                        checker1.AddNote(note_compo);
                        checker1_last = note_compo;
                        break;
                    case (int)note.Type.OUT_DOWN:
                        checker1.AddNote(note_compo);
                        connector = Instantiate(prefab_connector, checker1.transform);
                        conn = connector.GetComponent<NoteConnector>();
                        conn.SetJoint(checker1_last.transform, note_compo.transform);
                        checker1_last.SetConnector(conn);
                        note_compo.SetConnector(conn);
                        break;
                    default: break;
                }
            }
            checker0.EndAdding();
            checker1.EndAdding();
        }

    }
}
