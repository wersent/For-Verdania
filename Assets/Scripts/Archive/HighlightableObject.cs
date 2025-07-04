using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HighlightableObject : MonoBehaviour, IHighlightable
{
    private SpriteRenderer _renderer;
    private Color _originalColor;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _originalColor = _renderer.color;
    }

    public void Highlight(Color color) => _renderer.color = color;
    public void ResetHighlight() => _renderer.color = _originalColor;
}
