using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ClickHandlerScript : MonoBehaviour
{
    const float cooldown = 0.5f;
    float timeToCooldown = 0.5f;
    GameObject clickedObject;

    public AllyMenuInfo menuInfo;

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        //Debug.Log(hit.collider);
        if (Input.GetMouseButton(0) && hit.collider != null && (timeToCooldown >= cooldown || !ReferenceEquals(hit.collider.gameObject, clickedObject)))
        {
            Debug.Log(hit.collider);
            if (hit.collider.gameObject.TryGetComponent<ISelectable>(out var selectable)) selectable.OnClick();

            timeToCooldown = 0;

            clickedObject = hit.collider.gameObject;          
        }
        //else if (Input.GetMouseButton(0) && hit.collider == null)
        //{
        //    menuInfo.gameObject.SetActive(false);
        //}
        timeToCooldown += Time.deltaTime;
    }
}
