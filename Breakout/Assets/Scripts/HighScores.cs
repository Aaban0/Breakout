using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    private int highScore1;
    private int highScore2;
    private int highScore3;
    private int highScore4;
    private int highScore5;

    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;

    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI score5;

    private void Update()
    {
        CheckHighScore();
    }


    private void CheckHighScore()
    {
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("score"));
            score1.text = $" Score 1: {PlayerPrefs.GetInt("HighScore")}";
        }
        else
        {
            score1.text = $" Score 1: {PlayerPrefs.GetInt("HighScore")}";
        }


        if (PlayerPrefs.GetInt("score") < PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore2", PlayerPrefs.GetInt("score"));
            score2.text = $" Score 2: {PlayerPrefs.GetInt("HighScore2")}";
        }
        else
        {
            score1.text = $" Score 2: {PlayerPrefs.GetInt("HighScore")}";
        }
    }
}
