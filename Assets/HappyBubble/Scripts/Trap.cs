using UnityEngine;

public class Trap : MonoBehaviour
{
    public float speed = 5f; // Speed at which the trap moves
    private Rigidbody2D rb;

    private void Awake()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Ensure the Rigidbody2D uses kinematic movement for traps
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void FixedUpdate()
    {
        // Move the trap to the right by setting its velocity
        rb.linearVelocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
            Debug.Log("Poppppp");
        }
    }
}
