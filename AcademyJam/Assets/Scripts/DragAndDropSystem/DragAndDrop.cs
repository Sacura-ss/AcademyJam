using UnityEngine;
using UnityEngine.EventSystems;

namespace DragAndDropSystem
{
    public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
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

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("down");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("begin drag");
            _canvasGroup.blocksRaycasts = false;
            
            var canvas = FindInParents<Canvas>(gameObject);
            if (canvas == null)
                return;
            
            transform.SetParent(canvas.transform, true);
            transform.SetAsLastSibling();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("end drag");
            _canvasGroup.blocksRaycasts = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }
        
        static public T FindInParents<T>(GameObject go) where T : Component
        {
            if (go == null) return null;
            var comp = go.GetComponent<T>();

            if (comp != null)
                return comp;

            Transform t = go.transform.parent;
            while (t != null && comp == null)
            {
                comp = t.gameObject.GetComponent<T>();
                t = t.parent;
            }
            return comp;
        }
    }
}