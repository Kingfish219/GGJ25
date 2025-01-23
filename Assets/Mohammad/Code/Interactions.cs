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
                interactable.gameObject.name != "Cheese" ||
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
    }
}