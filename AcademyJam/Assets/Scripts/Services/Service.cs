using UnityEngine;

namespace Services
{
    public static class Service
    {
        public static void SetNewParent(GameObject target, GameObject newParent)
        {
            target.transform.SetParent(newParent.transform, true);
            target.transform.SetSiblingIndex(3);// SetAsLastSibling();
        }
    }
}