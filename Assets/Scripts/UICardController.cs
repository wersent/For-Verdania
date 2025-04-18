using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.XR;

public class UICardController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Unit unit;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private Image _image;
    [SerializeField] private UnitRegiment _unitRegiment;
    [SerializeField] private AllyMenuInfo _allyMenuInfo;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        var placementManage = _allyMenuInfo.placementPrefub;
        if (placementManage._unitRegiment == null)
        {
            var newUnitRegiment = Instantiate(_unitRegiment, placementManage.transform);
            newUnitRegiment.Initialize(ref placementManage);
            //newUnitRegiment.transform.position = placementManage.transform.position;
            //placementManage._unitRegiment = newUnitRegiment.GetComponent<UnitRegiment>();
            newUnitRegiment.name = $"Contains: {unit}";
            newUnitRegiment.unitsTypes.Add(unit);
            Debug.Log(newUnitRegiment.name);
            Debug.Log(placementManage.name);
        }
        else if (placementManage._unitRegiment != null)
        {
            placementManage._unitRegiment.unitsTypes.Add(unit);
            placementManage._unitRegiment.name += $" {unit}";
            Debug.Log(placementManage._unitRegiment.name);
            Debug.Log(placementManage.name);
        }
    }

    public void Initialize(Unit unitData)
    {
        unit = unitData;
        _image.sprite = unit.GetIcon();
        _textMeshProUGUI.text = unit.Description;
        _textMeshProUGUI.fontSize = 18;
    }

    void Start()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Menu Info")
            {
                _allyMenuInfo = obj.GetComponent<AllyMenuInfo>();
                break;
            }
        }
    }
}
