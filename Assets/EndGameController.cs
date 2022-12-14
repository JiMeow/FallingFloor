using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    GameObject player;
    DeathCountController deathCountController;
    void Start()
    {
        deathCountController = GameObject.Find("Dead").GetComponent<DeathCountController>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (player.transform.position.y < -5 && player.activeSelf)
        {
            Debug.Log(player.transform.position.y);
            player.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        if (Time.timeScale == 0)
        {
            deathCountController.IncreaseDeathCount();
        }
        Time.timeScale = 1;
        // on webGl
        if (Application.platform == RuntimePlatform.Android)
        {
            AdManager.instance.PlayNormalAd(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // public void RestartWithAd()
    // {
    //     Time.timeScale = 1;
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
}
