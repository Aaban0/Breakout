using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMovment : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    private bool movingDown = true;
    
    void Update()
    {
        StartCoroutine(Movment());
    }

    private IEnumerator Movment()
    {
        if (movingDown)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            yield return new WaitForSeconds(2);
            movingDown = false;
        }
        else if (movingDown == false)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return new WaitForSeconds(2);
            movingDown = true;
        }
    }
}
