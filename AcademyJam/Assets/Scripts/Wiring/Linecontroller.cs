using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Linecontroller : MonoBehaviour
{
    private LineRenderer lr;
    public List<Vector3> points = new List<Vector3>();
    public Vector3 lastPoints;
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
    public float maxPieceLen;
    private int piecesLeft;
    public GameObject EnergyPointController;
    public List<GameObject> EPoints = new List<GameObject>();
    public SpriteRenderer en;
    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRenderer>();


        
    }
    private void makeline(Vector3 finalPoint)
    {
        points.Add(finalPoint);
        points.Add(finalPoint);
        SetupLine();
    }
    private void SetupLine()
    {
        int pointLength = points.Count;
        lr.positionCount = pointLength;
        lr.SetPositions(points.ToArray());
    }
    void DisplayInfo(float dist, int piecesLeft)
    {
        distText.text = Alldist.ToString("F2");
        pointsText.text = piecesLeft.ToString();
    }
    void ClearBoard()
    {
        points.Clear();
        EPoints.Clear();
        Alldist = 0f;
        first_pointed = false;
        energyPointearned = false;
        DisplayInfo(Alldist, piecesLeft);
        SetupLine();
    }
    // Update is called once per frame
    void Update()
    {
        // Follow mouse as a straight line
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        int.TryParse(pointsText.text, out piecesLeft);
        lr.positionCount = points.Count;
        lr.SetPositions(points.ToArray());
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                
                if (hit.collider.gameObject.CompareTag(color) && first_pointed == false) // if is matches the color and is first
                {
                    // create a line and start following mouse
                    first_pointed = true;
                    lastWorldPoint = worldPoint;
                    firstPoint = worldPoint;
                    makeline(hit.collider.transform.position);
                    StartPlata = hit.collider.gameObject.transform.parent.name;
                }
                else if (first_pointed == true && (hit.collider.gameObject.CompareTag("dot") || hit.collider.gameObject.CompareTag("energy")))
                {
                    if (hit.collider.gameObject.CompareTag("energy"))
                    {
                        en = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                        en.color = Color.red;
                        EPoints.Add(hit.collider.gameObject);
                        energyPointearned = true;
                    }
                    if (points.Contains(hit.collider.transform.position))
                    {
                        ClearBoard();
                        return;
                    }
                    dist  = (worldPoint - lastWorldPoint).magnitude;
                    if (dist <= maxPieceLen)
                    {
                        makeline(hit.collider.transform.position);
                        lastWorldPoint = worldPoint;
                        Alldist += dist;
                        DisplayInfo(Alldist, piecesLeft);
                    }
                    
                }

                if (hit.collider.gameObject.CompareTag(color) && first_pointed == true && worldPoint != firstPoint)
                {
                    if (energyPointearned && StartPlata != hit.collider.gameObject.transform.parent.name)
                    {
                        makeline(hit.collider.transform.position);
                        dist  = (worldPoint - lastWorldPoint).magnitude;
                        if (dist <= maxPieceLen)
                        {
                            makeline(hit.collider.transform.position);
                            lastWorldPoint = worldPoint;
                            Alldist += dist;
                            DisplayInfo(Alldist, piecesLeft);
                            piecesLeft--;
                            pointsText.text = piecesLeft.ToString();
                            Destroy(this);
                        }
                        
                    }
                    else
                        ClearBoard();
                }
                if (!hit.collider.gameObject.CompareTag(color) && !hit.collider.gameObject.CompareTag("dot") && !hit.collider.gameObject.CompareTag("energy"))
                {
                    foreach (GameObject ep in EPoints)
                    {
                        en = ep.GetComponent<SpriteRenderer>();
                        en.color = Color.yellow;
                    }
                    
                    energyPointearned = false;
                    ClearBoard();
                    
                } 
            }
        }
        
        else if (points.Count > 0)
        {
            points[points.Count - 1] = mousePosition;

        }
    }
}
