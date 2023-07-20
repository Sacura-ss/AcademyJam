using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

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

    }
}