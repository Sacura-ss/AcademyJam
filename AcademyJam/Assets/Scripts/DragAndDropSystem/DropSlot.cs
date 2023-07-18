using UnityEngine;
using UnityEngine.EventSystems;

namespace DragAndDropSystem
{
    public class DropSlot : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("get item");
            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                    this.GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }
}