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

    private void Start()
    {
        score = PlayerPrefs.GetInt("score");
        scoreText.text = $"YOU SCORED: {PlayerPrefs.GetInt("score", score)}";

        message.enabled = false;
        
        
    }

    private void Update()
    {

    }

    public void StartGame()
    {
        PlayerPrefs.SetString("name", "Not Aaban");
        PlayerPrefs.DeleteKey("character");
        SceneManager.LoadScene("CharacterSelect");
        //SceneManager.LoadScene("Level_1");
        PlayerPrefs.SetInt("score", 0);
    }

    public void ResetScores()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        StartCoroutine(Message());
    }
    private IEnumerator Message()
    {
        message.enabled = true;
        yield return new WaitForSeconds(2);
        message.enabled = false;
    }

    public void Quit()
    {
        PlayerPrefs.Save();
        PlayerPrefs.DeleteKey("character");
        //exits the game
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
