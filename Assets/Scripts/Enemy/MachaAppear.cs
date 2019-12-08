using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachaAppear : MonoBehaviour
{
    public Transform destination;
    public float time;

    private IEnumerator move = null;

    private Vector3 origin;
    // Start is called before the first frame update
    public void StartMove()
    {
        if(move == null)
            StartCoroutine(move = Move());
    }

    IEnumerator Move()
    {
        origin = transform.position;
        float t = 0.0f;
        while (t < time)
        {
            float p = t / time;
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(origin, destination.position, p);
            yield return null;
        }

        transform.position = destination.position;
    }
}
