using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private Rigidbody2D rb;

    private float screeBottom = -6.5f;

    // Start is called before the first frame update
    void Start()
    {
        //gets rigidbody, playerHealth script and sets the velocity
        rb = GetComponent<Rigidbody2D>();
        playerHealth = FindObjectOfType<PlayerHealth>();

        rb.velocity = Vector2.down * 2f;
    }

    private void Update()
    {
        //if the object is below the screen it gets deleted 
        if (transform.position.y <= screeBottom)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the object collides with the player 
        if (collision.gameObject.tag.Equals("Player"))
        {
            //object is destroyed and player gains health
            Destroy(gameObject);
            playerHealth.Heal(30);
            Debug.Log("HEAL!");
        }
    }
}
