using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float offset;
    public float speed;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, 540 + Mathf.PingPong(Time.time * speed, offset),transform.position.z);
    }
}
