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
    private Vector2 firstPoint;
    public string color;
    private bool energyPointearned = false;
    private string StartPlata;
    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        PointsEarned = NumberOfPoints;
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
    void DisplayInfo(float dist, int pointsEarned)
    {
        distText.text = Alldist.ToString("F2");
        pointsText.text = PointsEarned.ToString();
    }
    void ClearBoard()
    {
        points.Clear();
        Alldist = 0f;
        PointsEarned = NumberOfPoints;
        first_pointed = false;
        energyPointearned = false;
        DisplayInfo(Alldist, PointsEarned);
        SetupLine();
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
                if (hit.collider.gameObject.CompareTag(color) && first_pointed == false)
                {
                    first_pointed = true;
                    lastWorldPoint = worldPoint;
                    firstPoint = worldPoint;
                    makeline(hit.collider.transform);
                    StartPlata = hit.collider.gameObject.transform.parent.name;
                }
                else if (first_pointed == true && (hit.collider.gameObject.CompareTag("dot") || hit.collider.gameObject.CompareTag("energy")))
                {
                    Debug.Log(hit.collider.gameObject.CompareTag("energy"));
                    if (hit.collider.gameObject.CompareTag("energy"))
                    {
                        energyPointearned = true;
                        Debug.Log("Hellooooooooo");
                    }
                    if (points.Contains(hit.collider.transform))
                    {
                        ClearBoard();
                        return;
                    }
                    Debug.Log("Hello");
                    makeline(hit.collider.transform);
                    PointsEarned--;
                    dist  = (worldPoint - lastWorldPoint).magnitude;
                    lastWorldPoint = worldPoint;
                    Alldist += dist;
                    DisplayInfo(Alldist, PointsEarned);
                }
                
                if (hit.collider.gameObject.CompareTag(color) && first_pointed == true && worldPoint != firstPoint)
                {
                    PointsEarned--;
                    if (PointsEarned == 0 && energyPointearned && StartPlata != hit.collider.gameObject.transform.parent.name)
                    {
                        makeline(hit.collider.transform);
                        dist  = (worldPoint - lastWorldPoint).magnitude;
                        Alldist += dist;
                        lastWorldPoint = worldPoint;
                        DisplayInfo(dist, PointsEarned);
                        Destroy(this);
                        Debug.Log("WIN!!");
                    }
                    else
                        ClearBoard();
                }

                if (!hit.collider.gameObject.CompareTag(color) && !hit.collider.gameObject.CompareTag("dot") && !hit.collider.gameObject.CompareTag("energy"))
                {
                    ClearBoard();
                }

                
            }
        }
    }
}
