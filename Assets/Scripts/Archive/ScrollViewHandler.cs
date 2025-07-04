using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewHandler : MonoBehaviour, IButtonClicked
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UICardController _cardController;
    [SerializeField] private RectTransform _contentTransform;
    [SerializeField] private RectTransform _rectTransform;

    void Start()
    {
        _contentTransform.sizeDelta = new Vector2(_contentTransform.sizeDelta.x, _contentTransform.sizeDelta.y * _gameManager.units.Count);
        foreach (var unit in _gameManager.units)
        {
            var unitCard = Instantiate(_cardController, _contentTransform.transform);
            UICardController uICardController = unitCard.GetComponent<UICardController>();

            uICardController.Initialize(unit);
        }
        gameObject.SetActive(false);
    }

    public void Initialize(GameObject gameObject)
    {
        _gameManager = gameObject.GetComponent<GameManager>();
    }

    public void ButtonClicked()
    {
        gameObject.SetActive(true);
    }

    public void OnSetActive(GameObject gameObject)
    {
        int rightEdge = (int)(gameObject.GetComponent<RectTransform>().anchoredPosition.x + gameObject.GetComponent<RectTransform>().rect.width / 2) + 15;
        float newPosX = rightEdge + _rectTransform.rect.width;

        float newPosY = gameObject.GetComponent<RectTransform>().anchoredPosition.y;

        Vector2 newPosition = new(newPosX, newPosY);
        _rectTransform.anchoredPosition = newPosition;
        gameObject.SetActive(true);
    }
}
