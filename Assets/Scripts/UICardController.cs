using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICardController : MonoBehaviour, IPointerClickHandler
{
    public Unit unit;
    public SpriteRenderer _spriteRenderer;
    public TextMeshProUGUI _textMeshProUGUI;
    public Image _image;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Add {unit.name}");
    }

    void Awake()
    {
        _image = unit.GetIcon();
        _textMeshProUGUI = unit.GetDescription();

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
