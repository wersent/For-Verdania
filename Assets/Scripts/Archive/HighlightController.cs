using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class HighlightController : MonoBehaviour
{
    public static HighlightController Instance { get; private set; }

    private IHighlightable _currentHighlighted;
    private IHighlightable _draggedObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterDraggedObject(GameObject draggedObj)
    {
        if (draggedObj.TryGetComponent<SpriteRenderer>(out var spriteRenderer))
        {
            spriteRenderer.color = Color.black;
        }
    }

    public void ProcessHighlighting(Vector2 mousePosition)
    {
        // �������� ������ ��� ��������
        var hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        var newHighlight = hit.collider?.GetComponent<IHighlightable>();

        // ���� ��������� �� ���������� - ������ �� ������
        if (newHighlight == _currentHighlighted) return;

        // ���������� ���������� ���������
        _currentHighlighted?.ResetHighlight();

        // ������������� ����� ���������
        if (newHighlight != null && newHighlight != (IHighlightable)_draggedObject)
        {
            newHighlight.Highlight(Color.red);
            _currentHighlighted = newHighlight;
        }
        else
        {
            _currentHighlighted = null;
        }
    }

    public void ClearAllHighlights()
    {
        if (_draggedObject != null)
        {
            _draggedObject.ResetHighlight();
            _draggedObject = null;
        }

        if (_currentHighlighted != null)
        {
            _currentHighlighted.ResetHighlight();
            _currentHighlighted = null;
        }
    }
}
*/