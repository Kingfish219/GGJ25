using Mohammad.Code;
using PipeMiniGame;
using UnityEngine;

public class CheckONload : MonoBehaviour
{
    private GameObject persistentObject;
    [SerializeField] private GridFlow gridFlow;
    [SerializeField] private string targetItemName;
    private bool findObj;

    private void Start()
    {
        findObj = false;
        // Find the persistent object in the scene
        persistentObject = GameObject.Find("GameSession");

        if (persistentObject != null)
        {
            // Get all InventorySlot components in the children of persistentObject
            InventorySlot[] inventorySlots = persistentObject.GetComponentsInChildren<InventorySlot>();
            Debug.Log(inventorySlots.Length);

            // Iterate through all InventorySlot components
            foreach (InventorySlot slot in inventorySlots)
            {
                if (slot.ObjectName == targetItemName)
                {
                    Debug.Log("Found matching item in InventorySlot: " + slot.gameObject.name);
                    findObj = true;
                } 
            }
            if (!findObj)
            {
                gridFlow.DisablePersistentObject();
                gameObject.SetActive(false);
            }
            else
            {
                gridFlow.DisablePersistentObject();
            }

        }
        else
        {
            gridFlow.DisablePersistentObject();
            Debug.LogWarning("GameSession object not found!");
        }
    }
}
