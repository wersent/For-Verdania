using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class AllyMenuInfo : MonoBehaviour, ISelectable
{
    public AllyPlacementMenuInfo aPMI;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnClick()
    {
        aPMI = GetComponent<AllyPlacementMenuInfo>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
