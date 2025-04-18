using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    private string name;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("character");
    }

    public void Character1()
    {
        PlayerPrefs.SetInt("character", 0);
        PlayerPrefs.SetString("characterName", "Steve");
        Time.timeScale = 1f;
        //SceneManager.LoadScene("Level_1");
    }

    public void Character2()
    {
        PlayerPrefs.SetInt("character", PlayerPrefs.GetInt("character", + 1));
        PlayerPrefs.SetString("characterName", "Bob");
        Time.timeScale = 1f;
        //SceneManager.LoadScene("Level_1");
    }

    public void EnterName(string newName)
    {
        name = newName;
        Debug.Log(name);
        PlayerPrefs.SetString("name", name);
        SceneManager.LoadScene("Round_1");
    }
}
