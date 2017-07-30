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

    [SerializeField]
    private int health = 3;

    [SerializeField]
    private float invincibilityDuration = 2f;

    [SerializeField]
    private float invincibilityBlinkSpeed = 12f;

    private SpriteRenderer mySpriteRenderer;

    private Rigidbody2D myRigidbody;

    private bool isInvincible = false;

    public bool IsGrounded
    {
        get;
        private set;
    }

    public bool IsCrouching
    {
        get;
        private set;
    }

    public void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        IsGrounded = true;
    }

    public void Update()
    {
        ProcessInput();
    }
     
    private void ProcessInput()
    {
        if ((Input.GetKeyDown(KeyCode.Space) ||Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded)
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.DownArrow) && IsGrounded)
        {
            Crouch();
        }
        else if (IsGrounded)
        {
            Idle();
        }

    }

    private void Idle()
    {
        IsCrouching = false;
        mySpriteRenderer.sprite = idle;
    }

    private void Jump()
    {
        IsCrouching = false;
        myRigidbody.AddForce(Vector2.up * jumpForce);
    }

    private void Crouch()
    {
        IsCrouching = true;
        mySpriteRenderer.sprite = crouch;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Ground":
                IsGrounded = true;
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        switch (otherCollider.tag)
        {
            case "TrafficCone":
                if (IsGrounded)
                {
                    Hit();
                }
                break;
            case "Bird":
                if (!IsCrouching)
                {
                    Hit();
                }
                break;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            IsGrounded = false;
            mySpriteRenderer.sprite = jump;
        }
    }

    public void Hit()
    {
        if (!isInvincible)
        {
            health--;
            StartCoroutine(InvincibleCoroutine());
            if (health <= 0)
            {
                GameManager.Instance.GetCurrentGame().GameOver();
            }
        }
    }

    private IEnumerator InvincibleCoroutine()
    {
        float timer = 0f;
        isInvincible = true;
        while (timer <= invincibilityDuration)
        {
            mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, mySpriteRenderer.color.g,
                                               mySpriteRenderer.color.b, Mathf.Cos(timer * invincibilityBlinkSpeed));
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }

        mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, mySpriteRenderer.color.g, mySpriteRenderer.color.b, 1.0f);
        isInvincible = false;
    }
}

