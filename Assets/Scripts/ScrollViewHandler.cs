using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewHandler : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UICardController _cardController;
    [SerializeField] private RectTransform _transform;

    void Awake()
    {
        //foreach (var unit in _gameManager.units)
        //{
        //    var unitCard = Instantiate(_cardController, _transform);
        //    UICardController uICardController = unitCard.GetComponent<UICardController>();

        //    uICardController.unit = unit;
        //}
    }

    void Start()
    {
        _transform.sizeDelta = new Vector2(_transform.sizeDelta.x, _transform.sizeDelta.y * _gameManager.units.Count);
        foreach (var unit in _gameManager.units)
        {
            var unitCard = Instantiate(_cardController, _transform.transform);
            UICardController uICardController = unitCard.GetComponent<UICardController>();

            uICardController.Initialize(unit);
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClicked()
    {
        gameObject.SetActive(true);

    }
}
