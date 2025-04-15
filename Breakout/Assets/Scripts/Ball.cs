using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    private float deathY = -6f;
    private Vector3 startPosition;

    [SerializeField] float velocityLimit = 15f;

    private Rigidbody2D rb;

    int score { get; set; } = 0;
    public TextMeshProUGUI scoreTxt;

    private int counter = 0; 


    public PlayerHealth health;
    public PlayerHealth enemyHealth;

    void Start()
    {
        //gets starting position 
        startPosition = transform.position;
        //gets rigidbody component
        rb = GetComponent<Rigidbody2D>();

        //sets the velocity of the ball 
        rb.velocity = Vector2.down * 8f;

        //strongBrick = FindObjectOfType<StrongBrick>();
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
        //StrongBrick();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Brick"))
        {
            Destroy(collision.gameObject);
            score += 100;
            scoreTxt.text = score.ToString("000000");

            enemyHealth.Damage(3.34f);

            if (enemyHealth.healthCurrent <= 0)
            {
                Debug.Log("YOU WIN!");
            }
        }

        /*PLACEHOLDER LOGIC FOR ORANGE BLOCK*/

        if (collision.gameObject.tag.Equals("Strong Brick"))
        {
            counter++;

            if (collision.gameObject.tag.Equals("Strong Brick") && counter == 2)
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
            health.Damage(30);
            Debug.Log("HIT!");

            if (health.healthCurrent <= 0)
            {
                Debug.Log("GAME OVER!");
            }
        }
    }

    /*private void StrongBrick()
    {
        if (strongBrick.IsDestroyed() == true)
        {
            score += 250;
            scoreTxt.text = score.ToString("000000");
        }
    }*/

    /*public void AddScore(int amount)
    {
        score += amount;
    }*/
}
