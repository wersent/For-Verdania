using Assets.Scripts.Features.GridSystem;
using LevelViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEditor.Profiling.HierarchyFrameDataView;

public class RegimentView : MonoBehaviour
{
    private RegimentViewModel _regimentVM;
    private IUiCoordinateConverter _uiCoordinateConverter;
    [SerializeField] private int huy = 9;
    [SerializeField] private RectTransform _rectTransform;

    [Inject]
    public void Init(RegimentViewModel regiment, IUiCoordinateConverter uiCoordinateConverter)
    {
        _regimentVM = regiment;
        _uiCoordinateConverter = uiCoordinateConverter;
        _regimentVM.OnRegimentMove += OnPositionChanged;
        _rectTransform.anchoredPosition = _uiCoordinateConverter.ToAnchoredPosition(_regimentVM.CurrentPosition);

        //_rectTransform.anchoredPosition = new Vector2(_regimentVM.CurrentPosition.x * 100f, _regimentVM.CurrentPosition.y * 100f);
    }

    private void Start()
    {
        //_regimentVM.OnRegimentMove += OnPositionChanged;
    }

    public void OnPositionChanged(RegimentAction move, Vector2 newPosition)
    {
        _rectTransform.anchoredPosition = _uiCoordinateConverter.ToAnchoredPosition(newPosition);
    }

    public class Factory : PlaceholderFactory<RegimentViewModel, RegimentView> { }
}
