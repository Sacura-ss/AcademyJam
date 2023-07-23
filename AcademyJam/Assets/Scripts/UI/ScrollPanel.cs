using DragAndDropSystem;
using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class ScrollPanel : MonoBehaviour, IDropHandler
    {
        private const float SCALE_NUMBER = 2;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent(out DragAndDropContainer t))
            {
                var layout = GetComponentInChildren<VerticalLayoutGroup>();
                if (layout != null)
                {
                    Service.SetNewParent(eventData.pointerDrag.gameObject, layout.gameObject);
                }

                var localScale = eventData.pointerDrag.transform.localScale;
                eventData.pointerDrag.transform.localScale = localScale / SCALE_NUMBER;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponentInParent<ScrollPanel>() != null)
            {
                if (other.TryGetComponent(out DragAndDropContainer dragAndDropContainer))
                {
                    TrySetCanvasAsParent(other.transform);
                    var localScale = other.transform.localScale;
                    other.transform.localScale = localScale * SCALE_NUMBER;
                }
            }
        }

        private void TrySetCanvasAsParent(Transform target)
        {
            if (target.transform.parent.TryGetComponent(out Canvas c))
                return;

            var canvas = target.GetComponentInParent<Canvas>();
            if (canvas == null)
                return;

            Service.SetNewParent(target.gameObject, canvas.gameObject);
        }
    }
}