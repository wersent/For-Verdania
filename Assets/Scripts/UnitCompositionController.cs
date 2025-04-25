using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitCompositionController : MonoBehaviour, ISelectable
{
    [SerializeField] private Image _unitIcon;
    [SerializeField] private ScrollViewHandler _scrollViewHandler;
    public Outline _outline;

    public void OnClick(GameObject unitRegiment)
    {
        int rightEdge = (int)(this.GetComponent<RectTransform>().position.x + this.GetComponent<RectTransform>().rect.width / 2) + 15;
        float newPosX = rightEdge + _scrollViewHandler.GetComponent<RectTransform>().rect.width;

        int upEdge = (int)(this.GetComponent<RectTransform>().position.y + this.GetComponent<RectTransform>().rect.height / 2);
        float newPosY = upEdge + _scrollViewHandler.GetComponent<RectTransform>().rect.height / 2;

        Vector2 newPosition = new(newPosX, newPosY);
        _scrollViewHandler.GetComponent<RectTransform>().anchoredPosition = newPosition;
        _scrollViewHandler.gameObject.SetActive(true);
    }

    public void Initialize(ScrollViewHandler scrollViewHandler) => _scrollViewHandler = scrollViewHandler;

    void Update()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == this.gameObject)
        {
            _outline = gameObject.AddComponent<Outline>();
            _outline.effectColor = Color.red;
        }
    }
}
