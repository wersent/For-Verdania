using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.XR;

public class UICardController : MonoBehaviour, ISelectable
{
    [SerializeField] private Unit unit;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private Image _image;
    [SerializeField] private UnitRegiment _unitRegiment;
    [SerializeField] private AllyMenuInfo _allyMenuInfo;

    public void OnClick()
    {
        
    }

    public void Initialize(Unit unitData)
    {
        unit = unitData;
        _image.sprite = unit.GetIcon();
        _textMeshProUGUI.text = unit.Description;
        _textMeshProUGUI.fontSize = 18;
        _spriteRenderer.color = Color.white;
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
