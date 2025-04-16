using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
        PlayerPrefs.SetInt("score", 0);
    }

    public void Quit()
    {
        PlayerPrefs.Save();
        //exits the game
        Application.Quit();
    }
}
