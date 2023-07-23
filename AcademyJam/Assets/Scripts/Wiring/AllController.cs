using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AllController : MonoBehaviour
{
     public List<GameObject> allObjs = new List<GameObject>();
     public GameObject parent;
     public TMP_Text pointsText;
     private int numOfPoints;
     private int curPoints;
     int i = 1;
     int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        int.TryParse(pointsText.text, out numOfPoints);
        foreach (Transform tr in parent.GetComponentsInChildren<Transform>())
        {
            allObjs.Add(tr.gameObject);
            count++;
        }
        for (int j = 2; j < count; j++)
        {
            allObjs[j].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int.TryParse(pointsText.text, out curPoints);
        if (numOfPoints!=curPoints && i < count - 1)
        {
            numOfPoints-=1;
            Debug.Log("inactivated");
            allObjs[i+1].SetActive(true);
            i++;
        }
    }
}
