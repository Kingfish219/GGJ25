using UnityEngine;

namespace Mohammad.Code
{
    public class GameSessionManager : MonoBehaviour
    {
        public Inventory Inventory { get; private set; }
        [SerializeField] private InventorySlot[] inventorySlots;
        
        private void Awake()
        {
            var numberGameSessions = FindObjectsByType<GameSessionManager>(FindObjectsSortMode.None).Length;
            if (numberGameSessions > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }

            inventorySlots = FindObjectsByType<InventorySlot>(FindObjectsSortMode.InstanceID);
            
            Inventory = new Inventory(inventorySlots);
        }
    }
}