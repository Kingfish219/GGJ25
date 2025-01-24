using UnityEngine;
using TMPro;

public class ScoreUpdator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_TextMeshPro;
    [SerializeField] public int goalScore;
    public int m_Score;

    private void Start()
    {
        m_Score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Trap"))
        {
            m_Score++;
            Debug.Log(m_Score);
            m_TextMeshPro.text = "Score " + m_Score.ToString() + "/" + goalScore.ToString();
        }
    }
}
