using UnityEngine;
using UnityEngine.EventSystems;

public class RotationStick : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("VAR");
        transform.parent.Rotate(0, 0, 90, Space.World);
    }
}