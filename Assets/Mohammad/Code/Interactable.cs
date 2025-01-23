using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Mohammad.Code
{
    public class Interactable : MonoBehaviour, IPointerClickHandler
    {
        private GameSessionManager _gameSessionManager;
        
        [SerializeField] private bool collectible;
        [SerializeField] public bool movable = true;
        [SerializeField] private UnityEvent<Interactable, object> interaction;
        public Sprite itemIcon;

        public string CurrentState { get; private set; } = "default";

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

        public void Interact(object obj = null)
        {
            interaction.Invoke(this, obj);
        }
        
        public void SetState(string state)
        {
            CurrentState = state;
        }
    }
}
