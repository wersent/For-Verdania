using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRegiment : Unit
{
    public event Action<Placement> PositionChanged = delegate { };

    public List<Unit> unitsTypes = new(2);
    [SerializeField] private Color color;
    [SerializeField] private Placement _placement;

    public override void Attack(int damage)
    {
        
    }

    public override void OnDeath()
    {
        
    }

    public void Initialize(Placement placement)
    {
        gameObject.transform.position = placement.transform.position;
        placement._unitRegiment = this;
        _placement = placement;
    }

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        color = gameObject.GetComponent<SpriteRenderer>().color;
        PositionChanged += _placement.SwitchPosition;
        PositionChanged += (Placement placement) => _placement = placement;
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

        if (hit.collider != null && hit.collider.TryGetComponent(out Placement placement) && placement != _placement)
        {
            PositionChanged(placement);

            if (hit.collider.TryGetComponent<Transform>(out var transfr))
            {
                gameObject.transform.SetParent(placement.transform);
                transform.position = transfr.position;

                Debug.Log($"Object moved to: {transform.position}");
            }
        }
    }

    public void OnUnitsCompositionChange(Unit unit)
    {
        if (unitsTypes.Count <= 2)
        {
            unitsTypes.Add(unit);
        }
        else
        {

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
