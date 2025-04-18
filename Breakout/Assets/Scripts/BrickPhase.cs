using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPhase : MonoBehaviour
{
    public MultiBrick brick;

    private Rigidbody2D rb;
    private float screeBottom = -6.5f;

    private void Start()
    {
        brick = FindObjectOfType<MultiBrick>();

        rb = GetComponent<Rigidbody2D>();
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
            brick.powerEnabled = true;
            StartCoroutine(PowerDuration());

            Destroy(gameObject);
        }
    }

    private IEnumerator PowerDuration()
    {
        yield return new WaitForSeconds(3.9f);
        brick.powerEnabled = false;
    }
}
