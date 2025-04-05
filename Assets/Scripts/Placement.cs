using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Placement : MonoBehaviour
{
    public AllyMenuInfo menuInfo;

    void Start()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Canvas" && !obj.activeInHierarchy)
            {
                menuInfo = obj.GetComponent<AllyMenuInfo>();
                break;
            }
        }
    }

    public void OnMouseDown()
    {
        menuInfo.gameObject.SetActive(true);
        if (menuInfo.gameObject.TryGetComponent<ISelectable>(out var selectable)) { selectable.OnClick(); menuInfo.aPMI = this; }
    }

    void FixedUpdate()
    {

    }
}
