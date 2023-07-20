using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyPoint : MonoBehaviour
{
    public TMP_Text EnergyText;
    private Vector3 scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
    public GameObject energyPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMouseEnter()
    {
        energyPoint.transform.localScale += scaleChange;
        EnergyText.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void OnMouseExit()
    {
        energyPoint.transform.localScale -= scaleChange;
        EnergyText.gameObject.SetActive(false);

    }
}
