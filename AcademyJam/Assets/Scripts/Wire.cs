using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    Vector3 startPoint;
    public SpriteRenderer Wire_end;
    Vector3 startPosition;
    public GameObject Light;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
         UpdateWire(newPosition);
         Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
         foreach (Collider2D collider in colliders)
         {
             if (collider.gameObject != gameObject)
             {
                 UpdateWire(collider.transform.position);
                 if (transform.parent.name.Equals(collider.transform.parent.name))
                 {
                     collider.GetComponent<Wire>()?.Done();
                     Done();
                 }
             }

             return;
         }
    }
    private void OnMouseUp()
    {
        UpdateWire(startPosition);
    }
    void Done()
    {
        Light.SetActive(true);
        Destroy(this);
    }
    void UpdateWire(Vector3 newPosition)
    {
        transform.position = newPosition;
        // new direction
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;
        float dist = Vector2.Distance(startPoint, newPosition) *2;
        Wire_end.size = new Vector2(dist, Wire_end.size.y); 
    }
    void Update()
    {
        
    }
}
