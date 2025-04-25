using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPanel2 : MonoBehaviour, ISetParentAndChildrenDisable
{
    [SerializeField] protected ScrollViewHandler _scrollViewHandler;
    [SerializeField] private UnitRegiment _unitRegiment;
    [SerializeField] private Image _menuBackground;

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

        foreach (Transform child in transform)
        {
            if (child.gameObject.TryGetComponent<UnitCompositionController>(out var unitCompositionController)) unitCompositionController.Initialize(_scrollViewHandler);
        }
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
