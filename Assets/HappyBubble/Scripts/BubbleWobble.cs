using UnityEngine;

public class BubbleWobble : MonoBehaviour
{
    [Header("Wobble Settings")]
    public float wobbleSpeed = 2f; // Speed of the wobble
    public float wobbleAmount = 0.1f; // Amplitude of the wobble

    private Vector3 originalScale;

    void Start()
    {
        // Store the original scale of the bubble
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Calculate the wobble factor using a sine wave
        float wobbleX = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
        float wobbleY = Mathf.Cos(Time.time * wobbleSpeed) * wobbleAmount;

        // Apply the wobble effect to the scale
        transform.localScale = new Vector3(
            originalScale.x + wobbleX,
            originalScale.y + wobbleY,
            originalScale.z
        );
    }
}
