using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DragAndDropSystem
{
    public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private RectTransform _rectTransform;
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //Debug.Log("begin drag");
            _canvasGroup.blocksRaycasts = false;

            TrySetCanvasAsParent();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //Debug.Log("end drag");
            _canvasGroup.blocksRaycasts = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        private void TrySetCanvasAsParent()
        {
            if (transform.parent.TryGetComponent(out Canvas c))
                return;

            var canvas = GetComponentInParent<Canvas>();
            if (canvas == null)
                return;

            SetAsParent(canvas.gameObject);
        }

        private void SetAsParent(GameObject newParent)
        {
            transform.SetParent(newParent.transform, true);
            transform.SetAsLastSibling();
        }
    }
}