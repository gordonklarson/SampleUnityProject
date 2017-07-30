using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Obstacle : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 1.0f;
    

    private Rigidbody2D myRigidbody;

    public void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        myRigidbody.velocity = Vector2.left * moveSpeed;
    }
}
