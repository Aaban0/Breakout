using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    //variables for player movment
    private float movment;
    [SerializeField] float speed = 15f;

    //variable to prevent player from moving off screen
    [SerializeField] float screenLimit = 8f;

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
}
