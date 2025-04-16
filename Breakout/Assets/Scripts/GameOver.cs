using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public PlayerHealth health;
    public GameObject gameOver;

    // Update is called once per frame
    void Update()
    {
        if (gameOver.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
        PlayerPrefs.SetInt("score", 0);
    }
}
