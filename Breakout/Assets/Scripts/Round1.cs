using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Round1 : MonoBehaviour
{
    public TextMeshProUGUI character;

    // Start is called before the first frame update
    void Start()
    {
        character.text = $"{PlayerPrefs.GetString("characterName")}";
        StartCoroutine(Wait());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
