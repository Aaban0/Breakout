using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPhase : MonoBehaviour
{
    public MultiBrick brick;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);

            brick.enabled = true;
            StartCoroutine(PowerDuration());
        }
    }

    private IEnumerator PowerDuration()
    {
        yield return new WaitForSeconds(4f);
        brick.enabled = false;
        spriteRenderer.color = Color.white;
    }
}
