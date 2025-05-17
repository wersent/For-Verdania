using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlacementInfoController : MonoBehaviour, ISetParentAndChildrenDisable
{
    [SerializeField] private ScrollViewHandler _scrollViewHandler;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private Button _button;
    private RectTransform _buttonRectTransform;

    void Awake()
    {
        _buttonRectTransform = _button.GetComponent<RectTransform>();
    }

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

        _scrollViewHandler.gameObject.SetActive(true);
        _scrollViewHandler.OnSetActive(_button.gameObject);
        _scrollViewHandler.gameObject.SetActive(false);

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
