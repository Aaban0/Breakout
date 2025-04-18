using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public GameObject GamePauseObject;
    public GameObject YouWin;
    public GameObject GameOver;
    public GameObject Round;

    public AudioSource pauseSfx;
    public AudioSource clickSfx;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameOver.activeSelf == false && YouWin.activeSelf == false && Round.activeSelf == false)
        {
            pauseSfx.Play();
            GamePauseObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Continue()
    {
        clickSfx.Play();
        GamePauseObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        clickSfx.Play();
        GamePauseObject.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1f;
    }

    public void PlaySfx()
    {
        clickSfx.Play();
    }
}
