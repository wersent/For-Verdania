using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRegiment : Unit
{
    public delegate void OnPositionChange(ref Placement placement);
    OnPositionChange positionChange;

    public List<Unit> unitsTypes = new(2);
    [SerializeField] private Color color;
    [SerializeField] private Placement _placement;

    public override void Attack(int damage)
    {
        
    }

    public override void OnDeath()
    {
        
    }

    public void Initialize(ref Placement placement)
    {
        gameObject.transform.position = placement.transform.position;
        placement._unitRegiment = this;
        _placement = placement;
    }

    private void OnChangePosition(ref Placement placement)
    {
        placement._unitRegiment = null;

    }

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        color = gameObject.GetComponent<SpriteRenderer>().color;
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
        spriteRenderer.color = color;

        // Делаем рейкаст с явным указанием параметров
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, Mathf.Infinity);

        if (hit.collider.TryGetComponent<Transform>(out var transfr))
        {
            transform.position = transfr.position;
            Debug.Log($"Object moved to: {transform.position}");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
