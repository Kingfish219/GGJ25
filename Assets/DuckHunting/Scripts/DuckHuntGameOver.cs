using UnityEngine;
using UnityEngine.SceneManagement;

namespace DuckHunting.Scripts
{
    public class DuckHuntGameOver : MonoBehaviour
    {
        public void TryAgain()
        {
            StaticVars.tryAgain = true;
            gameObject.SetActive (false);
            Scene currentScene = SceneManager.GetActiveScene(); // Get current scene
            SceneManager.LoadScene(currentScene.name);          // Reload by name

        }
    }
}