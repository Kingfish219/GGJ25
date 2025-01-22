using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class GameSessionManager : MonoBehaviour
    {
        public Inventory Inventory { get; private set; }
        [SerializeField] private Image[] inventorySlots;
        
        private void Awake()
        {
            var numberGameSessions = FindObjectsByType(gameObject.GetType(), FindObjectsSortMode.None).Length;
            if (numberGameSessions > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
            
            Inventory = new Inventory(inventorySlots);
        }
    }
}