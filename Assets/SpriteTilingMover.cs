using UnityEngine;

public class SpriteTilingMover : MonoBehaviour
{
    // Speed of the tiling movement
    public float speedX = 0.5f; // Speed along the X-axis
    public float speedY = 0.5f; // Speed along the Y-axis

    // Reference to the Material
    private Material material;

    // Store the current offset
    private Vector2 offset;

    void Start()
    {
        // Get the material of the object
        material = GetComponent<Renderer>().material;

        // Initialize offset
        offset = material.mainTextureOffset;
    }

    void Update()
    {
        // Update the offset based on time and speed
        offset.x += speedX * Time.deltaTime;
        offset.y += speedY * Time.deltaTime;

        // Apply the offset back to the material
        material.mainTextureOffset = offset;
    }
}

