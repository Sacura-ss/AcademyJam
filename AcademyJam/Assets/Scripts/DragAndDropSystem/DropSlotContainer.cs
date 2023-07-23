using System.Collections.Generic;
using UnityEngine;

namespace DragAndDropSystem
{
    public class DropSlotContainer : MonoBehaviour
    {
        private List<DropSlot> _dropSlots = new();

        private void Awake()
        {
            foreach (Transform child in transform)
            {
                if (child.TryGetComponent(out DropSlot dropSlot))
                {
                    _dropSlots.Add(dropSlot);
                }
            }
        }

        public bool IsAllSlotsFilled()
        {
            foreach (var slots in _dropSlots)
            {
                if (slots.IsEmpty)
                {
                    return false;
                }
            }

            return true;
        }

        public List<DropSlot> GetDropSlots()
        {
            return _dropSlots;
        }
    }
}