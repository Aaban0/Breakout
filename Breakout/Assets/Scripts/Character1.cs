using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character1 : MonoBehaviour
{
    public EnemyHealth enemyHealth;

    public Image powerBar;
    public float powerCurrent = 0;
    public float powerMax = 100;

    // Start is called before the first frame update
    void Start()
    {
        powerCurrent = 0;
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        powerCurrent += Time.deltaTime * 10f;

        powerBar.fillAmount = powerCurrent / powerMax;

        if (powerCurrent >= powerMax && Input.GetKeyDown(KeyCode.E))
        {
            enemyHealth.Damage(20);
            powerCurrent = 0;
        }
    }
}
