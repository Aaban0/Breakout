using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject multiBallPrefab;
    public GameObject gameOver;

    public GameObject youWin;
    public Image healthbar;

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
        //if ball collides with a brick
        if (collision.gameObject.tag.Equals("Brick"))
        {
            //brick gets destroyed and score is increased
            Destroy(collision.gameObject);
            score += 150;
            scoreTxt.text = score.ToString("000000");

            if (SceneManager.GetActiveScene().name == "Level_1")
            {
                //enemy gets damaged 
                enemyHealth.Damage(3.34f);
            }
            else if (SceneManager.GetActiveScene().name == "Level_2")
            {
                enemyHealth.Damage(3.65f);
            }
            else if (SceneManager.GetActiveScene().name == "Level_3")
            {
                enemyHealth.Damage(3.847f);
            }

            //if enemy health is 0 then player wins round
            if (enemyHealth.healthCurrent <= 0)
            {
                youWin.SetActive(true);
            }

            //1 in 5 chance for the health boost to spawn
            int randomInt = Random.Range(1, 5);
            if (randomInt == 1)
            {
                //spawns at the destroyed bricks x & y coordinate
                Instantiate(healthBoostPrefab, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, 0), Quaternion.identity);
            }

            if (SceneManager.GetActiveScene().name == "Level_2")
            {
                int randomInt2 = Random.Range(1, 5);
                if (randomInt2 == 1)
                {
                    //spawns at the destroyed bricks x & y coordinate
                    Instantiate(multiBallPrefab, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, 0), Quaternion.identity);
                }
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

            //player is damaged
            health.Damage(30);
            if (healthbar.fillAmount <= 0)
            {
                gameOver.SetActive(true);
            }
            /*if (health.healthCurrent <= 0)
            {
                gameOver.SetActive(true);
            }*/
            Debug.Log("HIT!");


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
