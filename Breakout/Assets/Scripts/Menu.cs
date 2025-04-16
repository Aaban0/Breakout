using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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

    public void Quit()
    {
        PlayerPrefs.Save();
        PlayerPrefs.DeleteKey("character");
        //exits the game
        Application.Quit();
    }
}
