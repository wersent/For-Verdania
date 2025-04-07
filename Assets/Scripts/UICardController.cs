using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICardController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected Unit unit;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] protected Image _image;

    public void OnPointerClick(PointerEventData eventData)
    {

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
