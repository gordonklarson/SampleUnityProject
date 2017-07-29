using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls movement of a group of alien enemies
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class AlienEnemyMovement : MonoBehaviour
{
    /// <summary>
    /// Movespeed of the enemy group
    /// </summary>
    [SerializeField]
    private float moveSpeed = 0.25f;

    /// <summary>
    /// Amount of time between each downward movement towards the player
    /// </summary>
    [SerializeField]
    private float dropTime = 5f;

    /// <summary>
    /// Distance to drop down when moving down towards the player
    /// </summary>
    [SerializeField]
    private float dropDistance = 0.05f;

    /// <summary>
    /// Each time the enemy group changes direction the speed gets multiplied by this value.
    /// </summary>
    [SerializeField]
    private float speedIncreaseMultiplyer = 0.01f;

    /// <summary>
    /// Direction the enemy group is moving in
    /// </summary>
    private Vector3 moveDirection = Vector3.right;
    /// <summary>
    /// Stores the time of the last downward movement
    /// </summary>
    private float timer = 0f;
    private Rigidbody2D myRigidbody;
    /// <summary>
    /// Stores the last screen border hit. Used in testing to make sure the 
    /// enemy group doesn't collide with the same screen border more than once in a row.
    /// </summary>
    private Collider2D lastBorderHit;

    public void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        myRigidbody.velocity = moveDirection * moveSpeed;
        timer = Time.time;
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("ScreenBorder") && lastBorderHit != collision.collider)
        {
            lastBorderHit = collision.collider;
            
            moveDirection *= -1.0f; // reverse move direction
            moveSpeed += moveSpeed * speedIncreaseMultiplyer;
            myRigidbody.velocity = moveDirection * moveSpeed;

            //drop down if enough time has passed
            if (Time.time - timer >= dropTime)
            {
                timer = Time.time;
                myRigidbody.MovePosition(transform.position + Vector3.down * dropDistance);
            }
        }
    }
}
