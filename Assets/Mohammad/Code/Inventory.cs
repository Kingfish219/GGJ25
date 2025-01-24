using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Mohammad.Code
{
    public class Inventory
    {
        private readonly Dictionary<string, Interactable> _items = new Dictionary<string, Interactable>();
        private readonly List<InventorySlot> _inventorySlots;

        public Inventory(IEnumerable<InventorySlot> inventorySlots)
        {
            _inventorySlots = inventorySlots.OrderBy(i => i.name).ToList();
        }

        public void AddItem(Interactable item)
        {
            Debug.Log($"Added {item.name} to inventory!");
            if (_items.ContainsKey(item.name))
            {
                return;
            }

            _items.Add(item.name, item);
            var slotImage = _inventorySlots[_items.Count - 1].slotImage;
            slotImage.sprite = item.itemIcon;
            slotImage.color = new Color(1, 1, 1, 1f);
            _inventorySlots[_items.Count - 1].item = item;
            _inventorySlots[_items.Count - 1].ObjectName = item.name;

            if (item.movable)
            {
                item.gameObject.SetActive(false);
            }
        }

        public void RemoveItem(Interactable item)
        {
            Debug.Log($"Removed {item.name} from inventory!");
            if (!_items.ContainsKey(item.name))
            {
                return;
            }

            _items.Remove(item.name);
            _inventorySlots.Where(i => i.item is not null)
                .SingleOrDefault(i => i.item.gameObject.name == item.name)!
                .slotImage.sprite = null;
            _inventorySlots.Where(i => i.item is not null)
                .SingleOrDefault(i => i.item.gameObject.name == item.name)!
                .slotImage.color = new Color(1, 1, 1, 0f);;
            _inventorySlots.Where(i => i.item is not null)
                .SingleOrDefault(i => i.item.gameObject.name == item.name)!
                .item = null;
        }
    }
}