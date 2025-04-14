using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float deathY = -6f;
    private Vector3 startPosition;

    [SerializeField] float velocityLimit = 15f;

    private Rigidbody2D rb;

    private int counter = 0; 

    // Start is called before the first frame update
    void Start()
    {
        //gets starting position 
        startPosition = transform.position;
        //gets rigidbody component
        rb = GetComponent<Rigidbody2D>();

        //sets the velocity of the ball 
        rb.velocity = Vector2.down * 8f;
    }

    // Update is called once per frame
    void Update()
    {
        //if velocity exceeds the max
        if (rb.velocity.magnitude >= velocityLimit)
        {
            //restricts (clamps) velocity 
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, velocityLimit);
        }

        DeathCondition();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Brick"))
        {
            Destroy(collision.gameObject);
        }

        /*PLACEHOLDER LOGIC FOR ORANGE BLOCK*/

        if (collision.gameObject.tag.Equals("Strong Brick"))
        {
            counter++;
            if (counter == 2)
            {
                Destroy(collision.gameObject);
                counter = 0;
            }
        }
    }

    private void DeathCondition()
    {
        //if ball is out of bounds 
        if (transform.position.y <= deathY)
        {
            //ball reset to stating position 
            transform.position = startPosition;
            //resets the velocity to its inital velocity
            rb.velocity = Vector2.down * 8f;

            Debug.Log("GAME OVER!");
        }
    }
}
