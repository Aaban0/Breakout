using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    //variables for player movment
    private float movment;
    [SerializeField] float speed = 15f;

    //variable to prevent player from moving off screen
    [SerializeField] float screenLimit = 8f;

    public AudioSource power;
    public AudioSource spell;


    void Update()
    {
        Movment();
    }

    private void Movment()
    {
        //Uses unity input system for player input and moves player 
        movment = Input.GetAxis("Horizontal");

        //checks if the player is in the bounds of the map
        if ((movment > 0 && transform.position.x < screenLimit) || (movment < 0 && transform.position.x > -screenLimit))
        {
            //players position is moved
            transform.position += Vector3.right * movment * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("power"))
        {
            power.Play();
        }

        if (collision.gameObject.tag.Equals("spell1"))
        {
            spell.Play();
        }
    }
}
