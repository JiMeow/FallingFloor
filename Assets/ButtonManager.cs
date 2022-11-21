using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credit()
    {
        Application.OpenURL("https://github.com/JiMeow/FallingFloor");
    }

    public void ExitOrRefresh()
    {
        Application.Quit();
    }
}
