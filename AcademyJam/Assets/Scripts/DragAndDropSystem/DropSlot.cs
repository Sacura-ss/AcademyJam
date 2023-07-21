using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DragAndDropSystem
{
    public class DropSlot : MonoBehaviour, IDropHandler
    {
        private GameObject _droppedGameObject = null;
        public bool IsEmpty { set; get; } = true;

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("get item");
            if (eventData.pointerDrag != null)
            {
                // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                //     GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.transform.position = transform.position;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_droppedGameObject == null)
            {
                IsEmpty = false;
                _droppedGameObject = other.gameObject;
                Fade(0.2f);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_droppedGameObject != null)
            {
                if (other.GetComponent<DragAndDropUnit>().ID == _droppedGameObject.GetComponent<DragAndDropUnit>().ID)
                {
                    IsEmpty = true;
                    _droppedGameObject = null;
                    Fade(1.0f);
                }
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