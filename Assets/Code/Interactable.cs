using UnityEngine;
using UnityEngine.EventSystems;

namespace Code
{
    public class Interactable : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private bool collectible;

        private GameSessionManager _gameSessionManager;

        private void Awake()
        {
            _gameSessionManager = FindObjectsByType<GameSessionManager>(FindObjectsSortMode.None)[0];
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"{gameObject.name} clicked!");
            OnClicked();
        }
        
        private void OnClicked()
        {
            Debug.Log("OnClicked");

            if (collectible)
            {
                _gameSessionManager.Inventory.AddItem(this);
            }
        }
        
        private void OnUsed()
        {
            Debug.Log("OnUsed");
            
            _gameSessionManager.Inventory.RemoveItem(this);
        }
    }
}
