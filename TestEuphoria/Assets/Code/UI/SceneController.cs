using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    internal bool isPause;

    private void Start()
    {
        Cursor.visible = false;
    }


    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    internal void PauseGame()
    {
        if(!isPause)
        {
            isPause = true;
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            isPause = false;
            Time.timeScale = 1;
            Cursor.visible = false;
        }
    }
}
