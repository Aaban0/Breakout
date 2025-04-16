using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    private int highScore1;
    public TextMeshProUGUI score1;
    /*public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI score5;*/

    private void Update()
    {
        CheckHighScore();
    }

    private void CheckHighScore()
    {
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("score"));

            //highScore1 = PlayerPrefs.GetInt("HighScore");
            score1.text = $" Score: {PlayerPrefs.GetInt("HighScore"/*, highScore1*/)}";
        }
        else
        {
            score1.text = $" Score: {PlayerPrefs.GetInt("HighScore")}";
        }
    }
}
