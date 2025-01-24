using System;
using System.Collections;
using System.Linq;
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
            if (sceneName == "Level 1")
            {
                HandleLevel1();
            }
            var operation = SceneManager.LoadSceneAsync(sceneName);

            while (!operation.isDone)
            {
                yield return null;
            }
        }

        public static void HandleLevel1()
        {
            if(!LevelData.ToiletLevel)
            {
                return;
            }
            
            var gameSessionManager = FindObjectsByType<GameSessionManager>(FindObjectsSortMode.None)[0];
            var interactable = gameSessionManager.inventorySlots
                .First(x=>x.ObjectName.Equals("glass", StringComparison.InvariantCultureIgnoreCase))
                .item;
            gameSessionManager.Inventory.RemoveItem(interactable);
            var key = FindObjectsByType
                    <Interactable>(FindObjectsSortMode.None)
                .FirstOrDefault(x => x.name == "FilledGlass");
            gameSessionManager.Inventory.AddItem(key);
        }
    }
}
