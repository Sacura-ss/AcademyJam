using System.Collections.Generic;
using UnityEngine;

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
            transform.position = position;
        }
    }
}