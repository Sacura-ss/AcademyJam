using DragAndDropSystem;
using UnityEngine;
using UnityEngine.UI;

public class ScrollPanel : MonoBehaviour
{
    private const float SCALE_NUMBER = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out DragAndDropContainer t))
        {
            var layout = GetComponentInChildren<VerticalLayoutGroup>();
            if (layout != null)
            {
                Service.SetNewParent(other.gameObject, layout.gameObject);
            }

            var localScale = other.transform.localScale;
            other.transform.localScale = localScale / SCALE_NUMBER;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out DragAndDropContainer dragAndDropContainer))
        {
            TrySetCanvasAsParent(other.transform);
            var localScale = other.transform.localScale;
            other.transform.localScale = localScale * SCALE_NUMBER;
        }
    }

    private void TrySetCanvasAsParent(Transform target)
    {
        if (target.transform.parent.TryGetComponent(out Canvas c))
            return;

        var canvas = target.GetComponentInParent<Canvas>();
        if (canvas == null)
            return;

        Service.SetNewParent(target.gameObject, canvas.gameObject);
    }
}