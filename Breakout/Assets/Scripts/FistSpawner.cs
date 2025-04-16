using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistSpawner : MonoBehaviour
{
    public GameObject fistPrefab;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(fistPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Spawner();
    }

    private void Spawner()
    {
        if (timer >= 3)
        {
            int rand = Random.Range(1, 6);
            if (rand == 1)
            {
                Instantiate(fistPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            }
            else if (rand == 2)
            {
                Instantiate(fistPrefab, new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y, 0), Quaternion.identity);
            }
            else if(rand == 3)
            {
                Instantiate(fistPrefab, new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, 0), Quaternion.identity);
            }
            else if (rand == 4)
            {
                Instantiate(fistPrefab, new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y, 0), Quaternion.identity);
            }
            else if (rand == 5)
            {
                Instantiate(fistPrefab, new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, 0), Quaternion.identity);
            }
            else
            {
                 
            }
            timer = 0;
        }
    }
}
