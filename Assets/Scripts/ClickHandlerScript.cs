using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ClickHandlerScript : MonoBehaviour
{
    const float cooldown = 0.5f;
    float timeToCooldown = 0.5f;
    GameObject clickedObject;

    public AllyMenuInfo menuInfo;

    void FixedUpdate()
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
        // Проверка, находится ли указатель над UI-элементом
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }

    private void HandleUIClick()
    {
        if (Input.GetMouseButton(0) && timeToCooldown >= cooldown)
        {
            // Получаем текущий UI-объект под указателем
            PointerEventData pointerData = new(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            // Берём первый элемент (он находится "сверху")
            if (results.Count > 0)
            {
                var topUIElement = results[0].gameObject;

                if (topUIElement.TryGetComponent<ISelectable>(out var selectable))
                {
                    selectable.OnClick();
                    clickedObject = topUIElement;
                    timeToCooldown = 0;
                }
            }
        }
    }

    private void HandleWorldClick()
    {
        // Выполняем Raycast для физических объектов
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonDown(0) && hits.Length > 0 && timeToCooldown >= cooldown)
        {
            // Сортируем объекты по z-координате (ближайший к камере — "сверху")
            System.Array.Sort(hits, (a, b) => a.collider.transform.position.z.CompareTo(b.collider.transform.position.z));

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.TryGetComponent<ISelectable>(out var selectable))
                {
                    selectable.OnClick();
                    clickedObject = hit.collider.gameObject;
                    timeToCooldown = 0;
                    break; // Обрабатываем только первый (верхний) объект
                }
            }
        }

        else if (Input.GetMouseButton(0) && hits.Length == 0)
        {
            menuInfo.SetParentAndChildrenDisable();
        }
    }
}