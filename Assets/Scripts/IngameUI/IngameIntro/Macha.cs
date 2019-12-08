using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Macha : MonoBehaviour
{
    private Vector2 lerpPos;
    private Vector2 lerpFinishPos;

    public float smooth;
    [SerializeField] bool isLerpFinished;
    [SerializeField] float lerpDistance;


    private float time;
    [SerializeField] bool istextFinish;


    void Start()
    {
        istextFinish = false;
        lerpPos = new Vector2(5, -2.86f);
        lerpFinishPos = new Vector2(25, -2.86f);
        isLerpFinished = false;
        
    }

    void Update()
    {
        LerpFinishCheck();

        if (isLerpFinished)
        {            

            time += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, lerpFinishPos, smooth * Time.deltaTime);
            GameObject.Destroy(gameObject,1);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, lerpPos, smooth * Time.deltaTime);
        }

    }

    public void LerpFinishCheck()
    {
        if(Mathf.Abs(transform.position.x - lerpPos.x) <=lerpDistance)
        {
            isLerpFinished = true;
        }
    }
}
