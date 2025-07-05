using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
/*
public class ClickHandlerScript : MonoBehaviour
{
    const float cooldown = 0.5f;
    float timeToCooldown = 0.5f;
    GameObject clickedObject;

    public AllyMenuInfo menuInfo;

    void Update()
    {
        if (IsPointerOverUI())
        {
            HandleUIClick();
        }
        else
        {
            HandleWorldClick();
        }

        timeToCooldown += Time.deltaTime;
    }

    private bool IsPointerOverUI()
    {
        // ��������, ��������� �� ��������� ��� UI-���������
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }

    private void HandleUIClick()
    {
        if (Input.GetMouseButton(0) && timeToCooldown >= cooldown)
        {
            // �������� ������� UI-������ ��� ����������
            PointerEventData pointerData = new(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new();
            EventSystem.current.RaycastAll(pointerData, results);

            // ���� ������ �������
            if (results.Count > 0)
            {
                var topUIElement = results[0].gameObject;

                if (topUIElement.TryGetComponent<ISelectable>(out var selectable))
                {
                    selectable.OnClick(topUIElement);
                    clickedObject = topUIElement;
                    timeToCooldown = 0;
                }
            }
        }
    }

    private void HandleWorldClick()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonDown(0) && hits.Length > 0 && timeToCooldown >= cooldown)
        {
            // ��������� ������� �� z-���������� (��������� - ������)
            System.Array.Sort(hits, (a, b) => a.collider.transform.position.z.CompareTo(b.collider.transform.position.z));

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.TryGetComponent<ISelectable>(out var selectable))
                {
                    selectable.OnClick(hit.collider.gameObject);
                    clickedObject = hit.collider.gameObject;
                    timeToCooldown = 0;
                    break;
                }
            }
        }

        else if (Input.GetMouseButton(0) && hits.Length == 0)
        {
            menuInfo.SetParentAndChildrenDisable();
        }
    }
}
*/