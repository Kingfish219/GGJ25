using UnityEngine;

public class RandomHight : MonoBehaviour
{

    private int randomHightInt;
    [SerializeField] int highRange;
    [SerializeField] int lowRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomHightInt = Random.Range(lowRange, highRange);
        gameObject.GetComponent<SpriteRenderer>().size= new Vector2(1.72f,1.04f*randomHightInt);
    }


}
