using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Round1_Level : MonoBehaviour
{
    public GameObject round1;
    public TextMeshProUGUI fight;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.00001f;
        fight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RoundStart());
    }

    private IEnumerator RoundStart()
    {
        yield return new WaitForSeconds(0.00001f);
        fight.enabled = true;
        yield return new WaitForSeconds(0.00001f);
        round1.SetActive(false);
        Time.timeScale = 1f;
    }
}
