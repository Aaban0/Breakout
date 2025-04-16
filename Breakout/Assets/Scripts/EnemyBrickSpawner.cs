using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;
    public EnemyHealth enemyHealth;

    public Image brickBar;

    private float brickCurrent = 0;
    private float brickMax = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        brickCurrent += Time.deltaTime * 10;

        brickBar.fillAmount = brickCurrent / brickMax;

        if (brickCurrent >= brickMax)
        {
            Instantiate(brickPrefab);
            enemyHealth.Heal(3.34f);
            brickCurrent = 0;
        }
    }
}
