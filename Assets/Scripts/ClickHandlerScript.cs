using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ClickHandlerScript : MonoBehaviour
{
    const float cooldown = 10;
    float timeToCooldown = 10;
    string objectName = string.Empty;

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButton(0) && hit.collider != null && (timeToCooldown >= cooldown || hit.collider.gameObject.name != objectName))
        {
            Debug.Log(hit.collider);
            if (hit.collider.gameObject.TryGetComponent<ISelectable>(out var selectable)) hit.collider.gameObject.GetComponent<ISelectable>().OnClick();

            timeToCooldown = 0;

            objectName = hit.collider.gameObject.name;
            
        }
        timeToCooldown += Time.deltaTime;
    }
}
