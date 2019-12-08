using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    [SerializeField] GameObject[] BG = new GameObject[4];
    [SerializeField] float[] scrollSpeed = new float[4];
    private Vector3[] firstPos = new Vector3[4];
    public float scrollDistance;
    public float factor = 0.0f;

    void Start()
    {
        InitFirstPos();
    }

    void Update()
    {
        Scroll(0);
        Scroll(1);
        Scroll(2);
        Scroll(3);
    }

    public void InitFirstPos()
    {
        for (int value = 0; value < 4; value++)
        {
            firstPos[value] = BG[value].transform.position;
        }

    }
    public void Scroll(int value)
    {
        BG[value].transform.position += Vector3.right * -scrollSpeed[value]*factor * Time.deltaTime;
        ScrollCheck(value);
    }
    public void ScrollCheck(int value)
    {
        if(Mathf.Abs(firstPos[value].x - BG[value].transform.position.x) >= scrollDistance)
        {
            BG[value].transform.position = firstPos[value];
        }
    }
}
