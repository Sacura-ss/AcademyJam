using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DragAndDropSystem
{
    public class DropSlot : MonoBehaviour, IDropHandler
    {
        private GameObject _droppedGameObject = null;
        public bool IsEmpty { set; get; } = true;

        public event Action Dropped;

        public void OnDrop(PointerEventData eventData)
        {
            //Debug.Log("drop item");
            if (eventData.pointerDrag != null)
            {
                // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                //     GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.transform.position = transform.position;
                Dropped?.Invoke();
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_droppedGameObject == null)
            {
                var dragUnit = other.GetComponent<DragAndDropUnit>();
                if (dragUnit == null) return;
                IsEmpty = false;
                _droppedGameObject = other.gameObject;
                Fade(0.2f);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_droppedGameObject != null)
            {
                var dragUnit = other.GetComponent<DragAndDropUnit>();
                if (dragUnit == null || dragUnit.ID != _droppedGameObject.GetComponent<DragAndDropUnit>().ID) return;
                IsEmpty = true;
                _droppedGameObject = null;
                Fade(1.0f);
            }
        }

        private void Fade(float alpha)
        {
            if (TryGetComponent(out CanvasGroup canvasGroup))
            {
                canvasGroup.alpha = alpha;
            }
        }
    }
}