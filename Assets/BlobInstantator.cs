using UnityEngine;

public class BlobInstantator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject BOB;
    
    public void OnMouseDown()
    {
        Vector3 randomPosition = new Vector3(Random.Range(0f, 0f), Random.Range(-10f, 10f), 0f);
        Quaternion rotation = Quaternion.identity; // No rotation

        Instantiate(BOB, randomPosition, rotation);
    }
}
