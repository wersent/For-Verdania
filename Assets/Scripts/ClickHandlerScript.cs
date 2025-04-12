using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickHandlerScript : MonoBehaviour
{
    const float cooldown = 0.5f;
    float timeToCooldown = 0.5f;
    GameObject clickedObject;

    void Update()
    {
        // �������� ��� ������� ��� �������� (UI + 2D)
        var (hasUI, has2D) = GetObjectsUnderPointer();

        // ���� ���� ���� �� ���� UI ������� - ���������� �Ѩ
        if (hasUI)
        {
            return;
        }

        // ������������ ������ "������" 2D ����� (��� UI ��� ��������)
        if (Input.GetMouseButton(0) && has2D != null &&
            (timeToCooldown >= cooldown || !ReferenceEquals(has2D, clickedObject)))
        {
            ProcessClick(has2D);
        }

        timeToCooldown += Time.deltaTime;
    }

    // ���������� (���� �� UI, ������ 2D ������)
    private (bool, GameObject) GetObjectsUnderPointer()
    {
        bool hasUI = false;
        GameObject first2DObject = null;

        // 1. ��������� UI ��������
        if (EventSystem.current != null)
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            foreach (var result in results)
            {
                if (result.gameObject.GetComponent<Graphic>()?.raycastTarget == true)
                {
                    hasUI = true;
                    break;
                }
            }
        }

        // 2. ��������� 2D ������� ������ ���� ��� UI
        if (!hasUI)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                Vector2.zero
            );

            if (hit.collider != null)
            {
                first2DObject = hit.collider.gameObject;
            }
        }

        return (hasUI, first2DObject);
    }

    private void ProcessClick(GameObject target)
    {
        if (target.TryGetComponent<ISelectable>(out var selectable))
        {
            selectable.OnClick();
            timeToCooldown = 0;
            clickedObject = target;
        }
    }
}
