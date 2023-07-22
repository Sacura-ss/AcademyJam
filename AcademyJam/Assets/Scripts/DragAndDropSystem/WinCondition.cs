using UnityEngine;

namespace DragAndDropSystem
{
    public class WinCondition : MonoBehaviour
    {
        [SerializeField] private WinPanel _winPanel;
        [SerializeField] private GameObject _vfxEffect;
        
        private DropSlotContainer _dropSlotContainer;

        private void Start()
        {
            _dropSlotContainer = FindObjectOfType<DropSlotContainer>();
            foreach (var dropSlot in _dropSlotContainer.GetDropSlots())
            {
                dropSlot.Dropped += CheckForWin;
            }
        }
        
        private void OnDisable()
        {
            foreach (var slot in _dropSlotContainer.GetDropSlots())
            {
                slot.Dropped -= CheckForWin;
            }
        }
        
        private void CheckForWin()
        {
            if (_dropSlotContainer.IsAllSlotsFilled())
            {
                WinProcess();
            }
        }
        
        private void WinProcess()
        {
            Debug.Log("WINNER");
            _vfxEffect.SetActive(true);
            _winPanel.gameObject.SetActive(true);
        }
    }
}
