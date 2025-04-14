using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBrick : MonoBehaviour
{
    private int counter = 0;

    private bool destroyed = false;
    /*private void Start()
    {
        ballScript = Ball.FindObjectOfType<Ball>();
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            counter++;
            if (counter == 2)
            {
                Destroy(gameObject);
                destroyed = true;
                /*ballScript.AddScore(200);
                ballScript.scoreTxt.text*/
            }
        }
    }

    public bool IsDestroyed()
    {
        return destroyed;
    }
}
