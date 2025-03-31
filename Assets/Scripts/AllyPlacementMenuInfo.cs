using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class AllyPlacementMenuInfo : MonoBehaviour
{
    public AllyMenuInfo menuInfo;

    void Start()
    {

    }

    public void OnMouseDown()
    {
        menuInfo.gameObject.SetActive(true);
        if (menuInfo.gameObject.TryGetComponent<ISelectable>(out var selectable)) { selectable.OnClick(); menuInfo.aPMI = this; }
    }

    void FixedUpdate()
    {

        //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    }
}
