using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Linecontroller : MonoBehaviour
{
    private LineRenderer lr;
    public List<Transform> points = new List<Transform>();
    public Transform lastPoints;
    private bool first_pointed = false;
    public int NumberOfPoints;
    private int PointsEarned;
    public TMP_Text pointsText;
    public TMP_Text distText;
    public TMP_Text winText;
    private float dist = 0f;
    private float Alldist = 0f;
    private Vector2 lastWorldPoint;
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
                    
                    lastWorldPoint = worldPoint;
                    distText.text = Alldist.ToString("F2") + PointsEarned;
                    makeline(hit.collider.transform);
                    pointsText.text = PointsEarned + " Pieces used";
                }
                else if (first_pointed == true)
                {
                    if (points.Contains(hit.collider.transform))
                    {
                        Debug.Log("Already Was");
                        points.Clear();
                        first_pointed = false;
                        Debug.Log("Again");
                        Alldist = 0f;
                        PointsEarned = 0;
                        distText.text = Alldist.ToString("F2") + PointsEarned;
                        pointsText.text = PointsEarned + " Pieces Used";
                        SetupLine();
                        return;

                    }
                     makeline(hit.collider.transform);
                     PointsEarned++;
                     dist  = (worldPoint - lastWorldPoint).magnitude;
                    lastWorldPoint = worldPoint;
                    Alldist+=dist;
                    distText.text = Alldist.ToString("F2") + PointsEarned;
                    pointsText.text = PointsEarned + " Pieces Used";
                }
                if (hit.collider.gameObject.CompareTag("last_dot") && first_pointed == true)
                {
                    if (PointsEarned == NumberOfPoints - 1)
                    {
                        dist  = (worldPoint - lastWorldPoint).magnitude;
                        Alldist += dist;
                        lastWorldPoint = worldPoint;
                        distText.text = Alldist.ToString("F2");
                        winText.text = "WIN!";
                        Debug.Log("WIN!!");
                    }
                    else
                    {
                        points.Clear();
                        Alldist = 0f;
                        distText.text = Alldist.ToString("F2");
                        first_pointed = false;
                        PointsEarned = 0;
                        Debug.Log("Again");

                        pointsText.text = PointsEarned + "Pieces Used";
                        SetupLine();
                    }
                }

                
            }
        }
    }
}
