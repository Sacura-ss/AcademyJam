using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DragAndDropSystem
{
    public class DragAndDropContainer : MonoBehaviour, IPointerDownHandler
    {
        private List<DragAndDropUnit> _units = new();

        private void Awake()
        {
            foreach (Transform child in transform)
            {
                if (child.TryGetComponent(out DragAndDropUnit dragAndDropUnit))
                {
                    _units.Add(dragAndDropUnit);
                }
            }
        }

        public void PivotTo(Vector3 position)
        {
            Vector3 offset = transform.position - position;
            foreach (Transform child in transform)
                child.transform.position += offset;
            transform.position = position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("GGGGGGGGG");
            transform.Rotate(0, 0, 90);
        }
    }
}