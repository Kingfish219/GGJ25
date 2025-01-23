using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float sizeIncreaseSpeed = 2f; // How fast the bubble grows
    public float riseSpeed = 5f;        // How fast the bubble rises
    public float shrinkSpeed = 2f;      // How fast the bubble shrinks
    public float fallSpeed = 3f;        // How fast the bubble falls

    private Vector3 originalScale;      // Store the original size of the bubble
    private Rigidbody2D rb;

    void Start()
    {
        originalScale = transform.localScale; // Save the original size
        rb = GetComponent<Rigidbody2D>();    // Get the Rigidbody2D component
        rb.gravityScale = 0;                 // Disable gravity by default
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // If the left mouse button is held
        {
            // Grow the bubble
            transform.localScale += Vector3.one * sizeIncreaseSpeed * Time.deltaTime;

            // Make the bubble rise
            rb.linearVelocity = new Vector2(0, riseSpeed);
        }
        else
        {
            // Shrink the bubble back to its original size
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, shrinkSpeed * Time.deltaTime);

            // Make the bubble fall
            rb.linearVelocity = new Vector2(0, -fallSpeed);
        }
    }
}
