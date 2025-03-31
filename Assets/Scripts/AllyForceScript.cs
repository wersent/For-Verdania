using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AllyForceScript : MonoBehaviour
{
    public AllyMenuInfo menuInfo;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnMouseDown()
    {
        HighlightController.Instance.RegisterDraggedObject(gameObject);
    }

    private void OnMouseDrag()
    {
        HighlightController.Instance.RegisterDraggedObject(gameObject);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        HighlightController.Instance.ProcessHighlighting(mousePos);
    }

    private void OnMouseUp()
    {
        // Выносим повторяющиеся вызовы в переменные
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Очищаем выделения
        HighlightController.Instance.ClearAllHighlights();

        // Устанавливаем стандартный цвет
        spriteRenderer.color = new Color(0.5f, 0.4646226f, 0.4646226f);

        // Делаем рейкаст с явным указанием параметров
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, Mathf.Infinity);

        if (hit.collider != null)
        {
            transform.position = hit.collider.transform.position;
            Debug.Log($"Object moved to: {transform.position}");
        }
    }

    public void ButtonClicked()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;

        // Получаем ссылку на объект один раз
        GameObject selectedObject = menuInfo.aPMI.gameObject;
        Vector3 targetPosition = selectedObject.transform.position;

        // Устанавливаем позицию
        transform.position = targetPosition;
    }
}
