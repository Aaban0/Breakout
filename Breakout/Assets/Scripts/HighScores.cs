using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI HighScore2;

    public TextMeshProUGUI HighScore3;
    public TextMeshProUGUI HighScore4;
    public TextMeshProUGUI HighScore5;

    public TextMeshProUGUI Name1;
    public TextMeshProUGUI Name2;
    public TextMeshProUGUI Name3;
    public TextMeshProUGUI Name4;
    public TextMeshProUGUI Name5;

    int playerScore;


    private void Start()
    {
        PlayerPrefs.DeleteKey("character");
        playerScore = PlayerPrefs.GetInt("score");

        UpdateHighScores();
        PrintHighScores();

    }

    private void Update()
    {
        ResetHighScores();
    }

    private void UpdateHighScores()
    {
        int newScore = PlayerPrefs.GetInt("score");
        string playerName = PlayerPrefs.GetString("name");

        for (int i = 0; i < 5; i++)
        {
            int savedScore = PlayerPrefs.GetInt("HighScore" + i, 0);

            if (newScore > savedScore)
            {
                // Shift down the lower scores
                for (int j = 4; j > i; j--)
                {
                    int previous = PlayerPrefs.GetInt("HighScore" + (j - 1), 0);
                    PlayerPrefs.SetInt("HighScore" + j, previous);

                    PlayerPrefs.SetString("HighScoreName" + j, PlayerPrefs.GetString("HighScoreName" + (j - 1), "---"));

                }

                // Insert new score
                PlayerPrefs.SetInt("HighScore" + i, newScore);

                PlayerPrefs.SetString("HighScoreName" + i, playerName);

                PlayerPrefs.Save();
                break;
            }
        }
    }

    /*public void SaveName(string playerName, int newScore)
    {
        for (int i = 0; i < 5; i++)
        {
            int savedScore = PlayerPrefs.GetInt("HighScore" + i, 0);

            if (newScore > savedScore)
            {
                // Shift down lower scores & names
                for (int j = 4; j > i; j--)
                {
                    PlayerPrefs.SetInt("HighScore" + j, PlayerPrefs.GetInt("HighScore" + (j - 1), 0));
                    PlayerPrefs.SetString("HighScoreName" + j, PlayerPrefs.GetString("HighScoreName" + (j - 1), "---"));
                }

                // Insert new score and name
                PlayerPrefs.SetInt("HighScore" + i, newScore);
                PlayerPrefs.SetString("HighScoreName" + i, playerName);
                PlayerPrefs.Save();
                break;
            }
        }
    }*/

    void PrintHighScores()
    {
        for (int i = 0; i < 5; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            if (i == 0)
            {
                HighScore.text = "Score 1: " + score; // Displays the score for the first rank (index 0)
            }
            if (i == 1)
            {
                HighScore2.text = "Score 2: " + score;
            }
            if (i == 2)
            {
                HighScore3.text = "Score 3: " + score;
            }
            if (i == 3)
            {
                HighScore4.text = "Score 4: " + score;
            }
            if (i == 4)
            {
                HighScore5.text = "Score 5: " + score;
            }

            string name = PlayerPrefs.GetString("HighScoreName" + i, "---");
            if (i == 0)
            {
                Name1.text = "Name: " + name;
            }
            if (i == 1)
            {
                Name2.text = "Name: " + name;
            }
            if (i == 2)
            {
                Name3.text = "Name: " + name;
            }
            if (i == 3)
            {
                Name4.text = "Name: " + name;
            }
            if (i == 4)
            {
                Name5.text = "Name: " + name;
            }

            //Debug.Log("Rank " + (i + 1) + ": " + score);
        }
    }

    private void ResetHighScores()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("HighScore" + i, 0);
                PlayerPrefs.SetString("name", "---");
            }
            PlayerPrefs.Save();
        }
    }


    /*private void CheckHighScore()
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
            score2.text = $" Score 2: {PlayerPrefs.GetInt("HighScore")}";
        }
    }*/
}
