using UnityEngine;
using UnityEngine.EventSystems;

namespace Services
{
    public class Rotation : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            transform.Rotate(0, 0, 90, Space.World);
        }
    }
}