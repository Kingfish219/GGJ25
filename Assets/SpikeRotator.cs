using UnityEngine;

public class SpikeRotator : MonoBehaviour
{
    // Speed of rotation in degrees per second
    public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its local Y-axis
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
