using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteKey("HighScore");
            Debug.Log("SCORES DELETED");
        }
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteKey("character");
        SceneManager.LoadScene("CharacterSelect");
        //SceneManager.LoadScene("Level_1");
        PlayerPrefs.SetInt("score", 0);
    }

    public void Quit()
    {
        PlayerPrefs.Save();
        PlayerPrefs.DeleteKey("character");
        //exits the game
        Application.Quit();
    }
}
