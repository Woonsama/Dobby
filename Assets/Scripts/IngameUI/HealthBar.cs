using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Player player;

    [Header("Smooth")]
    public float smooth;

     Image img;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        img = GetComponent<Image>();
        img.fillAmount = 1;
    }

    void Update()
    {
        img.fillAmount = Mathf.Lerp(img.fillAmount,player.GetHealth() / 100,smooth * Time.deltaTime);
    }
}
