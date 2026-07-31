using LevelViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.LevelModel;

public class RegimentModel
{
    private string _regName;
    private int _regHealth;
    private EntitySide _regSide;
    private HashSet<UnitBase> _regCom;
    private Vector2 _regPos;

    public bool IsAlive { get; private set; } = true;
    public string RegName => _regName;
    public int RegHealth
    {
        get => _regHealth;
        set => _regHealth = value;
    }
    public EntitySide RegSide => _regSide;
    public IReadOnlyCollection<UnitBase> RegCom => _regCom;
    public Vector2 RegPos => _regPos;
    public event Action<RegimentAction, Vector2> OnRegimentMove;

    public RegimentModel(string name, EntitySide entitySide, Vector2 position)
    {
        _regName = name;
        _regSide = entitySide;
        _regPos = position;
    }

    public void Move(Vector2 newPos)
    {
        _regPos = newPos;
        Debug.Log($"{_regPos}");
        OnRegimentMove?.Invoke(RegimentAction.Moving, newPos);
    }

    public void AddUnit(UnitBase unit)
    {
        _regCom.Add(unit);
        // логика пересчёта статов и абилок
    }
}
