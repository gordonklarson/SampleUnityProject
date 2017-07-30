using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float speed = 1.0f;

    public void Awake()
    {
        if (myRigidbody == null)
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }
    }

	// Use this for initialization
	void Start ()
	{
	    myRigidbody.velocity = Vector2.up * speed;
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        Destroy(this.gameObject);
    }
	
}
