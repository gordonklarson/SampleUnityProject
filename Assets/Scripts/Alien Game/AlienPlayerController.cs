using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class AlienPlayerController : MonoBehaviour
{
    /// <summary>
    /// Object to be used as projectiles by the player.
    /// </summary>
    [SerializeField]
    private GameObject projectile;

    /// <summary>
    /// Movement speed of the player
    /// </summary>
    [SerializeField]
    private float moveSpeed = 0.5f;

    /// <summary>
    /// Rate at which the player can fire projectiles.
    /// </summary>
    [SerializeField]
    private float fireRate = 0.5f;

    /// <summary>
    /// Attached Rigidbody2D
    /// </summary>
    private Rigidbody2D myRigidbody;

    /// <summary>
    /// Current input value of the horizontal input axis
    /// </summary>
    private float horizontalInput = 0f;

    
    private float lastFireTime = 0f;

    public void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update ()
	{
	    ProcessInput();
	}

    public void FixedUpdate()
    {
        myRigidbody.MovePosition(transform.position + Vector3.right * horizontalInput * moveSpeed * Time.fixedDeltaTime);
    }


    private void ProcessInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButton("Fire1") && Time.time - lastFireTime >= fireRate)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            lastFireTime = Time.time;
        }
    }

}
