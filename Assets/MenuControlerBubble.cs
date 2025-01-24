using Mohammad.Code;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlerBubble : MonoBehaviour
{
    private GameObject persistentObject;
    private void Start()
    {
        persistentObject = GameObject.Find("GameSession");
        if (persistentObject != null)
            persistentObject.SetActive(false);
    }
    public void RestartBubble()
    {
        Time.timeScale = 1f;
        if (persistentObject != null)
            persistentObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void CountinueBubble()
    {
        Time.timeScale = 1f;
        if (persistentObject != null)
            persistentObject.SetActive(true);
        var sceneLoader = FindObjectsByType<SceneLoader>(FindObjectsSortMode.None)[0];
        sceneLoader.LoadSceneAsync("Level 1");
    }
}
