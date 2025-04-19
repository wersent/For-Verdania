using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Placement : MonoBehaviour, ISelectable
{
    public AllyMenuInfo _allyMenuInfo;
    public UnitRegiment _unitRegiment;

    void Start()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Menu Info" && !obj.activeInHierarchy)
            {
                _allyMenuInfo = obj.GetComponent<AllyMenuInfo>();
                break;
            }
        }
    }

    public void SwitchPosition(Placement placement)
    {
        placement._unitRegiment = _unitRegiment;
        _unitRegiment = null;
    }

    public void OnClick()
    {
        _allyMenuInfo.gameObject.SetActive(true);
        if (_allyMenuInfo.gameObject.TryGetComponent<ISelectable>(out var selectable)) { selectable.OnClick(); _allyMenuInfo.placementPrefub = this; }
    }

    void FixedUpdate()
    {

    }
}
