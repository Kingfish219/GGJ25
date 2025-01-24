using System;
using System.Linq;
using UnityEngine;

namespace Mohammad.Code
{
    public class Interactions : MonoBehaviour
    {
        public void UseCheese(Interactable interactable, object obj = null)
        {
            Debug.Log("Cheese used!");

            if (obj is not Interactable collided ||
                !interactable.gameObject.name.Equals("Cheese", StringComparison.InvariantCultureIgnoreCase) ||
                !collided.CurrentState.Equals("shown", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            var gameSessionManager = FindObjectsByType<GameSessionManager>(FindObjectsSortMode.None)[0];

            var key = FindObjectsByType
                <Interactable>(FindObjectsSortMode.None)
                .FirstOrDefault(x => x.name == "Key");
            gameSessionManager.Inventory.AddItem(key);
            gameSessionManager.Inventory.RemoveItem(interactable);
        }
        
        public void UseKey(Interactable interactable, object obj = null)
        {
            Debug.Log("Key used!");

            if (!interactable.gameObject.name.Equals("key", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            var gameSessionManager = FindObjectsByType<GameSessionManager>(FindObjectsSortMode.None)[0];
            gameSessionManager.Inventory.RemoveItem(interactable);
            var sceneLoader = FindObjectsByType<SceneLoader>(FindObjectsSortMode.None)[0];
            sceneLoader.LoadSceneAsync("PipeMiniIGame");
        }
    }
}