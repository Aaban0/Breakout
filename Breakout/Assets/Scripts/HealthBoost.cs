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
        rb = GetComponent<Rigidbody2D>();
        playerHealth = FindObjectOfType<PlayerHealth>();

        rb.velocity = Vector2.down * 2f;
    }

    private void Update()
    {
        if (transform.position.y <= screeBottom)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            playerHealth.Heal(30);
            Debug.Log("HEAL!");
        }
    }
}
