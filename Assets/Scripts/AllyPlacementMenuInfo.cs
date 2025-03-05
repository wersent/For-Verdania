using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class AllyPlacementMenuInfo : MonoBehaviour, ISelectable
{
    
    public void OnClick()
    {
        Debug.Log("saas");
    }

    void FixedUpdate()
    {
        //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    }
}
