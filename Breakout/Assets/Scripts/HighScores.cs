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
        if (Input.GetKeyDown(KeyCode.T))
        {
            ResetHighScores();
        }
    }

    private void UpdateHighScores()
    {
        //gets player score and name
        int newScore = PlayerPrefs.GetInt("score");
        string playerName = PlayerPrefs.GetString("name");

        //loops for 5 scores 
        for (int i = 0; i < 5; i++)
        {
            //gets score at i
            int savedScore = PlayerPrefs.GetInt("HighScore" + i, 0);

            if (newScore > savedScore)
            {
                // Shift down the lower scores
                for (int j = 4; j > i; j--)
                {
                    //moves items down by one 

                    //get score one place up
                    int previous = PlayerPrefs.GetInt("HighScore" + (j - 1), 0);
                    //move down by one 
                    PlayerPrefs.SetInt("HighScore" + j, previous);
                    //move name down by one 
                    PlayerPrefs.SetString("HighScoreName" + j, PlayerPrefs.GetString("HighScoreName" + (j - 1), "---"));

                }
                // Adds new score
                PlayerPrefs.SetInt("HighScore" + i, newScore);
                PlayerPrefs.SetString("HighScoreName" + i, playerName);

                PlayerPrefs.Save();

                //exit since score is added
                break;
            }
        }
    }

    void PrintHighScores()
    {
        //loops for 5 scores 
        for (int i = 0; i < 5; i++)
        {
            //gets the high score
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            if (i == 0)
            {
                // Displays the score for the first rank
                HighScore.text = "Score 1: " + score;
            }
            if (i == 1)
            {
                // Displays the score for the Second rank
                HighScore2.text = "Score 2: " + score;
            }
            if (i == 2)
            {
                // Displays the score for the third rank
                HighScore3.text = "Score 3: " + score;
            }
            if (i == 3)
            {
                // Displays the score for the fourth rank
                HighScore4.text = "Score 4: " + score;
            }
            if (i == 4)
            {
                // Displays the score for the fith rank
                HighScore5.text = "Score 5: " + score;
            }
            //gets the names 
            string name = PlayerPrefs.GetString("HighScoreName" + i, "---");
            if (i == 0)
            {
                // Displays the name for the first rank
                Name1.text = "Name: " + name;
            }
            if (i == 1)
            {
                // Displays the name for the second rank
                Name2.text = "Name: " + name;
            }
            if (i == 2)
            {
                // Displays the name for the third rank
                Name3.text = "Name: " + name;
            }
            if (i == 3)
            {
                // Displays the name for the fourth rank
                Name4.text = "Name: " + name;
            }
            if (i == 4)
            {
                // Displays the name for the fith rank
                Name5.text = "Name: " + name;
            }
        }
    }

    private void ResetHighScores()
    {
        //loops for all scores
        /*for (int i = 0; i < 5; i++)
        {
            //resets to its default values
            PlayerPrefs.SetInt("HighScore" + i, 0);
            PlayerPrefs.SetString("name" + i, "---");
        }*/

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        PrintHighScores();
    }
}
