using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace DragAndDropSystem
{
    public class DragAndDropContainer : MonoBehaviour
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
            //SaveImagePosition(offset);
            transform.position = position;
        }

        private void SaveImagePosition(Vector3 offset)
        {
            RawImage rawImage = GetComponent<RawImage>();
            if(rawImage != null)
            {
                Debug.Log("hhh " + offset);
                var rawImageUVRect = rawImage.uvRect;
                rawImageUVRect.x += 0.5f;
                rawImageUVRect.y += 0.5f;
            }
        }
    }
}