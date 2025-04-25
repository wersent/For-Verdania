using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestPanel1 : MonoBehaviour, ISetParentAndChildrenDisable
{
    [SerializeField] private ScrollViewHandler _scrollViewHandler;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(ScrollViewHandler scrollViewHandler)
    {
        _scrollViewHandler = scrollViewHandler;

        int rightEdge = (int)(_button.GetComponent<RectTransform>().transform.position.x + _button.GetComponent<RectTransform>().rect.width / 2) + 10;
        float newPosX = rightEdge + _scrollViewHandler.GetComponent<RectTransform>().rect.width;
        Vector2 newPosition = _scrollViewHandler.GetComponent<RectTransform>().anchoredPosition;
        newPosition.x = newPosX;
        _scrollViewHandler.GetComponent<RectTransform>().anchoredPosition = newPosition;

        _button.onClick.AddListener(_scrollViewHandler.ButtonClicked);
    }

    public void SetParentAndChildrenDisable()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.TryGetComponent<IButtonClicked>(out var buttonClicked)) child.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
