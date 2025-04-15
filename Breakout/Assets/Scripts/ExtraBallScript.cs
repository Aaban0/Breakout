using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ExtraBallScript : MonoBehaviour
{
    private float screeBottom = -6.5f;

    public EnemyHealth enemyHealth;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
        rb.velocity = Vector2.down * 8f;
    }

    // Update is called once per frame
    void Update()
    {
        //if the ball is below the screen it gets deleted 
        if (transform.position.y <= screeBottom)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Brick"))
        {
            //brick gets destroyed and score is increased
            Destroy(collision.gameObject);
            /*score += 150;
            scoreTxt.text = score.ToString("000000");*/
            //enemy gets damaged
            enemyHealth.Damage(3.57f);
        }
    }
}
