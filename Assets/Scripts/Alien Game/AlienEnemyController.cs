using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller for an individual alien enemy
/// </summary>
public class AlienEnemyController : MonoBehaviour
{
    /// <summary>
    /// Number of hits this enemy can take before dying
    /// </summary>
    [SerializeField]
    private int health = 3;

    [SerializeField]
    private SpriteRenderer mySpriteRenderer;

    public void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Alien collided with " + collision.gameObject.name);
        if (collision.collider.CompareTag("Projectile"))
        {
            health--;
            mySpriteRenderer.color += new Color(-0.3f, 0.3f, 0.3f);
            if (health == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Alien entered trigger on object " + collider.gameObject.name);
    }
}
