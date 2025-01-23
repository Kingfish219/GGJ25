using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mohammad.Code
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadSceneAsync(string sceneName)
        {
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);

            while (!operation.isDone)
            {
                yield return null;
            }
        }
    }
}
