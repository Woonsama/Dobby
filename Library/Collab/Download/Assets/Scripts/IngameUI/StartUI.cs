using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    private Vector3 firstPos = new Vector3(0, -1, 0);
    private Vector3 secondPos = new Vector3(-16, -1, 0);
    public float smooth;

    public float Distance;

    private bool isFinish;

    [Header("Start")] 
    public MachaAppear macha;

    void Start()
    {
        isFinish = false;
    }
  
    void Update()
    {
        if (!isFinish)
        {
            FirstMove();
        }
        else
        {
            SecondMove();
        }
    }
    public void FirstMove()
    {       
        FirstMoveCheck();
    }

    public void FirstMoveCheck()
    {
        if(Mathf.Abs(transform.position.x - firstPos.x) <= Distance)
        {
            isFinish = true;
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, firstPos, smooth * Time.deltaTime);
        }
    }

    public void SecondMove()
    {
        transform.position = Vector2.Lerp(transform.position, secondPos, smooth * Time.deltaTime);
        GameObject.Destroy(gameObject, 1);
    }

    private void OnDestroy()
    {
        macha.StartMove();
    }
}
