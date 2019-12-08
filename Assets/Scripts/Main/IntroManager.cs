using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera mainCam;
    [SerializeField] private float camMoveSpeed;
    [SerializeField] private float moveDistance;

    [Header("Main Logo")]
    [SerializeField] SpriteRenderer Logo;

    [Header("Start Button")]
    [SerializeField] Image StartBtn;


    [Header("Color Speed")]
    public float colorSpeed;

    Vector3 firstMainCamPos;
    Color c;
    void Start()
    {
        firstMainCamPos = mainCam.transform.position; // init first main camera position.  

        c.a = 0;
    }
    
    void Update()
    {
        Logo.color = new Color(Logo.color.r, Logo.color.g, Logo.color.b,c.a);
        StartBtn.color = new Color(StartBtn.color.r, StartBtn.color.g, StartBtn.color.b, c.a);

        CamMoveCheck();
        OpacityUp();
    }

    private void CamMoveCheck()
    {
        if(Mathf.Abs(firstMainCamPos.y - mainCam.transform.position.y) >= moveDistance)
        {
            Debug.Log("Camera Move is Finished");
        }
        else
        {
            mainCam.transform.position += Vector3.down * camMoveSpeed * Time.deltaTime;
        }
    }
    private void OpacityUp()
    {
        c.a += colorSpeed * Time.deltaTime;
    }

    public void StartButton()
    {
         SceneManager.LoadScene("Loading");
    }
}
