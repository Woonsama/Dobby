using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DobbyHealthbar : MonoBehaviour
{
    private DobbyControll dobby;

    [Header("Smooth")]
    public float smooth;

    private Image img;

    void Start()
    {
        dobby = DobbyControll.Get();
        img = GetComponent<Image>();
        img.fillAmount = 1;
    }

    void Update()
    {
        img.fillAmount = Mathf.Lerp(img.fillAmount, dobby.hp / dobby.GetMaxHP(),smooth * Time.deltaTime);
    }
}
