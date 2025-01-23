using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Mohammad.Code
{
    public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Image slotImage;
        public Interactable item;

        private GameObject _shadowImage;
        private Canvas _canvas;
        private RectTransform _canvasRectTransform;

        private void Awake()
        {
            _canvas = GetComponentInParent<Canvas>();
            if (_canvas != null)
            {
                _canvasRectTransform = _canvas.GetComponent<RectTransform>();
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (slotImage.sprite == null)
            {
                return;
            }

            _shadowImage = new GameObject("ShadowImage", typeof(Image));
            _shadowImage.transform.SetParent(_canvas.transform, false);

            var imageComponent = _shadowImage.GetComponent<Image>();
            imageComponent.sprite = slotImage.sprite;
            imageComponent.color = new Color(1, 1, 1, 0.5f);
            imageComponent.raycastTarget = false; 
            
            var shadowRectTransform = _shadowImage.GetComponent<RectTransform>();
            var slotRectTransform = slotImage.GetComponent<RectTransform>();

            var sizeMultiplier = 0.1f;
            shadowRectTransform.sizeDelta = new Vector2(
                slotImage.sprite.rect.width * sizeMultiplier,
                slotImage.sprite.rect.height * sizeMultiplier
            );

            shadowRectTransform.pivot = slotRectTransform.pivot;
            shadowRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            shadowRectTransform.anchorMax = new Vector2(0.5f, 0.5f);

            UpdateShadowPosition(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_shadowImage == null)
            {
                return;
            }
            
            UpdateShadowPosition(Input.mousePosition);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_shadowImage is null)
            {
                return;
            }
            
            DetectCollision(eventData.position);
            Destroy(_shadowImage);
            _shadowImage = null;
        }

        private void DetectCollision(Vector3 mousePosition)
        {
            var pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = mousePosition
            };

            var raycastResults = new System.Collections.Generic.List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);

            foreach (var result in raycastResults)
            {
                var interactable = result.gameObject.GetComponent<Interactable>();
                if (interactable is null)
                {
                    continue;
                }

                Debug.Log($"Collided with Interactable: {result.gameObject.name}");
                item.Interact(interactable);
            }
        }
        
        private void UpdateShadowPosition(Vector3 mousePosition)
        {
            if (_canvas == null || _canvas.renderMode != RenderMode.ScreenSpaceOverlay)
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _canvasRectTransform,
                    mousePosition,
                    _canvas.worldCamera,
                    out Vector2 localPoint
                );
                _shadowImage.GetComponent<RectTransform>().localPosition = localPoint;
            }
            else
            {
                _shadowImage.GetComponent<RectTransform>().position = mousePosition;
            }
        }
    }
}