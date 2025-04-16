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
        brickCurrent += Time.deltaTime * 20;

        brickBar.fillAmount = brickCurrent / brickMax;

        if (brickCurrent >= brickMax)
        {
            var position = new Vector3(Random.Range(-4.11f, 3), Random.Range(-1.82f, -0.25f), 0);
            Instantiate(brickPrefab, position, Quaternion.identity);
            enemyHealth.Heal(3.34f);
            brickCurrent = 0;
        }
    }
}
