using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class Inventory
    {
        private readonly Dictionary<string, Interactable> _items = new Dictionary<string, Interactable>();
        private readonly Image[] _inventorySlots;

        public Inventory(Image[] inventorySlots)
        {
            _inventorySlots = inventorySlots;
        }
        
        public void AddItem(Interactable item)
        {
            Debug.Log($"Added {item.name} to inventory!");
            if (_items.ContainsKey(item.name))
            {
                return;
            }
            
            _items.Add(item.name, item);
            _inventorySlots[_items.Count - 1].sprite = item.GetComponent<SpriteRenderer>().sprite;
            Object.Destroy(item.gameObject);
        }
        
        public void RemoveItem(Interactable item)
        {
            Debug.Log($"Removed {item.name} from inventory!");
            if (!_items.ContainsKey(item.name))
            {
                return;
            }
            
            _items.Remove(item.name);
            _inventorySlots[_items.Count].sprite = null;
        }
    }
}