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
            
            
            SceneLoader.HandleLevel1();
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
        
        public static void UseFilledGlass(Interactable interactable, object obj = null)
        {
            Debug.Log("UseFilledGlass");

            if (!interactable.gameObject.name.Equals("FilledGlass", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            var gameSessionManager = FindObjectsByType<GameSessionManager>(FindObjectsSortMode.None)[0];
            gameSessionManager.Inventory.RemoveItem(interactable);
            GameObject targetObject = GameObject.Find("Aqua");
            GameObject sourceObject = GameObject.Find("FilledTank");

            if (targetObject != null && sourceObject != null)
            {
                // Get the SpriteRenderer components
                SpriteRenderer targetRenderer = targetObject.GetComponent<SpriteRenderer>();
                SpriteRenderer sourceRenderer = sourceObject.GetComponent<SpriteRenderer>();

                if (targetRenderer != null && sourceRenderer != null)
                {
                    // Copy the sprite from the source to the target
                    targetRenderer.sprite = sourceRenderer.sprite;
                    Debug.Log("Sprite copied successfully!");
                }
                else
                {
                    Debug.LogError("SpriteRenderer not found on one of the objects!");
                }
            }
            else
            {
                Debug.LogError("Target or Source object not found!");
            }
        }
    }
}