using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class AlienPlayerController : MonoBehaviour
{

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float moveSpeed = 0.5f;

    [SerializeField]
    private float fireRate = 0.5f;

    private Rigidbody2D myRigidbody;
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GameManager.Instance.GetCurrentGame().GameOver();
        }
    }
}
