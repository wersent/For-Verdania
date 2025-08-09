using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
/*
public class AllyMenuInfo : MonoBehaviour, ISelectable, ISetParentAndChildrenDisable
{
    public Placement _placement;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private PlacementInfoController _placementInfoController;
    [SerializeField] private TestPanel2 _testPanel2;
    [SerializeField] private ScrollViewHandler _scrollViewHandler;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) if (child.gameObject.TryGetComponent<ScrollViewHandler>(out var scrollViewHandler)) _scrollViewHandler = scrollViewHandler.GetComponent<ScrollViewHandler>();
        gameObject.SetActive(false);
    }

    public void OnClick(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<Placement>(out Placement placement))
        {
            _placement = placement;
            SetChildrenDisable(_placementInfoController.gameObject);
            _placementInfoController.gameObject.SetActive(true);
            _scrollViewHandler.gameObject.transform.SetParent(_placementInfoController.transform);
            _placementInfoController.Initialize(_scrollViewHandler);
        }
        else if (gameObject.TryGetComponent<UnitRegiment>(out UnitRegiment unitRegiment))
        {
            SetChildrenDisable(_testPanel2.gameObject);
            _testPanel2.gameObject.SetActive(true);
            _scrollViewHandler.gameObject.transform.SetParent(_testPanel2.transform);
            _testPanel2.Initialize(_scrollViewHandler);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void SetTitleName(string title)
    {
        _textMeshProUGUI.text = title;
    }

    private void SetChildrenDisable(GameObject notDisableObject)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.TryGetComponent<ISetParentAndChildrenDisable>(out var setParentAndChildrenDisable) && child.gameObject != notDisableObject) setParentAndChildrenDisable.SetParentAndChildrenDisable();
        }
    }

    public void SetParentAndChildrenDisable()
    {
        // ������������ ���� ��������, ����� �������� ��������������
        foreach (Transform child in transform)
        {
            if (child.gameObject.TryGetComponent<ISetParentAndChildrenDisable>(out var setParentAndChildrenDisable)) setParentAndChildrenDisable.SetParentAndChildrenDisable();
        }
        gameObject.SetActive(false);
    }
}
*/