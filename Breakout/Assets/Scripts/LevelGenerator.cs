using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Vector2Int brickNumber;
    public Vector2 brickOffset;
    public GameObject BrickPrefab;
    public Gradient gradient;

    private void Awake()
    {
        for (int i = 0; i < brickNumber.x; i++)
        {
            for(int j = 0; j < brickNumber.y; j++)
            {
                GameObject newBrick = Instantiate(BrickPrefab, transform);
                newBrick.transform.position = transform.position + new Vector3((float)((brickNumber.x - 1) * .5f - i)*brickOffset.x, (j*brickOffset.y + 1), 0);
                newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j / (brickNumber.y - 1));
            }
        }
    }
}
