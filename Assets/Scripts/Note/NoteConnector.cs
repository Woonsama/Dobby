using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteConnector : MonoBehaviour
{
    private Transform note0;
    private Transform note1;
    public float yoffset;
    public float lengthfactor;

    public void SetJoint(Transform j0, Transform j1)
    {
        note0 = j0;
        note1 = j1;
    }

    public void SetFirstJoint(Transform j0)
    {
        note0 = j0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((note0.position.x + note1.position.x)/2.0f, note0.position.y + yoffset, note0.position.z);
        transform.localScale = new Vector3(Math.Abs(note0.position.x - note1.position.x)*lengthfactor, 1.0f);
    }

    public Transform getSecondJoint()
    {
        return note1;
    }
}
