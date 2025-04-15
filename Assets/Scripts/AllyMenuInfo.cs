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

    public void SetParentAndChildrenDisable()
    {
        Transform parent = transform;
        Button[] buttons = parent.GetComponents<Button>();
        Image[] images = parent.GetComponents<Image>();
        // Деактивируем всех потомков, когда родитель деактивируется
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Button>() == null && child.gameObject.GetComponent<Image>() == null) child.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
