using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class AllyMenuInfo : MonoBehaviour, ISelectable
{
    public Placement placementPrefub;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnClick()
    {
        placementPrefub = GetComponent<Placement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
