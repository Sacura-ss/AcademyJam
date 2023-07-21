using UnityEngine;
using UnityEngine.EventSystems;

namespace DragAndDropSystem
{
    public class Rotation : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            transform.Rotate(0, 0, 90, Space.World);
        }
    }
}