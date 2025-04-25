using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRegiment : Unit, ISelectable
{
    public event Action<Placement> PositionChanged = delegate { };

    public List<Unit> unitsTypes = new(2);
    [SerializeField] private bool _isDragging = false;
    [SerializeField] private float _timeInHolding = 0f;
    [SerializeField] private const float _holdingCooldown = 1f;
    [SerializeField] private Color _color;
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
        _color = gameObject.GetComponent<SpriteRenderer>().color;
        PositionChanged += _placement.SwitchPosition;
        PositionChanged += (Placement placement) => _placement = placement;
    }

    public void OnClick(GameObject gameObject)
    {
        _placement._allyMenuInfo.gameObject.SetActive(true);
        if (_placement._allyMenuInfo.gameObject.TryGetComponent<ISelectable>(out var selectable))
        {
            selectable.OnClick(this.gameObject);
        }
    }

    private void OnMouseDrag()
    {
        if (_isDragging)
        {
            HighlightController.Instance.RegisterDraggedObject(gameObject);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            HighlightController.Instance.ProcessHighlighting(mousePos);
        }
    }

    private void OnMouseUp()
    {
        if (_isDragging)
        {
            // Выносим повторяющиеся вызовы в переменные
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Очищаем выделения
            HighlightController.Instance.ClearAllHighlights();

            // Устанавливаем стандартный цвет
            spriteRenderer.color = _color;

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
        _isDragging = false;
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
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                _timeInHolding += Time.deltaTime;

                // Проверяем, превышен ли порог времени
                if (_timeInHolding >= _holdingCooldown)
                {
                    _isDragging = true;
                }
            }
            else
            {
                _timeInHolding = 0f;
            }
        }
        else
        {
            _timeInHolding = 0f;
            _isDragging = false; // Сбрасываем состояние перетаскивания при отпускании кнопки
        }
    }
}
