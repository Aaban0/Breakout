using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI message;

    private int score;
    public TextMeshProUGUI scoreText;

    public AudioSource clickSfx;

    private void Start()
    {
        score = PlayerPrefs.GetInt("score");
        scoreText.text = $"YOU SCORED: {PlayerPrefs.GetInt("score", score)}";

        clickSfx = GetComponent<AudioSource>();

        //message.enabled = false;
        
        
    }

    private void Update()
    {

    }

    public void StartGame()
    {
        //clickSfx.Play();
        PlayerPrefs.SetString("name", "---");
        PlayerPrefs.DeleteKey("character");
        SceneManager.LoadScene("CharacterSelect");
        //SceneManager.LoadScene("Level_1");
        PlayerPrefs.SetInt("score", 0);
    }

    public void ResetScores()
    {
        clickSfx.Play();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        StartCoroutine(Message());
    }
    private IEnumerator Message()
    {
        if (SceneManager.GetActiveScene().name == "Main_Menu")
        {
            message.enabled = true;
            yield return new WaitForSeconds(2);
            message.enabled = false;
        }
       
    }

    public void Quit()
    {
        clickSfx.Play();
        PlayerPrefs.Save();
        PlayerPrefs.DeleteKey("character");
        //exits the game
        Application.Quit();
    }

    public void MainMenu()
    {
        clickSfx.Play();
        SceneManager.LoadScene("Main_Menu");
    }

    public void PlaySFX()
    {
        clickSfx.Play();
    }
}
