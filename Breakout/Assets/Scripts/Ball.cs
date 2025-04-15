using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    private float deathY = -6.5f;
    private Vector3 startPosition;

    [SerializeField] float velocityLimit = 15f;

    private Rigidbody2D rb;

    int score { get; set; } = 0;
    public TextMeshProUGUI scoreTxt;

    public PlayerHealth health;
    public EnemyHealth enemyHealth;

    public GameObject healthBoostPrefab;

    void Start()
    {
        //gets starting position 
        startPosition = transform.position;
        //gets rigidbody component
        rb = GetComponent<Rigidbody2D>();

        //sets the velocity of the ball 
        rb.velocity = Vector2.down * 8f;

    }

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
            score += 150;
            scoreTxt.text = score.ToString("000000");

            enemyHealth.Damage(3.34f);

            if (enemyHealth.healthCurrent <= 0)
            {
                Debug.Log("YOU WIN!");
            }

            int randomInt = Random.Range(1, 5);
            if (randomInt == 1)
            {
                Instantiate(healthBoostPrefab, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, 0), Quaternion.identity);
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
