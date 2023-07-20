using UnityEngine;
using UnityEngine.EventSystems;

namespace DragAndDropSystem
{
    public class DropSlot : MonoBehaviour, IDropHandler
    {
        private GameObject _droppedGameObject = null;
        public bool IsEmpty { set; get; } = true;

        public bool _isEmpty = true;

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("get item");
            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                    this.GetComponent<RectTransform>().anchoredPosition;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_droppedGameObject == null)
            {
                IsEmpty = false;
                _isEmpty = false;
                _droppedGameObject = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_droppedGameObject != null)
            {
                if (other.GetComponent<DragAndDropUnit>().ID == _droppedGameObject.GetComponent<DragAndDropUnit>().ID)
                {
                    IsEmpty = true;
                    _isEmpty = true;
                    _droppedGameObject = null;
                }
            }
            
        }
    }
}