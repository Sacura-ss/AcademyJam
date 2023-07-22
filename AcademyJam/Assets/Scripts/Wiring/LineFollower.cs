using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class LineFollower : MonoBehaviour
{
    public GameObject pointPrefab;
    private GameObject point;
    
    private LineRenderer lineRenderer;
    private List<Vector3> points;
    private bool mouseClick;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        points = new List<Vector3>();

        mouseClick = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            if (!mouseClick)
            {
                point = Instantiate(pointPrefab, mousePosition, Quaternion.identity);
                mouseClick = true;
            }

            UpdateLine(mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Destroy(point);
            mouseClick = false;
        }
    }

    private void UpdateLine(Vector3 newPoint)
    {
        if (points.Count == 0 || points[points.Count-1] != newPoint)
        {
            points.Add(newPoint);
            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());
        }
    }
    private void CreateDot(Vector3 Point)
    {

    }
}