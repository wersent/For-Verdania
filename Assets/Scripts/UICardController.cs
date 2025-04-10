using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICardController : MonoBehaviour
{
    public Unit unit;
    public SpriteRenderer _spriteRenderer;
    public TextMeshProUGUI _textMeshProUGUI;
    public Image _image;

    void Awake()
    {

    }

    void Start()
    {

    }

    public void Initialize(Unit unitData)
    {
        unit = unitData;
        _image.sprite = unit.GetIcon();
        _textMeshProUGUI.text = unit.Description;
        _textMeshProUGUI.fontSize = 18;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        // Другие настройки
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


    }
}
