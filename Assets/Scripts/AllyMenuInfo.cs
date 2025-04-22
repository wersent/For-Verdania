using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class AllyMenuInfo : MonoBehaviour, ISelectable
{
    public Placement placementPrefub;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnClick()
    {
        placementPrefub = GetComponent<Placement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void SetTitleName(string title)
    {
        _textMeshProUGUI.text = title;
    }

    public void SetParentAndChildrenDisable()
    {
        // Деактивируем всех потомков, когда родитель деактивируется
        foreach (Transform child in transform)
        {
            if (child.gameObject.TryGetComponent<IButtonClicked>(out var buttonClicked)) child.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
