using UnityEngine;

public class ScrollPanel : MonoBehaviour
{
    private const float SCALE_NUMBER = 2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.TryGetComponent(out DragAndDropContainer t))
        // {
        //     var localScale = other.transform.localScale;
        //     other.transform.localScale = localScale / SCALE_NUMBER;
        // }
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     // if (other.TryGetComponent(out DragAndDropContainer t))
    //     // {
    //     //     var localScale = other.transform.localScale;
    //     //     other.transform.localScale = localScale * SCALE_NUMBER;
    //     // }
    //     other.transform.parent = GetComponentInParent<Canvas>().transform;
    // }
}
