using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieCheck : MonoBehaviour
{
    private Player player;

    [Header("Black Screen")]
    public GameObject blackScr;
    public Image blackScreen;
    [Header("GameOver Image / Restart Btn Image")]
    public GameObject gameOverUI;
    public Image gameover;

    public GameObject RestartBtn;
    public Image RestartBtnImg;

    Color c;

    [Header("Time Scale")]
    public float timeScale;
    public float opacity;

    [Header("Audio Source")]
    public AudioSource ingameSound;

    void Start()
    {
        Time.timeScale = 1;
        c.a = 0;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        
    }

    void Update()
    {
        //ingameSound.Stop(); // stop Sing

        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, c.a);
        gameover.color = new Color(gameover.color.r, gameover.color.g, gameover.color.b, c.a);
        RestartBtnImg.color = new Color(RestartBtnImg.color.r, RestartBtnImg.color.g, RestartBtnImg.color.b, c.a);


        if (player.DieCheck())
        {

            blackScr.SetActive(true);
            gameOverUI.SetActive(true);
            RestartBtn.SetActive(true);

            Time.timeScale = timeScale;
            c.a += opacity * Time.deltaTime * 1 / timeScale;
        }
    }
}
