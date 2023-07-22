using System;
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
                    dropSlot.Dropped += CheckForWin;
                }
            }
        }

        private void OnDisable()
        {
            foreach (var slot in _dropSlots)
            {
                slot.Dropped -= CheckForWin;
            }
        }

        private void CheckForWin()
        {
            if (IsAllSlotsFilled())
            {
                WinProcess();
            }
        }

        private void WinProcess()
        {
            Debug.Log("WINNER");
        }

        private bool IsAllSlotsFilled()
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
    }
}