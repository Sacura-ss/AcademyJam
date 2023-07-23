using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

namespace DragAndDropSystem
{
    public class DragAndDropUnit : MonoBehaviour, IPointerDownHandler
    {
        public int ID { private set; get; }

        private void Awake()
        {
            ID = Random.Range(0, 1000);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (transform.parent.TryGetComponent(out DragAndDropContainer dragAndDropContainer))
            {
                //dragAndDropContainer.PivotTo(transform.position);
            }
        }
    }
}