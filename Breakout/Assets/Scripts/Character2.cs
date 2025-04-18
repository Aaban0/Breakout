using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character2 : MonoBehaviour
{
    public PlayerHealth health;

    public Image powerBar;
    public TextMeshProUGUI e;

    public float powerCurrent = 0;
    public float powerMax = 100;

    public AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        powerCurrent = 0;
        health = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        powerCurrent += Time.deltaTime * 10f;

        powerBar.fillAmount = powerCurrent / powerMax;

        if (powerCurrent >= powerMax)
        {
            e.enabled = true;
        }
        else
        {
            e.enabled = false;
        }

        if (powerCurrent >= powerMax && Input.GetKeyDown(KeyCode.E))
        {
            sfx.Play();
            health.Heal(30);
            powerCurrent = 0;
        }
    }
}
