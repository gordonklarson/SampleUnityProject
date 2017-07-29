using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class JumpPlayerController : MonoBehaviour
{

    [SerializeField]
    private float jumpForce = 1f;

    [SerializeField]
    private Sprite idle;

    [SerializeField]
    private Sprite crouch;

    [SerializeField]
    private Sprite jump;
    
    private SpriteRenderer mySpriteRenderer;

    private Rigidbody2D myRigidbody;

    private bool isGrounded = true;

    public void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        ProcessInput();
    }
     
    private void ProcessInput()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
        {
            Crouch();
        }
        else if (isGrounded)
        {
            Idle();
        }

    }

    private void Idle()
    {
        mySpriteRenderer.sprite = idle;
    }

    private void Jump()
    {
        myRigidbody.AddForce(Vector2.up * jumpForce);
    }

    private void Crouch()
    {
        mySpriteRenderer.sprite = crouch;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
            mySpriteRenderer.sprite = jump;
        }
    }
}

