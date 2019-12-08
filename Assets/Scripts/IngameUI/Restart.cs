using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] bool isBossStage;

    public void RestartButton()
    {
        if(isBossStage)
        {
            Destroy(Score.Get().gameObject);
            SceneManager.LoadScene("InGame");
        }
        else
        {
            Destroy(Score.Get().gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
