using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject multiBallPrefab;
    private float screeBottom = -6.5f;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 2f;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if the object is below the screen it gets deleted 
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
            Instantiate(multiBallPrefab, new Vector3(player.transform.position.x, player.transform.position.y + 2, 0), Quaternion.identity);
            Debug.Log("SPAWNING BALLS!");
        }
    }
}
