using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class energyPointController : MonoBehaviour
{
    public List<SpriteRenderer> Epoints = new List<SpriteRenderer>();
    public TMP_Text EnPointsLeft;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (SpriteRenderer tr in GetComponentsInChildren<SpriteRenderer>())
        {
            Epoints.Add(tr);
        }
        EnPointsLeft.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (SpriteRenderer tr in Epoints)
        {
            if (tr.color == Color.red)
            {
                count += 1;
                EnPointsLeft.text = count.ToString();
            }
        }
        EnPointsLeft.text = count.ToString();
        count = 0;
    }
}
