using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject character1Prefab;
    public GameObject character2Prefab;

    void Update()
    {
        if (PlayerPrefs.GetInt("character") == 0)
        {
            Instantiate(character1Prefab, new Vector3(-7, -0.00999999978f, 0), Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("character") == 1)
        {
            Instantiate(character2Prefab, new Vector3(-7, -0.00999999978f, 0), Quaternion.identity);
        }
    }
}
