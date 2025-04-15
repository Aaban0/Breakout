using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBrick : MonoBehaviour
{
    private bool powerEnabled = false;
    public CircleCollider2D circleCollider;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        powerEnabled = true;
        spriteRenderer.color = Color.yellow;
    }

    private void Update()
    {
        if (powerEnabled)
        {
            circleCollider.enabled = true;
            StartCoroutine(WaitTime());
        }
        else if (!powerEnabled)
        {
            circleCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (powerEnabled)
        {
            if (collision.gameObject.tag.Equals("Brick"))
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3f);
        powerEnabled = false;
        spriteRenderer.color = Color.white;
    }
}
