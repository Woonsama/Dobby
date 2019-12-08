using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitEnabler : MonoBehaviour
{
    public GameObject target;

    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        target.SetActive(true);
    }
}
