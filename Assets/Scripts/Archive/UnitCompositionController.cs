using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
/*
public class UnitCompositionController : MonoBehaviour, ISelectable
{
    [SerializeField] private Image _unitIcon;
    [SerializeField] private ScrollViewHandler _scrollViewHandler;
    private Outline _outline;
    [SerializeField] private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnClick(GameObject unitRegiment)
    {
        _scrollViewHandler.gameObject.SetActive(true);
        _scrollViewHandler.OnSetActive(this.gameObject);
    }

    public void Initialize(ScrollViewHandler scrollViewHandler)
    {
        _scrollViewHandler = scrollViewHandler;
    }

    private void Update()
    {
        // �������� ������� ������� � ������� �����������
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ���������, ��������� �� ������ ��� ��������
        Collider2D hit = Physics2D.OverlapPoint(mouseWorldPosition);

        if (hit != null && hit.gameObject == this.gameObject)
        {
            // ��������� Outline, ���� ��� ��� ���
            if (_outline == null)
            {
                _outline = gameObject.AddComponent<Outline>();
                _outline.effectColor = Color.red;
                _outline.effectDistance = new Vector2(2, 2); // ������ ���������
            }
        }
        else
        {
            // ������� Outline, ���� ������ ����� �� ������� �������
            if (_outline != null)
            {
                Destroy(_outline);
                _outline = null;
            }
        }
    }
}
*/