using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linecontroller : MonoBehaviour
{
    private LineRenderer lr;
    public List<Transform> points = new List<Transform>();
    public Transform lastPoints;
    private bool first_pointed = false;
    public int NumberOfPoints;
    private int PointsEarned;
    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    private void makeline(Transform finalPoint)
    {
        if (lastPoints ==null)
        {
            lastPoints = finalPoint;
            points.Add(lastPoints);
            SetupLine();
        }
        else
        {
            points.Add(finalPoint);
            lr.enabled = true;
            SetupLine();
        }
    }
    private void SetupLine()
    {
        int pointLength = points.Count;
        lr.positionCount = pointLength;
        for (int i = 0; i < pointLength; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("first_dot") && first_pointed == false)
                {
                    first_pointed = true;
                    makeline(hit.collider.transform);
                }
                else if (first_pointed == true)
                {
                    if (points.Contains(hit.collider.transform))
                    {
                        Debug.Log("Already Was");
                        return;
                    }
                     makeline(hit.collider.transform);

                }
                PointsEarned++;
                if (hit.collider.gameObject.CompareTag("last_dot") && first_pointed == true)
                {
                    if (PointsEarned == NumberOfPoints)
                    {
                        Debug.Log("WIN!!");
                    }
                    else
                    {
                        points.Clear();
                        first_pointed = false;
                        PointsEarned = 0;
                        Debug.Log("Again");
                    }
                }
                
            }
        }
    }
}
