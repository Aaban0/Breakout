using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    public GameObject youWin;

    // Update is called once per frame
    void Update()
    {
        if (youWin.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
